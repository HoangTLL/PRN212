using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class BookingDAO
    {
        private readonly PRN212Context _context;

        public BookingDAO()
        {
            _context = new PRN212Context();
        }

        // Retrieve all bookings
        public List<Booking> GetBookings()
        {
            return _context.Bookings.Include(b => b.User).Include(b => b.Trip).ToList();
        }

        // Find a booking by ID
        public Booking? FindBookingById(int id)
        {
            return _context.Bookings
                .Include(b => b.User) // Include User details
                .Include(b => b.Trip) // Include Trip details
                .FirstOrDefault(b => b.Id == id);
        }

        // Add a new booking
        public void AddBooking(Booking booking)
        {
            _context.Bookings.Add(booking);
            _context.SaveChanges();
        }

        // Update an existing booking
        public bool UpdateBooking(Booking booking)
        {
            try
            {
                _context.Entry(booking).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch (DbUpdateException ex)
            {
                // Log the error (ex) here if necessary
                return false;
            }
        }

        // Delete a booking by ID
        public bool DeleteBooking(int id)
        {
            var booking = FindBookingById(id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                _context.SaveChanges();
                return true;
            }
            return false;
        }        
    }
}
