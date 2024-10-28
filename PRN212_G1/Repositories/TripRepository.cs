using BusinessObjects.Models;
using DataAccessLayer;

namespace Repositories
{
    public class TripRepository : ITripRepository
    {
        private readonly TripDAO _tripDAO;

        public TripRepository()
        {
            _tripDAO = new TripDAO();
        }

        public List<Trip> GetAllTripsWithLocations() => _tripDAO.GetAllTripsWithLocations();

        public Trip? GetTripById(int id) => _tripDAO.FindTripById(id);

        public void SaveTrip(Trip trip) => _tripDAO.AddTrip(trip);

        public bool UpdateTrip(Trip trip) => _tripDAO.UpdateTrip(trip); // Return the result from DAO

        public bool DeleteTrip(int id) => _tripDAO.DeleteTrip(id); // Return the result from DAO
    }
}
