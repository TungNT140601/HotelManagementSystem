using HotelManagementSystem.WebApi.DatabaseContext;
using HotelManagementSystem.WebApi.Models.CustomerModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementSystem.WebApi.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly HotelManagementDBContext dBContext;
        private readonly IHotelManagementService hotelManagementService;
        public CustomerService(HotelManagementDBContext hotelManagement, IHotelManagementService hotel)
        {
            dBContext = hotelManagement;
            hotelManagementService = hotel;
        }
        public async Task<Dictionary<string, object>> LoginCheck(string username, string password)
        {
            try
            {
                var cus = dBContext.Customers.Where(x => x.Username == username).FirstOrDefault();
                if (cus != null)
                {
                    if (cus.Password == password)
                    {
                        return new Dictionary<string, object>() { {"result", new CustomerDto
                        {
                            Address = cus.Address,
                            AddressProof = cus.AddressProof,
                            CustomerId = cus.CustomerId,
                            CustomerName = cus.CustomerName,
                            Gender = cus.Gender,
                            IdProof = cus.IdProof,
                            PhoneNo = cus.PhoneNo,
                            ProfileImage = cus.ProfileImage,
                        }
                    } };
                    }
                    else
                    {
                        return new Dictionary<string, object>() { { "Error", new { errMsg = "Password was wrong!!!" } } };
                    }
                }
                else
                {
                    return new Dictionary<string, object>() { { "Error", new { errMsg = "Username not exist!!!" } } };
                }
            }
            catch (Exception ex)
            {
                return new Dictionary<string, object>() { { "Error 500", new { errMsg = ex.Message } } };
            }
        }
        public async Task<Dictionary<string, object>> GetCustomerById(string? id)
        {
            try
            {
                if (id == null)
                {
                    return new Dictionary<string, object>() { { "Error", new { errMsg = "Must constain id!!!" } } };
                }
                else
                {
                    var cus = dBContext.Customers.Where(x => x.CustomerId == id && x.IsDelete == false).FirstOrDefault();
                    if (cus != null)
                    {
                        return new Dictionary<string, object>() { {"result", new CustomerDto
                            {
                                Address = cus.Address,
                                AddressProof = cus.AddressProof,
                                CustomerId = cus.CustomerId,
                                CustomerName = cus.CustomerName,
                                Gender = cus.Gender,
                                IdProof = cus.IdProof,
                                PhoneNo = cus.PhoneNo,
                                ProfileImage = cus.ProfileImage,
                            }
                        }
                    };
                    }
                    else
                    {
                        return new Dictionary<string, object>() { { "Error", new { errMsg = "CustomerId dose not exist!!!" } } };
                    }
                }
            }
            catch (Exception ex)
            {
                return new Dictionary<string, object>() { { "Error", new { errMsg = ex.Message } } };
            }
        }
        public async Task<Dictionary<string, object>> GetCustomers()
        {
            try
            {
                var cuss = dBContext.Customers.Where(x => x.IsDelete == false).ToList();
                var lst = new List<CustomerDto>();
                foreach (var cus in cuss)
                {
                    var cus1 = new CustomerDto()
                    {
                        Address = cus.Address,
                        AddressProof = cus.AddressProof,
                        CustomerId = cus.CustomerId,
                        CustomerName = cus.CustomerName,
                        Gender = cus.Gender,
                        IdProof = cus.IdProof,
                        PhoneNo = cus.PhoneNo,
                        ProfileImage = cus.ProfileImage,
                    };
                    lst.Add(cus1);
                }
                return new Dictionary<string, object>() { { "result", lst } };
            }
            catch (Exception ex)
            {
                return new Dictionary<string, object>() { { "Error", new { errMsg = ex.Message } } };
            }
        }
        public async Task<Dictionary<string, object>> CreateOrUpdateCustomer(CustomerInput input)
        {
            try
            {
                if (input.CustomerId == null)
                {
                    if (CheckUserName(input.Username))
                    {
                        return new Dictionary<string, object>() { { "Error", new { errMsg = "This username has been used." } } };
                    }
                    string id = "";
                    do
                    {
                        id = hotelManagementService.AutoGeneId("CUS");
                    } while (dBContext.Customers.Where(x => x.CustomerId == id).FirstOrDefault() != null);
                    var cus = new Customer()
                    {
                        Password = input.Password,
                        Username = input.Username,
                        Address = input.Address,
                        AddressProof = input.AddressProof,
                        CustomerName = input.CustomerName,
                        Gender = input.Gender,
                        IdProof = input.IdProof,
                        IsDelete = false,
                        PhoneNo = input.PhoneNo,
                        ProfileImage = input.ProfileImage,
                        CustomerId = id
                    };
                    dBContext.Customers.Add(cus);
                    dBContext.SaveChanges();
                    return new Dictionary<string, object>() { { "Success", new { errMsg = "Create success" } } };
                }
                else
                {
                    var cus = dBContext.Customers.Where(x => x.CustomerId == input.CustomerId && x.IsDelete == false).FirstOrDefault();
                    if (cus == null)
                    {
                        return new Dictionary<string, object>() { { "Error", new { errMsg = "Update info error!!!" } } };
                    }
                    else
                    {
                        cus.AddressProof = input.AddressProof;
                        cus.PhoneNo = input.PhoneNo;
                        cus.ProfileImage = input.ProfileImage;
                        cus.Address = input.Address;
                        cus.IdProof = input.IdProof;
                        cus.CustomerName = input.CustomerName;
                        cus.Gender = input.Gender;
                        dBContext.Customers.Update(cus);
                        dBContext.SaveChanges();
                        return new Dictionary<string, object>() { { "Success", new { errMsg = "Update success" } } };
                    }
                }
            }
            catch (Exception ex)
            {
                return new Dictionary<string, object>() { { "Error", new { errMsg = ex.Message } } };
            }
        }
        private bool CheckUserName(string userName)
        {
            var cus = dBContext.Customers.Where(x => x.Username == userName && x.IsDelete == false).ToList();
            if (cus.Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<Dictionary<string, object>> DeleteCustomer(string? customerId)
        {
            try
            {
                if(customerId == null)
                {
                    return new Dictionary<string, object>() { { "Error", new { errMsg = "CustomerId cannot empty" } } };
                }
                else
                {
                    var cus = dBContext.Customers.Where(x=>x.CustomerId== customerId && x.IsDelete == false).FirstOrDefault();
                    if(cus != null)
                    {
                        cus.IsDelete = true;
                        dBContext.Customers.Update(cus);
                        dBContext.SaveChanges();
                        return new Dictionary<string, object>() { { "Success", new { msg = "Delete customer id: "+customerId+" success." } } };
                    }
                    else
                    {
                        return new Dictionary<string, object>() { { "Error", new { errMsg = "CustomerId dose not exist" } } };
                    }
                }
            }
            catch (Exception ex)
            {
                return new Dictionary<string, object>() { { "Error", new { errMsg = ex.Message } } };
            }
        }
    }
}
