using BusinessObjects.Models;

namespace Repositories
{
    public interface ILocationRepository
    {
        List<Location> GetLocations();
        Location? GetLocationById(int id);
        void SaveLocation(Location location);
        bool UpdateLocation(Location location);
        bool DeleteLocation(int id);
    }
}
