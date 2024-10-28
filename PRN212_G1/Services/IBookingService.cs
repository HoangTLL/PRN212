using BusinessObjects.Models;
using System.Collections.Generic;

namespace Services
{
    public interface IBookingService
    {
        List<Booking> GetBookings();
        Booking? GetBookingById(int id);
        void SaveBooking(Booking booking);
        bool UpdateBooking(Booking booking);
        bool DeleteBooking(int id);
    }
}
