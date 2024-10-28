using BusinessObjects.Models;
using DataAccessLayer;

namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDAO _userDAO;

        public UserRepository()
        {
            _userDAO = new UserDAO();
        }

        public List<User> GetUsers() => _userDAO.GetUsers();

        public User? GetUserById(int id) => _userDAO.FindUserById(id);

        public User? FindUserByEmail(string email) => _userDAO.FindUserByEmail(email);

        public void SaveUser(User user) => _userDAO.AddUser(user);

        public bool UpdateUser(User user) => _userDAO.UpdateUser(user);

        public bool DeleteUser(int id) => _userDAO.DeleteUser(id);
    }
}
