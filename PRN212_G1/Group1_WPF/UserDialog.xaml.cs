using BusinessObjects.Models;
using Repositories;
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
    /// Interaction logic for UserDialog.xaml
    /// </summary>
    public partial class UserDialog : Window
    {

        private readonly UserService _userService;
        public User User { get; set; }

        public DateTime? DateOfBirthDateTime
        {
            get => User.DateOfBirth.HasValue ? User.DateOfBirth.Value.ToDateTime(TimeOnly.MinValue) : (DateTime?)null;
            set => User.DateOfBirth = value.HasValue ? DateOnly.FromDateTime(value.Value) : (DateOnly?)null;
        }

        public UserDialog(User user = null)
        {
            InitializeComponent();
            _userService = new UserService();
            User = user ?? new User();
            DataContext = User; 
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (User.Id == 0)
            {
                _userService.SaveCustomer(User); 
            }
            else
            {
                _userService.UpdateCustomer(User);
            }
            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false; 
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Pre-fill elements if editing an existing user
            UserIdTextBox.Text = User.Id.ToString();
            NameTextBox.Text = User.Name;
            EmailTextBox.Text = User.Email;
            PhoneNumberTextBox.Text = User.PhoneNumber;
            PasswordTextBox.Text = User.Password;
            DateOfBirthDatePicker.SelectedDate = User.DateOfBirth?.ToDateTime(new TimeOnly(0, 0));
            CreatedAtDatePicker.SelectedDate = User.CreatedAt;
            RoleComboBox.SelectedItem = User.Role;
            StatusComboBox.SelectedItem = User.Status?.ToString();
        }
    }
}
