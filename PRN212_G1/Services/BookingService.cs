using BusinessObjects.Models;
using Repositories;
using System.Collections.Generic;

namespace Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService()
        {
            _bookingRepository = new BookingRepository();
        }

        public List<Booking> GetBookings() => _bookingRepository.GetBookings();
        public Booking? GetBookingById(int id) => _bookingRepository.GetBookingById(id);

        public void SaveBooking(Booking booking) => _bookingRepository.SaveBooking(booking);

        public bool UpdateBooking(Booking booking) => _bookingRepository.UpdateBooking(booking);

        public bool DeleteBooking(int id) => _bookingRepository.DeleteBooking(id);
    }
}
