using BusinessObjects.Models;
using System.Collections.Generic;

namespace Services
{
    public interface ITripService
    {
        List<Trip> GetAllTripsWithLocations();
        Trip? GetTripById(int id);
        void SaveTrip(Trip trip);
        bool UpdateTrip(Trip trip);
        bool DeleteTrip(int id);
        List<Trip> FindAvailableTrips(int pickUpLocationId, int dropOffLocationId);
    }
}
