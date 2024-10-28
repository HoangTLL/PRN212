using BusinessObjects.Models;
using System.Collections.Generic;

namespace Repositories
{
    public interface ITripRepository
    {
        List<Trip> GetAllTripsWithLocations();
        Trip? GetTripById(int id);
        void SaveTrip(Trip trip);
        bool UpdateTrip(Trip trip); // Return type changed to bool
        bool DeleteTrip(int id); // Return type changed to bool
    }
}
