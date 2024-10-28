using BusinessObjects.Models;
using DataAccessLayer;

namespace Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly BookingDAO _bookingDAO;

        public BookingRepository()
        {
            _bookingDAO = new BookingDAO();
        }

        public List<Booking> GetBookings() => _bookingDAO.GetBookings();

        public Booking? GetBookingById(int id) => _bookingDAO.FindBookingById(id);

        public void SaveBooking(Booking booking) => _bookingDAO.AddBooking(booking);

        public bool UpdateBooking(Booking booking) => _bookingDAO.UpdateBooking(booking);

        public bool DeleteBooking(int id) => _bookingDAO.DeleteBooking(id);
    }
}
