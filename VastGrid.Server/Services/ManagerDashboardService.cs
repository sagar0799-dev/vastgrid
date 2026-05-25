using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VastGrid.Server.Data;
using VastGrid.Server.Interfaces;
using VastGrid.Server.Models.DTOs;
using VastGrid.Server.Models.Entities;

namespace VastGrid.Server.Services
{
    public class ManagerDashboardService(
        VastGridDbContext context,
        KeycloakService keycloakService,
        ILogger<ManagerDashboardService> logger) : IManagerDashboardService
    {
        public async Task<IEnumerable<object>> GetResidentsAsync(string keycloakUserId)
        {
            logger.LogInformation("Retrieving residents list for User Keycloak ID: {UserId}", keycloakUserId);
            
            var manager = await context.Managers
                .Include(m => m.Apartments)
                .FirstOrDefaultAsync(m => m.KeycloakUserId == keycloakUserId);

            // If not a manager, return all residents (for Watchmen/Global access)
            if (manager == null)
            {
                logger.LogInformation("Manager profile not found. Returning global residents list for gate operations.");
                return await context.Residents
                    .Include(r => r.Apartment)
                    .Select(r => new
                    {
                        r.Id,
                        r.FirstName,
                        r.LastName,
                        Apartment = r.Apartment != null ? r.Apartment.BlockName : "Unassigned"
                    })
                    .ToListAsync();
            }

            var apartmentIds = manager.Apartments.Select(a => a.Id).ToList();

            return await context.Residents
                .Include(r => r.Apartment)
                .Where(r => apartmentIds.Contains(r.ApartmentId))
                .Select(r => new
                {
                    r.Id,
                    r.FirstName,
                    r.LastName,
                    Apartment = r.Apartment != null ? r.Apartment.BlockName : "Unassigned"
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<object>> GetStatisticsAsync(string keycloakUserId)
        {
            logger.LogInformation("Compiling occupancy statistics for Manager Keycloak ID: {ManagerId}", keycloakUserId);

            var manager = await context.Managers
                .Include(m => m.Apartments)
                .ThenInclude(a => a.Residents)
                .FirstOrDefaultAsync(m => m.KeycloakUserId == keycloakUserId);

            if (manager == null)
            {
                logger.LogWarning("Manager profile not found for Keycloak ID: {ManagerId}", keycloakUserId);
                throw new KeyNotFoundException("Manager profile not found.");
            }

            return manager.Apartments.Select(a => new
            {
                BlockName = a.BlockName,
                Sold = a.Residents.Count,
                Unsold = a.TotalFlats - a.Residents.Count
            }).ToList();
        }

        public async Task<IEnumerable<object>> GetApartmentsAsync(string keycloakUserId)
        {
            logger.LogInformation("Fetching blocks list for User Keycloak ID: {UserId}", keycloakUserId);

            var manager = await context.Managers
                .Include(m => m.Apartments)
                .FirstOrDefaultAsync(m => m.KeycloakUserId == keycloakUserId);

            // If not a manager, return all apartments (for Watchmen/Global access)
            if (manager == null)
            {
                logger.LogInformation("Manager profile not found. Returning global apartments list.");
                return await context.Apartments
                    .Select(a => new
                    {
                        a.Id,
                        a.BlockName,
                        a.TotalFlats
                    })
                    .ToListAsync();
            }

            return manager.Apartments.Select(a => new
            {
                a.Id,
                a.BlockName,
                a.TotalFlats
            }).ToList();
        }

        public async Task<bool> SellFlatAsync(string keycloakUserId, SellFlatDto dto)
        {
            logger.LogInformation("Processing flat sale on block {ApartmentId} by Manager Keycloak ID: {ManagerId}", dto.ApartmentId, keycloakUserId);

            var manager = await context.Managers
                .Include(m => m.Apartments)
                .FirstOrDefaultAsync(m => m.KeycloakUserId == keycloakUserId);

            if (manager == null)
            {
                logger.LogWarning("Manager profile not found for Keycloak ID: {ManagerId}", keycloakUserId);
                throw new KeyNotFoundException("Manager profile not found.");
            }

            var managesApartment = manager.Apartments.Any(a => a.Id == dto.ApartmentId);
            if (!managesApartment)
            {
                logger.LogWarning("Manager {ManagerId} attempted unauthorized sale on Block {ApartmentId}", keycloakUserId, dto.ApartmentId);
                throw new UnauthorizedAccessException("You do not have administrative management access for this apartment block.");
            }

            // Provision user in Keycloak via KeycloakService
            string keycloakResidentId;
            try
            {
                keycloakResidentId = await keycloakService.CreateResidentUserAsync(
                    dto.Username,
                    dto.Email,
                    dto.FirstName,
                    dto.LastName,
                    dto.Password
                );
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Keycloak OIDC account provisioning failed for resident: {Username}", dto.Username);
                throw;
            }

            // Add the resident to the local database
            var resident = new Resident
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                ApartmentId = dto.ApartmentId,
                KeycloakUserId = keycloakResidentId
            };

            context.Residents.Add(resident);
            await context.SaveChangesAsync();

            logger.LogInformation("Flat sold and resident record synchronized successfully. Keycloak ID: {KeycloakResidentId}", keycloakResidentId);
            return true;
        }
    }
}
