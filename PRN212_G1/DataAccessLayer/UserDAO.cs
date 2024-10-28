using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class UserDAO
    {
        private readonly PRN212Context _context;

        public UserDAO()
        {
            _context = new PRN212Context();
        }

        // Retrieve all users
        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        // Find a user by ID
        public User? FindUserById(int id)
        {
            return _context.Users.Find(id);
        }

        // Find a user by email
        public User? FindUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }

        // Add a new user
        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        // Update an existing user
        public bool UpdateUser(User user)
        {
            try
            {
                _context.Entry(user).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch (DbUpdateException ex)
            {
                // Log the error (ex) here if necessary
                return false;
            }
        }

        // Delete a user by ID
        public bool DeleteUser(int id)
        {
            var user = FindUserById(id);
            if (user != null)
            {
                // Check if the user has associated bookings
                var hasBookings = _context.Bookings.Any(b => b.UserId == id);
                if (hasBookings)
                {
                    // Set user status to 0 instead of deleting
                    user.Status = 0; // Set status to inactive
                    _context.Entry(user).State = EntityState.Modified; 
                    _context.SaveChanges(); 
                    return true;
                }
                else
                {
                    // Proceed to remove the user if no bookings are associated
                    _context.Users.Remove(user);
                    _context.SaveChanges();
                    return true;
                }
            }
            return false;
        }
    }
}
