using BusinessObjects.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace Group1_WPF
{
    public partial class AdminWindow : Window, INotifyPropertyChanged
    {
        private UserService _UserService = new();
        private User selectedUser;
        private readonly ITripService tripService;
        private readonly ILocationService locationService;
        private ObservableCollection<User> users;
        private ObservableCollection<Trip> trips;
        private ObservableCollection<Location> locations;
        private Trip selectedTrip;
        private string tripSearchText;
        private string locationSearchText; // Add this for location search text
        private string userSearchText;

        public event PropertyChangedEventHandler PropertyChanged;

        public AdminWindow()
        {
            InitializeComponent();
            tripService = new TripService();
            locationService = new LocationService();
            LoadTrip();
            LoadLocation();
            DataContext = this;
        }
        private void LoadUsers()
        {
            users = new ObservableCollection<User>(_UserService.GetCustomers());
        }
        public ObservableCollection<User> Users
        {
            get => users;
            set
            {
                users = value;
                OnPropertyChanged(nameof(Users));
                OnPropertyChanged(nameof(FilteredUsers));
            }
        }
        public IEnumerable<User> FilteredUsers =>
            string.IsNullOrWhiteSpace(UserSearchText)
                ? Users
                : Users.Where(u =>
                    u.Name.Contains(UserSearchText, StringComparison.OrdinalIgnoreCase) ||
                    u.Email.Contains(UserSearchText, StringComparison.OrdinalIgnoreCase) ||
                    u.PhoneNumber.Contains(UserSearchText, StringComparison.OrdinalIgnoreCase));
        public string UserSearchText
        {
            get => userSearchText;
            set
            {
                userSearchText = value;
                OnPropertyChanged(nameof(UserSearchText));
                OnPropertyChanged(nameof(FilteredUsers));
            }
        }

        private void LoadTrip()
        {
            Trips = new ObservableCollection<Trip>(tripService.GetAllTripsWithLocations());
        }

        public ObservableCollection<Trip> Trips
        {
            get => trips;
            set
            {
                trips = value;
                OnPropertyChanged(nameof(Trips));
            }
        }

        public string TripSearchText
        {
            get => tripSearchText;
            set
            {
                tripSearchText = value;
                OnPropertyChanged(nameof(TripSearchText));
                OnPropertyChanged(nameof(FilteredTrips));
            }
        }

        private void LoadLocation()
        {
            var locationsList = locationService.GetLocations();
            Locations = new ObservableCollection<Location>(locationsList);

        }

        public ObservableCollection<Location> Locations
        {
            get => locations;
            set
            {
                locations = value;
                OnPropertyChanged(nameof(Locations));
                OnPropertyChanged(nameof(FilteredLocations)); // Notify that FilteredLocations may change
            }
        }

        public string LocationSearchText // Add property for location search text
        {
            get => locationSearchText;
            set
            {
                locationSearchText = value;
                OnPropertyChanged(nameof(LocationSearchText));
                OnPropertyChanged(nameof(FilteredLocations)); // Notify that FilteredLocations may change
            }
        }

        public IEnumerable<Location> FilteredLocations => // Add this property
            string.IsNullOrWhiteSpace(LocationSearchText)
                ? Locations
                : Locations.Where(l =>
                    l.Name.Contains(LocationSearchText, StringComparison.OrdinalIgnoreCase));

        public Trip SelectedTrip
        {
            get => selectedTrip;
            set
            {
                selectedTrip = value;
                OnPropertyChanged(nameof(SelectedTrip));
            }
        }

        public IEnumerable<Trip> FilteredTrips =>
            string.IsNullOrWhiteSpace(TripSearchText)
                ? Trips
                : Trips.Where(c =>
                    c.DropOffLocation.Name.Contains(TripSearchText, StringComparison.OrdinalIgnoreCase));

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void AddTripButton_Click(object sender, RoutedEventArgs e)
        {
            var newTrip = new Trip();
            var tripDialog = new TripDialog(newTrip);
            if (tripDialog.ShowDialog() == true)
            {
                tripService.SaveTrip(newTrip);
                RefreshTrips();
            }
        }

        private void EditTripButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedTrip == null) return;
            var tripDialog = new TripDialog(SelectedTrip);
            if (tripDialog.ShowDialog() == true)
            {
                tripService.UpdateTrip(SelectedTrip);
                RefreshTrips();
            }
        }

        private void DeleteTripButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedTrip == null) return;
            var result = MessageBox.Show($"Are you sure you want to delete TripID {SelectedTrip.Id} ?",
                "Delete Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                tripService.DeleteTrip(SelectedTrip.Id);
                RefreshTrips();
            }
        }

        private void RefreshTrips()
        {
            var updatedTrips = tripService.GetAllTripsWithLocations();
            Trips.Clear();
            foreach (var room in updatedTrips)
            {
                Trips.Add(room);
            }
            OnPropertyChanged(nameof(FilteredTrips));
        }

        private void AddLocationButton_Click(object sender, RoutedEventArgs e)
        {
            var locationDialog = new LocationDialog();
            locationDialog.ShowDialog();
            //FillLocationsDataGrid();
            LoadLocation();
        }

        private void EditLocationButton_Click(object sender, RoutedEventArgs e)
        {
            Location selected = LocationsDataGrid.SelectedItem as Location;
            if (selected == null)
            {
                MessageBox.Show("Please select a row before editing", "Select a row", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            var locationDialog = new LocationDialog(selected);
            locationDialog.ShowDialog();
            FillLocationsDataGrid();
        }

        private void DeleteLocationButton_Click(object sender, RoutedEventArgs e)
        {
            Location? selected = LocationsDataGrid.SelectedItem as Location;
            if (selected == null)
            {
                MessageBox.Show("Please select a row before deleting", "Select a row", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            MessageBoxResult answer = MessageBox.Show("Do you really want to delete?", "Confirm?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (answer == MessageBoxResult.No)
                return;
            locationService.DeleteLocation(selected.Id);
            FillLocationsDataGrid();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            FillLocationsDataGrid(); // Reload the data based on search criteria
        }

        private void FillLocationsDataGrid()
        {
            LocationsDataGrid.ItemsSource = locationService.GetLocations().ToList(); // Bind filtered locations to the DataGrid
        }

        private void DeleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedUser == null) return;
            var result = MessageBox.Show($"Are you sure you want to delete {SelectedUser.Id} ?",
                "Delete Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                _UserService.DeleteCustomer(SelectedUser.Id);
                FillDataGrid();
            }
        }

        public User SelectedUser
        {
            get => selectedUser;
            set
            {
                selectedUser = value;
                OnPropertyChanged(nameof(SelectedUser));
            }
        }

        private void EditUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedUser == null)
            {
                MessageBox.Show("Please select a user to edit.", "Edit User", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var userDialog = new UserDialog(SelectedUser);
            if (userDialog.ShowDialog() == true)
            {
                FillDataGrid();
            }
        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            // Open the UserDialog without passing an existing user, so a new user is created
            var userDialog = new UserDialog();
            if (userDialog.ShowDialog() == true) // If dialog result is true (Save clicked)
            {
                FillDataGrid(); // Refresh the data grid to show the new user
            }
        }

        private void FillDataGrid()
        {
            UserDataGrid.ItemsSource = null;
            UserDataGrid.ItemsSource = _UserService.GetCustomers();
        }

        private void TabItem_Loaded(object sender, RoutedEventArgs e)
        {
            FillDataGrid();
        }
    }
}
