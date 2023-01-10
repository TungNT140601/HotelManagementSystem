using HotelManagementSystem.WebApi.DatabaseContext;
using HotelManagementSystem.WebApi.Models.RoomModel;
using HotelManagementSystem.WebApi.Services.RoomTypeService;
using System.Collections.Generic;

namespace HotelManagementSystem.WebApi.Services.RoomService
{
    public class RoomService: IRoomService
    {
        private readonly HotelManagementDBContext dBContext;
        private readonly IHotelManagementService hotelManagementService;
        private readonly IRoomTypeService roomTypeService;
        public RoomService(IRoomTypeService roomTypeService, IHotelManagementService hotelManagementService, HotelManagementDBContext hotelManagement)
        {
            this.roomTypeService = roomTypeService;
            this.hotelManagementService = hotelManagementService;
            this.dBContext = hotelManagement;
        }
        public async Task<Dictionary<string, object>> GetRooms()
        {
            try
            {
                var rooms = dBContext.Rooms.Where(x => x.IsDelete == false).ToList();
                var lst = new List<RoomDto>();
                foreach (var room in rooms)
                {
                    var rm = new RoomDto()
                    {
                        Description = room.Description,
                        RoomId = room.RoomId,
                        RoomNumber = room.RoomNumber,
                        RoomTypeId = room.RoomTypeId
                    };
                    lst.Add(rm);
                }
                return new Dictionary<string, object>() { { "result", lst } };
            }
            catch (Exception ex)
            {
                return new Dictionary<string, object>() { { "Error", new { msg = ex.Message } } };
            }
        }
        public async Task<Dictionary<string, object>> GetRoomById(string id)
        {
            try
            {
                if (id == null)
                {
                    return new Dictionary<string, object>() { { "Error", new { msg = "Room id is empty" } } };
                }
                else
                {
                    var room = dBContext.Rooms.Where(x => x.RoomId == id && x.IsDelete == false).FirstOrDefault();
                    if(room!= null)
                    {
                        return new Dictionary<string, object>() { { "result", room } };
                    }
                    else
                    {
                        return new Dictionary<string, object>() { { "Error", new { msg = "Room id is not exist" } } };
                    }
                }
            }
            catch (Exception ex)
            {
                return new Dictionary<string, object>() { { "Error", new { msg = ex.Message } } };
            }
        }
        public async Task<Dictionary<string, object>> GetRoomByRoomTypeId(string id)
        {
            try
            {
                if (id == null)
                {
                    return new Dictionary<string, object>() { { "Error", new { msg = "Room Type id is empty" } } };
                }
                else
                {
                    var room = dBContext.Rooms.Where(x => x.RoomTypeId == id && x.IsDelete == false).FirstOrDefault();
                    if (room != null)
                    {
                        return new Dictionary<string, object>() { { "result", room } };
                    }
                    else
                    {
                        return new Dictionary<string, object>() { { "Error", new { msg = "Room Type id is not exist" } } };
                    }
                }
            }
            catch (Exception ex)
            {
                return new Dictionary<string, object>() { { "Error", new { msg = ex.Message } } };
            }
        }
        public async Task<Dictionary<string, object>> CreateOrUpdateRoom(RoomDto room)
        {
            try
            {
                if (room.RoomId == null)
                {
                    var id = "";
                    do
                    {
                        id = hotelManagementService.AutoGeneId("RM");
                    } while (dBContext.Rooms.Where(x => x.RoomId == id && x.IsDelete == false).FirstOrDefault() != null);
                    var rm = new Room()
                    {
                        RoomId = id,
                        RoomNumber = room.RoomNumber,
                        RoomTypeId = room.RoomTypeId,
                        Description = room.Description,
                        IsDelete = false,
                        RoomType = dBContext.RoomTypes.Where(x => x.RoomTypeId == room.RoomTypeId && x.IsDelete == false).FirstOrDefault()
                    };
                    dBContext.Rooms.Add(rm);
                    dBContext.SaveChanges();
                    return new Dictionary<string, object>() { { "Success", new { msg = "Create room success" } } };
                }
                else
                {
                    var rm = dBContext.Rooms.Where(x => x.RoomId == room.RoomId && x.IsDelete == false).FirstOrDefault();
                    if(rm == null)
                    {
                        return new Dictionary<string, object>() { { "Error", new { msg = "Room is not exist" } } };
                    }
                    else
                    {
                        rm.RoomNumber = room.RoomNumber;
                        rm.Description = room.Description;
                        rm.RoomTypeId = room.RoomTypeId;
                        rm.RoomType = dBContext.RoomTypes.Where(x => x.RoomTypeId == room.RoomTypeId && x.IsDelete == false).FirstOrDefault();
                        dBContext.Rooms.Update(rm);
                        dBContext.SaveChanges();
                        return new Dictionary<string, object>() { { "Success", new { msg = "Update room success" } } };
                    }
                }
            }
            catch (Exception ex)
            {
                return new Dictionary<string, object>() { { "Error", new { msg = ex.Message } } };
            }
        }
        public async Task<Dictionary<string, object>> DeleteRoom(string id)
        {
            try
            {
                if (id == null)
                {
                    return new Dictionary<string, object>() { { "Error", new { msg = "Room id is empty" } } };
                }
                else
                {
                    var rm = dBContext.Rooms.Where(x => x.RoomId == id && x.IsDelete == false).FirstOrDefault();
                    if (rm == null)
                    {
                        return new Dictionary<string, object>() { { "Error", new { msg = "Room is not exist" } } };
                    }
                    else
                    {
                        rm.IsDelete = true;
                        dBContext.Rooms.Update(rm);
                        dBContext.SaveChanges();
                        return new Dictionary<string, object>() { { "Success", new { msg = "Delete room success" } } };
                    }
                }
            }
            catch (Exception ex)
            {
                return new Dictionary<string, object>() { { "Error", new { msg = ex.Message } } };
            }
        }
    }
}
