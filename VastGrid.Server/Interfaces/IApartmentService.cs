using System.Collections.Generic;
using System.Threading.Tasks;
using VastGrid.Server.Models.Entities;

namespace VastGrid.Server.Interfaces
{
    public interface IApartmentService
    {
        Task<IEnumerable<Apartment>> GetApartmentsAsync();
    }
}
