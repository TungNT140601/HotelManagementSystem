using HotelManagementSystem.WebApi.Models.CustomerModel;

namespace HotelManagementSystem.WebApi.Services.CustomerService
{
    public interface ICustomerService
    {
        Task<Dictionary<string, object>> LoginCheck(string username, string password);
        Task<Dictionary<string, object>> GetCustomerById(string? id);
        Task<Dictionary<string, object>> GetCustomers();
        Task<Dictionary<string, object>> CreateOrUpdateCustomer(CustomerInput input);
        Task<Dictionary<string, object>> DeleteCustomer(string? customerId);
    }
}
