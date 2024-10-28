using BusinessObjects.Models;
using Repositories;
using System.Collections.Generic;

namespace Services
{
    public class TripService : ITripService
    {
        private readonly ITripRepository _tripRepository;

        public TripService()
        {
            _tripRepository = new TripRepository();
        }

        public List<Trip> GetAllTripsWithLocations() => _tripRepository.GetAllTripsWithLocations();

        public Trip? GetTripById(int id) => _tripRepository.GetTripById(id);

        public void SaveTrip(Trip trip) => _tripRepository.SaveTrip(trip);

        public bool UpdateTrip(Trip trip) => _tripRepository.UpdateTrip(trip);

        public bool DeleteTrip(int id) => _tripRepository.DeleteTrip(id);
    }
}
