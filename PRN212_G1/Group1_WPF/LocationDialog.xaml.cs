using BusinessObjects.Models;
using Services;
using System.Windows;

namespace Group1_WPF
{
    public partial class LocationDialog : Window
    {
        private readonly LocationService _locationService;
        public Location Location { get; set; }

        public LocationDialog(Location location = null)
        {
            InitializeComponent();
            _locationService = new LocationService();

            // Initialize Location property for binding
            Location = location ?? new Location();
            DataContext = Location;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            // If Location is new, add it; otherwise, update it
            if (Location.Id == 0)
            {
                _locationService.SaveLocation(Location);
            }
            else
            {
                _locationService.UpdateLocation(Location);
            }
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Pre-fill elements if editing
            FillElements(Location);
        }

        private void FillElements(Location x)
        {
            if (x == null) return;
            NameTextBox.Text = x.Name;
            StatusComboBox.SelectedValue = x.Status;
        }
    }
}
