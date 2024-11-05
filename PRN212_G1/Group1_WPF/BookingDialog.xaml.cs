using BusinessObjects.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Group1_WPF
{
    /// <summary>
    /// Interaction logic for BookingDialog.xaml
    /// </summary>
    public partial class BookingDialog : Window
    {
        private Booking _booking;
        private List<Location> _locations;
        private readonly ITripService _tripService;
        private readonly IBookingService _bookingService;
        public BookingDialog(Booking booking, List<Location> locations)
        {
            InitializeComponent();
            _tripService = new TripService();
            _bookingService = new BookingService();
            _booking = booking;
            _locations = locations;

            // Populate ComboBoxes with location names
            PickUpLocationComboBox.ItemsSource = _locations;
            PickUpLocationComboBox.DisplayMemberPath = "Name";
            PickUpLocationComboBox.SelectedValuePath = "Id";

            DropOffLocationComboBox.ItemsSource = _locations;
            DropOffLocationComboBox.DisplayMemberPath = "Name";
            DropOffLocationComboBox.SelectedValuePath = "Id";

            // Initialize existing trip data, if any
            if (_booking.Trip != null)
            {
                PickUpLocationComboBox.SelectedValue = _booking.Trip.PickUpLocationId;
                DropOffLocationComboBox.SelectedValue = _booking.Trip.DropOffLocationId;
            }
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            // Validate inputs
            if (!ValidateLocations())
            {
                return;
            }

            // Assign details to the booking’s trip
            if (_booking.Trip == null)
            {
                _booking.Trip = new Trip();
            }
            _booking.Trip.PickUpLocationId = (int)PickUpLocationComboBox.SelectedValue;
            _booking.Trip.DropOffLocationId = (int)DropOffLocationComboBox.SelectedValue;

            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void FindButton_Click(object sender, RoutedEventArgs e)
        {

            // Validate inputs
            if (!ValidateLocations())
            {
                return;
            }

            // Retrieve trips from TripService
            var availableTrips = _tripService.FindAvailableTrips(
                (int)PickUpLocationComboBox.SelectedValue,
                (int)DropOffLocationComboBox.SelectedValue
            );

            // Display results
            if (availableTrips != null && availableTrips.Any())
            {
                TripResultsListBox.ItemsSource = availableTrips;
                TripResultsListBox.DisplayMemberPath = "TripInfo"; // Assuming TripInfo is a property that summarizes the trip details
            }
            else
            {
                MessageBox.Show("No available trips found for the selected locations.");
                TripResultsListBox.ItemsSource = null; // Clear previous results
            }
        }

        private bool ValidateLocations()
        {
            if (PickUpLocationComboBox.SelectedValue == null || DropOffLocationComboBox.SelectedValue == null)
            {
                MessageBox.Show("Please select both pick-up and drop-off locations.");
                return false;
            }
            return true;
        }

        private void BookButton_Click(object sender, RoutedEventArgs e)
        {
            // Check if a trip is selected
            if (TripResultsListBox.SelectedItem is Trip selectedTrip)
            {
                // Attempt to parse the UserId from the TextBox
                if (int.TryParse(UserId.Text, out int userId))
                {
                    // Check if we are creating a new booking or editing an existing one
                    if (_booking.Id == 0) // Assuming Id is 0 for a new booking
                    {
                        // Create a new booking
                        _booking.UserId = userId; // Use the parsed userId
                        _booking.TripId = selectedTrip.Id; // Use the selected trip's ID
                        _booking.Status = 1; // Set the status as needed (e.g., 1 for booked)

                        // Save the booking using your booking service/repository
                        _bookingService.SaveBooking(_booking);
                    }
                    else
                    {
                        // If editing an existing booking, just update its properties
                        _booking.UserId = userId; // Update the user ID
                        _booking.TripId = selectedTrip.Id; // Update the trip ID
                                                           // Optionally update status or other fields as needed
                                                           // Save the updated booking
                        _bookingService.UpdateBooking(_booking);
                    }

                    MessageBox.Show("Booking created/updated successfully!");
                    this.DialogResult = true; // Assuming this is in the BookingDialog context
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Please enter a valid User ID.");
                }
            }
            else
            {
                MessageBox.Show("Please select a trip to book.");
            }
        }
    }
}
