namespace HotelManagementSystem.WebApi.Services.CustomerService
{
    public interface ICustomerService
    {
        Task<Dictionary<string, object>> LoginCheck(string username, string password);
    }
}
