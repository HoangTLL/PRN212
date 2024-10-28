using BusinessObjects.Models;
using Repositories;
using System.Collections.Generic;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _customerRepository;

        public UserService()
        {
            _customerRepository = new UserRepository();
        }

        public List<User> GetCustomers() => _customerRepository.GetUsers();

        public User? GetCustomerById(int id) => _customerRepository.GetUserById(id);

        public User GetCustomerByEmail(string email) => _customerRepository.FindUserByEmail(email);

        public void SaveCustomer(User customer) => _customerRepository.SaveUser(customer);

        public bool UpdateCustomer(User customer) => _customerRepository.UpdateUser(customer);

        public bool DeleteCustomer(int id) => _customerRepository.DeleteUser(id);
    }
}
