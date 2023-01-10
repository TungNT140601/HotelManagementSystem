using HotelManagementSystem.WebApi.DatabaseContext;
using HotelManagementSystem.WebApi.Models.RoomTypeModel;

namespace HotelManagementSystem.WebApi.Services.RoomTypeService
{
    public class RoomTypeService : IRoomTypeService
    {
        private readonly HotelManagementDBContext dBContext;
        private readonly IHotelManagementService service;
        public RoomTypeService(HotelManagementDBContext dBContext, IHotelManagementService service)
        {
            this.dBContext = dBContext;
            this.service = service;
        }
        public async Task<Dictionary<string, object>> GetRoomTypeById(string id)
        {
            try
            {
                if (id == null)
                {
                    return new Dictionary<string, object>() { { "Error", new { msg = "Room Type Id cannot be empty!!!" } } };
                }
                else
                {
                    var rtype = dBContext.RoomTypes.Where(x => x.RoomTypeId == id && x.IsDelete == false).FirstOrDefault();
                    if (rtype != null)
                    {
                        return new Dictionary<string, object> { { "result", rtype } };
                    }
                    else
                    {
                        return new Dictionary<string, object>() { { "Error", new { msg = "Room Type Id dose not exist!!!" } } };
                    }
                }
            }
            catch (Exception ex)
            {
                return new Dictionary<string, object>() { { "Error", new { msg = ex.Message } } };
            }
        }
        public async Task<List<RoomTypeDto>> GetRoomTypes()
        {
            try
            {
                var lst = dBContext.RoomTypes.Where(x => x.IsDelete == false).ToList();
                var rst = new List<RoomTypeDto>();
                foreach (var r in lst)
                {
                    var rtd = new RoomTypeDto()
                    {
                        Cost = r.Cost,
                        Description = r.Description,
                        RoomImg = r.RoomImg,
                        RoomTypeId = r.RoomTypeId,
                        RoomTypeName = r.RoomTypeName
                    };
                    rst.Add(rtd);
                }
                return rst;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<Dictionary<string, object>> CreateOrUpdateRoomType(RoomTypeDto roomType)
        {
            try
            {
                if (roomType.RoomTypeId == null)
                {
                    string id = "";
                    do
                    {
                        id = service.AutoGeneId("RT");
                    } while (dBContext.RoomTypes.Where(x => x.RoomTypeId == id).FirstOrDefault() != null);
                    var room = new RoomType()
                    {
                        Cost = roomType.Cost,
                        Description = roomType.Description,
                        RoomImg = roomType.RoomImg,
                        RoomTypeId = id,
                        RoomTypeName = roomType.RoomTypeName,
                        IsDelete = false
                    };
                    dBContext.RoomTypes.Add(room);
                    dBContext.SaveChanges();
                    return new Dictionary<string, object>() { { "Success", new { msg = "Create RoomType Success" } } };
                }
                else
                {
                    var room = dBContext.RoomTypes.Where(x => x.RoomTypeId == roomType.RoomTypeId && x.IsDelete == false).FirstOrDefault();
                    if (room == null)
                    {
                        return new Dictionary<string, object>() { { "Error", new { msg = "Room Type dose not exist!!!" } } };
                    }
                    else
                    {
                        room.RoomTypeName = roomType.RoomTypeName;
                        room.RoomImg = roomType.RoomImg;
                        room.Cost = roomType.Cost;
                        room.Description = roomType.Description;
                        dBContext.RoomTypes.Update(room);
                        dBContext.SaveChanges();
                        return new Dictionary<string, object>() { { "Success", new { msg = "Update RoomType Success" } } };
                    }
                }
            }
            catch (Exception ex)
            {
                return new Dictionary<string, object>() { { "Error", new { msg = ex.Message } } };
            }
        }
        public async Task<Dictionary<string, object>> DeleteRoomType(string id)
        {
            try
            {
                if (id == null)
                {
                    return new Dictionary<string, object>() { { "Error", new { msg = "Room Type Id cannot be empty!!!" } } };
                }
                else
                {
                    var rtype = dBContext.RoomTypes.Where(x => x.RoomTypeId == id && x.IsDelete == false).FirstOrDefault();
                    if (rtype != null)
                    {
                        dBContext.RoomTypes.Remove(rtype);
                        dBContext.SaveChanges();
                        return new Dictionary<string, object> { { "result", new { msg = "Success" } } };
                    }
                    else
                    {
                        return new Dictionary<string, object>() { { "Error", new { msg = "Room Type Id dose not exist!!!" } } };
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
