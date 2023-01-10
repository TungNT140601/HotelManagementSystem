using HotelManagementSystem.WebApi.Models.BookingModel;
using HotelManagementSystem.WebApi.Models.CustomerModel;
using HotelManagementSystem.WebApi.Models.RoomModel;
using HotelManagementSystem.WebApi.Models.RoomTypeModel;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.WebApi.DatabaseContext
{
    public class HotelManagementDBContext : DbContext
    {
        public HotelManagementDBContext(DbContextOptions<HotelManagementDBContext> ops): base(ops) { }
        public DbSet<Customer> Customers { get; set; } = default!;
        public DbSet<RoomType> RoomTypes { get; set; } = default!;
        public DbSet<Room> Rooms { get; set; } = default!;
        public DbSet<Booking> Bookings { get; set; } = default!;
    }
}
