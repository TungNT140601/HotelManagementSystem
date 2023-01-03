using HotelManagementSystem.WebApi.Models.Customer;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.WebApi.DatabaseContext
{
    public class HotelManagementDBContext : DbContext
    {
        public HotelManagementDBContext(DbContextOptions<HotelManagementDBContext> ops): base(ops) { }
        public DbSet<Customer> Customers { get; set; } = default!;
    }
}
