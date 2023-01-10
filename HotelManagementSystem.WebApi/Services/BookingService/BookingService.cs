using HotelManagementSystem.WebApi.DatabaseContext;
using HotelManagementSystem.WebApi.Models.BookingModel;
using HotelManagementSystem.WebApi.Models.CustomerModel;
using HotelManagementSystem.WebApi.Models.RoomModel;
using HotelManagementSystem.WebApi.Services.CustomerService;
using HotelManagementSystem.WebApi.Services.RoomService;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.WebApi.Services.BookingService
{
    public class BookingService : IBookingService
    {
        private readonly HotelManagementDBContext dBContext;
        private readonly IHotelManagementService hotelManagementService;
        public BookingService(HotelManagementDBContext dBContext, IHotelManagementService hotelManagementService)
        {
            this.dBContext = dBContext;
            this.hotelManagementService = hotelManagementService;
        }
        public async Task<Dictionary<string, object>> GetBookings()
        {
            try
            {
                var bookings = dBContext.Bookings.Where(x => x.IsDelete == false).ToList();
                var lst = new List<BookingDto>();
                foreach (var booking in bookings)
                {
                    var index = new BookingDto()
                    {
                        BookingId = booking.BookingId,
                        BookingDate = booking.BookingDate,
                        CheckIn = booking.CheckIn,
                        CheckOut = booking.CheckOut,
                        CustomerId = booking.CustomerId,
                        RoomId = booking.RoomId
                    };
                    lst.Add(index);
                }
                return new Dictionary<string, object>() { { "result", lst } };
            }
            catch (Exception ex)
            {
                return new Dictionary<string, object>() { { "Error", new { msg = ex.Message } } };
            }
        }
        public async Task<Dictionary<string, object>> GetBookingById([Required] string id)
        {
            try
            {
                if (id == null)
                {
                    return new Dictionary<string, object>() { { "Error", new { msg = "Booking id is empty" } } };
                }
                else
                {
                    var room = dBContext.Bookings.Where(x => x.BookingId == id && x.IsDelete == false).FirstOrDefault();
                    if (room != null)
                    {
                        return new Dictionary<string, object>() { { "result", room } };
                    }
                    else
                    {
                        return new Dictionary<string, object>() { { "Error", new { msg = "Booking id is not exist" } } };
                    }
                }
            }
            catch (Exception ex)
            {
                return new Dictionary<string, object>() { { "Error", new { msg = ex.Message } } };
            }
        }
        public async Task<Dictionary<string, object>> CreateOrUpdateBooking(BookingDto input)
        {
            try
            {
                if (input.BookingId == null)
                {
                    var id = "";
                    do
                    {
                        id = hotelManagementService.AutoGeneId("BK");
                    } while (dBContext.Bookings.Where(x => x.BookingId == id && x.IsDelete == false).FirstOrDefault() != null);
                    var booking = new Booking()
                    {
                        BookingId = id,
                        BookingDate = DateTime.Now,
                        CheckIn = input.CheckIn,
                        CheckOut = input.CheckOut,
                        CustomerId = input.CustomerId,
                        RoomId = input.RoomId,
                        IsDelete = false,
                        Customer = dBContext.Customers.Where(x => x.CustomerId == input.CustomerId && x.IsDelete == false).FirstOrDefault(),
                        Room = dBContext.Rooms.Where(x => x.RoomId == input.RoomId && x.IsDelete == false).FirstOrDefault(),
                    };
                    dBContext.Bookings.Add(booking);
                    dBContext.SaveChanges();
                    return new Dictionary<string, object>() { { "Success", new { msg = "Create booking success" } } };
                }
                else
                {
                    var booking = dBContext.Bookings.Where(x => x.RoomId == input.BookingId && x.IsDelete == false).FirstOrDefault();
                    if (booking == null)
                    {
                        return new Dictionary<string, object>() { { "Error", new { msg = "Booking is not exist" } } };
                    }
                    else
                    {
                        booking.CheckIn = input.CheckIn;
                        booking.CheckOut = input.CheckOut;
                        booking.CustomerId = input.CustomerId;
                        booking.RoomId = input.RoomId;
                        booking.Customer = dBContext.Customers.Where(x => x.CustomerId == input.CustomerId && x.IsDelete == false).FirstOrDefault();
                        booking.Room = dBContext.Rooms.Where(x => x.RoomId == input.RoomId && x.IsDelete == false).FirstOrDefault();
                        dBContext.Bookings.Update(booking);
                        dBContext.SaveChanges();
                        return new Dictionary<string, object>() { { "Success", new { msg = "Update booking success" } } };
                    }
                }
            }
            catch (Exception ex)
            {
                return new Dictionary<string, object>() { { "Error", new { msg = ex.Message } } };
            }
        }
        public async Task<Dictionary<string, object>> DeleteBooking([Required] string id)
        {
            try
            {
                if (id == null)
                {
                    return new Dictionary<string, object>() { { "Error", new { msg = "Booking id is empty" } } };
                }
                else
                {
                    var booking = dBContext.Bookings.Where(x => x.BookingId == id && x.IsDelete == false).FirstOrDefault();
                    if (booking == null)
                    {
                        return new Dictionary<string, object>() { { "Error", new { msg = "Booking is not exist" } } };
                    }
                    else
                    {
                        booking.IsDelete = true;
                        dBContext.Bookings.Update(booking);
                        dBContext.SaveChanges();
                        return new Dictionary<string, object>() { { "Success", new { msg = "Delete booking success" } } };
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
