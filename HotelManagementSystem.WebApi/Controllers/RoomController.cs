using HotelManagementSystem.WebApi.Models.RoomModel;
using HotelManagementSystem.WebApi.Services.RoomService;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoomController: ControllerBase
    {
        private readonly IRoomService roomService;
        public RoomController (IRoomService roomService)
        {
            this.roomService = roomService;
        }
        [HttpGet]
        public Task<Dictionary<string, object>> GetRooms()
        {
            return roomService.GetRooms();
        }
        [HttpGet]
        public Task<Dictionary<string, object>> GetRoomById([Required] string id)
        {
            return roomService.GetRoomById(id);
        }
        [HttpGet]
        public Task<Dictionary<string, object>> GetRoomByRoomTypeId([Required] string id)
        {
            return roomService.GetRoomByRoomTypeId(id);
        }
        [HttpPost]
        public Task<Dictionary<string, object>> CreateOrUpdateRoom(RoomDto room)
        {
            return roomService.CreateOrUpdateRoom(room);
        }
        [HttpDelete]
        public Task<Dictionary<string, object>> DeleteRoom([Required] string id)
        {
            return roomService.DeleteRoom(id);
        }
    }
}
