using BusinessObjects.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Interaction logic for BookingWindow.xaml
    /// </summary>
    public partial class BookingWindow : Window
    {
        private readonly IBookingService bookingService;
        private ObservableCollection<Booking> bookings;
      private readonly ILocationService locationService;
        private ObservableCollection<Booking> FilteredBookings;
        private Booking selectedBooking;
        private string bookingSearchText;

        public event PropertyChangedEventHandler PropertyChanged;
        public BookingWindow()
        {
            InitializeComponent();
            bookingService = new BookingService();
            locationService = new LocationService();
            loadBookings();
            DataContext = this;
        }
        private void loadBookings()
        {
            bookings = new ObservableCollection<Booking>(bookingService.GetBookings());
            dgBooking.ItemsSource = bookings;
        }
        public ObservableCollection<Booking> Bookings
        {
            get => bookings;
            set
            {
                bookings = value;
                OnPropertyChanged(nameof(Bookings));
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

        private void AddBooking_Click(object sender, RoutedEventArgs e)
        {
            var newBooking = new Booking();
            
            var locations = locationService.GetLocations();
            var bookingDialog = new BookingDialog(newBooking, locations);
            if (bookingDialog.ShowDialog() == true)
            {
                bookingService.SaveBooking(newBooking);
                loadBookings();
            }
        }

        private void FindBooking_Click(object sender, RoutedEventArgs e)
        {
            FilterBookings(); // Call the method to filter bookings based on the current search text\
            dgBooking.ItemsSource = FilteredBookings;

        }
        public string BookingSearchText // New property for search text
        {
            get => bookingSearchText;
            set
            {
                bookingSearchText = value;
                OnPropertyChanged(nameof(BookingSearchText));
                FilterBookings(); // Call filter whenever the search text changes
            }
        }
        private void FilterBookings()
        {
            if (string.IsNullOrWhiteSpace(BookingSearchText))
            {
                FilteredBookings = new ObservableCollection<Booking>(Bookings); // Show all if search text is empty
            }
            else
            {
                int userId;
                if (int.TryParse(BookingSearchText, out userId))
                {
                    // Filter the bookings based on UserId
                    var filtered = Bookings.Where(b => b.UserId == userId).ToList();
                    FilteredBookings = new ObservableCollection<Booking>(filtered);
                }
                else
                {
                    // If the input is not a valid integer, clear the filtered bookings
                    FilteredBookings = new ObservableCollection<Booking>();
                }
            }
        }

        //private void EditBooking_Click(object sender, RoutedEventArgs e)
        //{
        //    if (SelectedBooking == null)
        //    {
        //        MessageBox.Show("Please select a booking to edit.");
        //        return;
        //    }

        //    // Create a new instance of the booking dialog, passing the selected booking
        //    var bookingDialog = new BookingDialog(SelectedBooking, locationService.GetLocations());
        //    if (bookingDialog.ShowDialog() == true)
        //    {
        //        // Update the booking in the service and reload bookings
        //        bookingService.SaveBooking(SelectedBooking);
        //        loadBookings(); // Refresh the booking list
        //    }
        //}

        private void DeleteBooking_Click(object sender, RoutedEventArgs e)
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
                bookingService.DeleteBooking(SelectedBooking.Id); // Assuming you have a method in the service to delete the booking
                loadBookings(); // Refresh the booking list
            }

        }

    }
}
