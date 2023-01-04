using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.WebApi.Services
{
    public interface IHotelManagementService
    {
        public string AutoGeneId(string geneId);
    }
}
