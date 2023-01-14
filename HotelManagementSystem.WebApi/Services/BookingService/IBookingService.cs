using HotelManagementSystem.WebApi.Models.BookingModel;

namespace HotelManagementSystem.WebApi.Services.BookingService
{
    public interface IBookingService
    {
        Task<Dictionary<string, object>> GetBookings();
        Task<Dictionary<string, object>> GetBookingById(string id);
        Task<Dictionary<string, object>> CreateOrUpdateBooking(BookingDto input);
        Task<Dictionary<string, object>> DeleteBooking(string id);
    }
}
