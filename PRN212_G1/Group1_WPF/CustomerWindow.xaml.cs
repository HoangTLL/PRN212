using BusinessObjects.Models;
using Services;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Group1_WPF
{
    public partial class CustomerWindow : Window
    {
        private readonly IUserService _userService;
        private readonly ITripService _tripService;
        private readonly IBookingService _bookingService;
        private User _currentUser;
        private Booking selectedBooking;

        public event PropertyChangedEventHandler PropertyChanged;

        public CustomerWindow(User user)
        {
            InitializeComponent();
            _userService = new UserService();
            _tripService = new TripService();
            _bookingService = new BookingService();
            _currentUser = user;
            LoadUserData();
            LoadTrips();
            LoadMyBookings();
            DataContext = this;
        }

        private void LoadUserData()
        {
            NameTextBox.Text = _currentUser.Name;
            EmailTextBox.Text = _currentUser.Email;
            PhoneTextBox.Text = _currentUser.PhoneNumber;
            if (_currentUser.DateOfBirth.HasValue)
            {
                DobPicker.SelectedDate = new DateTime(
                    _currentUser.DateOfBirth.Value.Year,
                    _currentUser.DateOfBirth.Value.Month,
                    _currentUser.DateOfBirth.Value.Day);
            }
            PasswordBox.Password = _currentUser.Password;
        }

        private void LoadTrips()
        {
            try
            {
                var trips = _tripService.GetAllTripsWithLocations()
                    .Where(t => t.Status == 1)
                    .OrderBy(t => t.BookingDate)
                    .ThenBy(t => t.HourInDay)
                    .ToList();

                TripsDataGrid.ItemsSource = trips;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading trips: {ex.Message}", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoadMyBookings()
        {
            try
            {
                var bookings = _bookingService.GetBookings()
                    .Where(b => b.UserId == _currentUser.Id)
                    .ToList();

                

                MyBookingsDataGrid.ItemsSource = bookings;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading bookings: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }





        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(NameTextBox.Text) ||
                    string.IsNullOrWhiteSpace(PhoneTextBox.Text) ||
                    string.IsNullOrWhiteSpace(PasswordBox.Password))
                {
                    MessageBox.Show("Please fill in all required fields.", "Validation Error",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                _currentUser.Name = NameTextBox.Text;
                _currentUser.PhoneNumber = PhoneTextBox.Text;
                _currentUser.Password = PasswordBox.Password;
                if (DobPicker.SelectedDate.HasValue)
                {
                    _currentUser.DateOfBirth = DateOnly.FromDateTime(DobPicker.SelectedDate.Value);
                }

                bool updated = _userService.UpdateCustomer(_currentUser);
                MessageBox.Show(updated ? "Profile updated successfully!" : "Failed to update profile.",
                    "Update Status", MessageBoxButton.OK,
                    updated ? MessageBoxImage.Information : MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BookTrip_Click(object sender, RoutedEventArgs e)
        {
            var trip = (Trip)((Button)sender).DataContext;

            try
            {
                var existingBooking = _bookingService.GetBookings()
                    .FirstOrDefault(b => b.UserId == _currentUser.Id && b.TripId == trip.Id && b.Status == 1);

                if (existingBooking != null)
                {
                    MessageBox.Show("You already have an active booking for this trip!",
                        "Booking Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var activeBookingsCount = _bookingService.GetBookings()
                    .Count(b => b.TripId == trip.Id && b.Status == 1);

                if (activeBookingsCount >= trip.MaxPerson)
                {
                    MessageBox.Show("This trip is already full!",
                        "Booking Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var newBooking = new Booking
                {
                    UserId = _currentUser.Id,
                    TripId = trip.Id,
                    Status = 1
                };

                _bookingService.SaveBooking(newBooking);
                MessageBox.Show("Trip booked successfully!", "Success",
                    MessageBoxButton.OK, MessageBoxImage.Information);

                LoadMyBookings();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error booking trip: {ex.Message}",
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelBooking_Click(object sender, RoutedEventArgs e)
        {
            var booking = (Booking)((Button)sender).DataContext;

            var result = MessageBox.Show(
                "Are you sure you want to cancel this booking?",
                "Confirm Cancellation",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    booking.Status = 0;
                    bool updated = _bookingService.UpdateBooking(booking);

                    if (updated)
                    {
                        MessageBox.Show("Booking cancelled successfully!",
                            "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        LoadMyBookings();
                    }
                    else
                    {
                        MessageBox.Show("Failed to cancel booking.",
                            "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error cancelling booking: {ex.Message}",
                        "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        public Booking SelectedBooking
        {
            get => selectedBooking;
            set
            {
                selectedBooking = value;
                OnPropertyChanged(nameof(SelectedBooking));
            }
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedBooking == null)
            {
                MessageBox.Show("Please select a booking to delete.");
                return;
            }

            // Confirm deletion
            var result = MessageBox.Show("Are you sure you want to delete this booking?", "Confirm Deletion", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                _bookingService.DeleteBooking(SelectedBooking.Id); // Assuming you have a method in the service to delete the booking
                LoadMyBookings(); // Refresh the booking list
            }
        }
    }
}
