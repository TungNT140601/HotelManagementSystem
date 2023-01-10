using HotelManagementSystem.WebApi.Models.RoomTypeModel;
using HotelManagementSystem.WebApi.Services.RoomTypeService;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoomTypeController : ControllerBase
    {
        private readonly IRoomTypeService roomTypeService;
        public RoomTypeController(IRoomTypeService roomTypeService)
        {
            this.roomTypeService = roomTypeService;
        }
        [HttpGet]
        public Task<Dictionary<string, object>> GetRoomTypeById([Required] string id)
        {
            return roomTypeService.GetRoomTypeById(id);
        }
        [HttpGet]
        public Task<List<RoomTypeDto>> GetRoomTypes()
        {
            return roomTypeService.GetRoomTypes();
        }
        [HttpPost]
        public Task<Dictionary<string, object>> CreateOrUpdateRoomType(RoomTypeDto roomType)
        {
            return roomTypeService.CreateOrUpdateRoomType(roomType);
        }
        [HttpDelete]
        public Task<Dictionary<string, object>> DeleteRoomType([Required] string id)
        {
            return roomTypeService.DeleteRoomType(id);
        }
    }
}
