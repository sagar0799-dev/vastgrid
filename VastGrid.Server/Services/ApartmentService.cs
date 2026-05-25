using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VastGrid.Server.Data;
using VastGrid.Server.Interfaces;
using VastGrid.Server.Models.Entities;

namespace VastGrid.Server.Services
{
    public class ApartmentService(
        VastGridDbContext context,
        ILogger<ApartmentService> logger) : IApartmentService
    {
        public async Task<IEnumerable<Apartment>> GetApartmentsAsync()
        {
            logger.LogInformation("Retrieving all apartments from the database.");
            return await context.Apartments.ToListAsync();
        }
    }
}
