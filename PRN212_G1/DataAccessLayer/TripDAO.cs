using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class TripDAO
    {
        private readonly PRN212Context _context;

        public TripDAO()
        {
            _context = new PRN212Context();
        }

        // Retrieve all trips with location names
        public List<Trip> GetAllTripsWithLocations()
        {
            return _context.Trips
                .Include(t => t.PickUpLocation) // Include pickup location details
                .Include(t => t.DropOffLocation) // Include drop-off location details
                .ToList();
        }

        // Find a trip by ID with location names
        public Trip? FindTripById(int id)
        {
            return _context.Trips
                .Include(t => t.PickUpLocation)
                .Include(t => t.DropOffLocation)
                .FirstOrDefault(t => t.Id == id);
        }

        // Add a new trip
        public void AddTrip(Trip trip)
        {
            _context.Trips.Add(trip);
            _context.SaveChanges();
        }

        // Update an existing trip
        public bool UpdateTrip(Trip trip)
        {
            try
            {
                _context.Entry(trip).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch (DbUpdateException ex)
            {
                // Log the error (ex) here if necessary
                return false;
            }
        }

        // Delete a trip by ID
        public bool DeleteTrip(int id)
        {
            var trip = FindTripById(id);
            if (trip != null)
            {
                _context.Trips.Remove(trip);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
