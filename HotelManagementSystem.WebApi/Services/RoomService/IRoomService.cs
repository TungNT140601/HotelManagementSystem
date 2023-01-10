using HotelManagementSystem.WebApi.Models.RoomModel;

namespace HotelManagementSystem.WebApi.Services.RoomService
{
    public interface IRoomService
    {
        Task<Dictionary<string, object>> GetRooms();
        Task<Dictionary<string, object>> GetRoomById(string id);
        Task<Dictionary<string, object>> GetRoomByRoomTypeId(string id);
        Task<Dictionary<string, object>> CreateOrUpdateRoom(RoomDto room);
        Task<Dictionary<string, object>> DeleteRoom(string id);
    }
}
