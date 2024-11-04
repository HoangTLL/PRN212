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
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private readonly ITripService tripService;
        private ObservableCollection<Trip> trips;
        private Trip selectedTrip;
        private string tripSearchText;

        public event PropertyChangedEventHandler PropertyChanged;

        public AdminWindow()
        {
            InitializeComponent();
            tripService = new TripService();
            LoadTrip();
            DataContext = this;
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
            if (SelectedTrip == null) return ;
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
    }
}
