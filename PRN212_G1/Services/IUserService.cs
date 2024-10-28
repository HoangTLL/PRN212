using BusinessObjects.Models;
using System.Collections.Generic;


namespace Services
{
    public interface IUserService
    {
        List<User> GetCustomers();
        User? GetCustomerById(int id);
        User GetCustomerByEmail(string email);
        void SaveCustomer(User customer);
        bool UpdateCustomer(User customer);
        bool DeleteCustomer(int id);
    }
}
