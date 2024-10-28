using BusinessObjects.Models;

namespace Repositories
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        User? GetUserById(int id);
        User? FindUserByEmail(string email);
        void SaveUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(int id);
    }
}
