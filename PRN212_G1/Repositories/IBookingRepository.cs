using BusinessObjects.Models;

namespace Repositories
{
    public interface IBookingRepository
    {
        List<Booking> GetBookings();
        Booking? GetBookingById(int id);
        void SaveBooking(Booking booking);
        bool UpdateBooking(Booking booking);
        bool DeleteBooking(int id);
    }
}
