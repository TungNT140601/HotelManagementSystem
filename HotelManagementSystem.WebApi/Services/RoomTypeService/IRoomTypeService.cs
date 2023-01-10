using HotelManagementSystem.WebApi.Models.RoomTypeModel;

namespace HotelManagementSystem.WebApi.Services.RoomTypeService
{
    public interface IRoomTypeService
    {
        Task<Dictionary<string, object>> GetRoomTypeById(string id);
        Task<List<RoomTypeDto>> GetRoomTypes();
        Task<Dictionary<string, object>> CreateOrUpdateRoomType(RoomTypeDto roomType);
        Task<Dictionary<string, object>> DeleteRoomType(string id);
    }
}
