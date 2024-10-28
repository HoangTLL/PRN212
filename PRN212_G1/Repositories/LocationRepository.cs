using BusinessObjects.Models;
using DataAccessLayer;

namespace Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly LocationDAO _locationDAO;

        public LocationRepository()
        {
            _locationDAO = new LocationDAO();
        }

        public List<Location> GetLocations() => _locationDAO.GetLocations();

        public Location? GetLocationById(int id) => _locationDAO.FindLocationById(id);

        public void SaveLocation(Location location) => _locationDAO.AddLocation(location);

        public bool UpdateLocation(Location location) => _locationDAO.UpdateLocation(location);

        public bool DeleteLocation(int id) => _locationDAO.DeleteLocation(id);
    }
}
