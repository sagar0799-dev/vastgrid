using Microsoft.EntityFrameworkCore;
using VastGrid.Server.Models.Entities;
using System.Collections.Generic;

namespace VastGrid.Server.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // Seed Builders (3 builders)
            modelBuilder.Entity<Builder>().HasData(
                new Builder { Id = 1, CompanyName = "Aura Properties", ContactEmail = "builder@vastgrid.local", KeycloakUserId = "dev-builder-sub" },
                new Builder { Id = 2, CompanyName = "Skyline Dev", ContactEmail = "skyline@vastgrid.local" },
                new Builder { Id = 3, CompanyName = "Pinnacle Real Estate", ContactEmail = "pinnacle@vastgrid.local" }
            );

            // Seed Managers (15 managers)
            var managers = new List<Manager>();
            for (int i = 1; i <= 15; i++)
            {
                managers.Add(new Manager
                {
                    Id = i,
                    FirstName = $"Manager{i}First",
                    LastName = $"Manager{i}Last",
                    KeycloakUserId = $"manager-{i}-sso-uuid"
                });
            }
            modelBuilder.Entity<Manager>().HasData(managers);

            // Seed Apartments (2 blocks per builder = 6 blocks total)
            var apartments = new List<Apartment>();
            int apartmentId = 1;
            for (int builderId = 1; builderId <= 3; builderId++)
            {
                for (int j = 1; j <= 2; j++)
                {
                    apartments.Add(new Apartment
                    {
                        Id = apartmentId,
                        BuilderId = builderId,
                        BlockName = $"Block {(char)('A' + apartmentId - 1)}",
                        TotalFlats = 50
                    });
                    apartmentId++;
                }
            }
            modelBuilder.Entity<Apartment>().HasData(apartments);

            // Seed Residents (5 to 15 residents per block)
            var residents = new List<Resident>();
            int residentId = 1;
            foreach (var apt in apartments)
            {
                // Assign a pseudo-random number of residents per block (e.g., 5 + (apt.Id * 2))
                int residentCount = 5 + (apt.Id * 2); 
                for (int i = 0; i < residentCount; i++)
                {
                    residents.Add(new Resident
                    {
                        Id = residentId++,
                        FirstName = $"Resident{residentId}First",
                        LastName = $"Resident{residentId}Last",
                        KeycloakUserId = $"resident-{residentId}-sso-uuid",
                        PhoneNumber = $"+91 98{residentId.ToString().PadLeft(8, '0')}",
                        ApartmentId = apt.Id
                    });
                }
            }
            modelBuilder.Entity<Resident>().HasData(residents);

            // Seed ApartmentManagers Join Table (M:N)
            var apartmentManagers = new List<object>();
            // Manager 1 manages Blocks A, B, C, D, E (Ids: 1, 2, 3, 4, 5)
            apartmentManagers.Add(new { ApartmentsId = 1, ManagersId = 1 });
            apartmentManagers.Add(new { ApartmentsId = 2, ManagersId = 1 });
            apartmentManagers.Add(new { ApartmentsId = 3, ManagersId = 1 });
            apartmentManagers.Add(new { ApartmentsId = 4, ManagersId = 1 });
            apartmentManagers.Add(new { ApartmentsId = 5, ManagersId = 1 });
            // Manager 2 manages Block F (Id:6)
            apartmentManagers.Add(new { ApartmentsId = 6, ManagersId = 2 });
            
            // Assign remaining managers to random blocks to satisfy foreign keys
            for (int m = 5; m <= 15; m++)
            {
                apartmentManagers.Add(new { ApartmentsId = (m % 6) + 1, ManagersId = m });
            }

            modelBuilder.Entity<Apartment>()
                .HasMany(a => a.Managers)
                .WithMany(m => m.Apartments)
                .UsingEntity(j => j.ToTable("ApartmentManagers")
                    .HasData(apartmentManagers.ToArray()));
        }
    }
}
