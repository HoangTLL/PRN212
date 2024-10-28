using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class LocationDAO
    {
        private readonly PRN212Context _context;

        public LocationDAO()
        {
            _context = new PRN212Context();
        }

        // Get all locations
        public List<Location> GetLocations()
        {
            return _context.Locations.ToList();
        }

        // Find location by ID
        public Location? FindLocationById(int id)
        {
            return _context.Locations.Find(id);
        }

        // Add a new location
        public void AddLocation(Location location)
        {
            _context.Locations.Add(location);
            _context.SaveChanges();
        }

        // Update an existing location
        public bool UpdateLocation(Location location)
        {
            try
            {
                _context.Entry(location).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Delete a location (soft delete, set status to 0)
        public bool DeleteLocation(int id)
        {
            var location = _context.Locations.Find(id);
            if (location != null)
            {
                location.Status = 0; // Set status to 0 instead of removing
                _context.Entry(location).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
