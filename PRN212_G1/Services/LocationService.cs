using BusinessObjects.Models;
using Repositories;
using System.Collections.Generic;

namespace Services
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;

        public LocationService()
        {
            _locationRepository = new LocationRepository();
        }

        public List<Location> GetLocations() => _locationRepository.GetLocations();

        public Location? GetLocationById(int id) => _locationRepository.GetLocationById(id);

        public void SaveLocation(Location location) => _locationRepository.SaveLocation(location);

        public bool UpdateLocation(Location location) => _locationRepository.UpdateLocation(location);

        public bool DeleteLocation(int id) => _locationRepository.DeleteLocation(id);
    }
}
