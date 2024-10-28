using BusinessObjects.Models;
using System.Collections.Generic;

namespace Services
{
    public interface ILocationService
    {
        List<Location> GetLocations();
        Location? GetLocationById(int id);
        void SaveLocation(Location location);
        bool UpdateLocation(Location location);
        bool DeleteLocation(int id);
    }
}
