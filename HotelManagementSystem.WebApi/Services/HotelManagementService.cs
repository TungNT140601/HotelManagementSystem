using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.WebApi.Services
{
    public class HotelManagementService: IHotelManagementService
    {
        public string AutoGeneId(string geneId)
        {
            Guid g = Guid.NewGuid();
            string Id = geneId + "_" + g.ToString();
            return Id;
        }
    }
}
