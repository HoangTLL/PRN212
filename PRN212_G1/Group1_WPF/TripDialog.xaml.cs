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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MessageBox = System.Windows.MessageBox;

namespace Group1_WPF
{
    /// <summary>
    /// Interaction logic for TripDialog.xaml
    /// </summary>
    public partial class TripDialog : Window
    {
        public Trip Trip { get; set; }
        private readonly ILocationService locationService;
        public TripDialog(Trip trip)
        {
            InitializeComponent();
            Trip = trip ?? new Trip();
            locationService = new LocationService();
            LoadTripLocation();
            LoadTripLocation1();
            MaxPersonTextBox.Text = Trip.MaxPerson.ToString();
            MinPersonTextBox.Text= Trip.MinPerson.ToString();
            BookingDatePicker.SelectedDate = Trip.BookingDate.ToDateTime(new TimeOnly());
            HourInDayTextBox.Text = Trip.HourInDay.ToString();
            StatusComboBox.SelectedItem = Trip.Status == 1 ? StatusComboBox.Items[0] : StatusComboBox.Items[1];

            foreach (ComboBoxItem item in TripLocationComboBox.Items)
            {
                if ((int)item.Tag == Trip.PickUpLocationId)
                {
                    TripLocationComboBox.SelectedItem = item;
                    break;
                }
            }

            foreach (ComboBoxItem item in TripLocationComboBox1.Items)
            {
                if ((int)item.Tag == Trip.DropOffLocationId)
                {
                    TripLocationComboBox1.SelectedItem = item;
                    break;
                }
            }

        }

        private void LoadTripLocation()
        {
            var tripLocation = locationService.GetLocations();
            foreach (var location in tripLocation) 
            { 
                TripLocationComboBox.Items.Add(new ComboBoxItem { Content = location.Name, Tag = location.Id });
            }
        }

        private void LoadTripLocation1()
        {
            var tripLocation1 = locationService.GetLocations();
            foreach (var location in tripLocation1)
            {
                TripLocationComboBox1.Items.Add(new ComboBoxItem { Content = location.Name, Tag = location.Id });
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (!TimeOnly.TryParse(HourInDayTextBox.Text, out TimeOnly hourInDay) ||
                !int.TryParse(MaxPersonTextBox.Text, out int maxCapacity) ||
                !int.TryParse(MinPersonTextBox.Text, out int minCapacity) ||
                TripLocationComboBox.SelectedItem == null ||
                TripLocationComboBox1.SelectedItem == null || !BookingDatePicker.SelectedDate.HasValue)
            {
                MessageBox.Show("All fields must be filled correctly.");
                return;
            }
            Trip.PickUpLocationId = (int)((ComboBoxItem)TripLocationComboBox.SelectedItem).Tag;
            Trip.DropOffLocationId = (int)((ComboBoxItem)TripLocationComboBox1.SelectedItem).Tag;
            Trip.MaxPerson = maxCapacity;
            Trip.MinPerson = minCapacity;
            Trip.BookingDate = BookingDatePicker.SelectedDate.HasValue ? DateOnly.FromDateTime(BookingDatePicker.SelectedDate.Value) : DateOnly.MinValue;
            Trip.HourInDay = hourInDay;
            Trip.Status = (StatusComboBox.SelectedItem as ComboBoxItem).Content.ToString().StartsWith("1") ? 1 : 2;
            Console.WriteLine("Saved");

            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
