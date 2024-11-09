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
        public User EditedUser { get; set; } = null;
        private readonly IUserService iUserService;
        private UserService _service = new();
        public User User { get; set; }
        public UserDialog()
        {
            InitializeComponent();
            iUserService = new UserService();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            User _user = new();
            _user.Id = int.Parse(UserIdTextBox.Text);
            _user.Name = NameTextBox.Text;
            _user.Email = EmailTextBox.Text;
            _user.PhoneNumber = PhoneNumberTextBox.Text;
            _user.Password = PasswordTextBox.Text;
            if (DateOfBirthDatePicker.SelectedDate.HasValue)
            {
                _user.DateOfBirth = DateOnly.FromDateTime(DateOfBirthDatePicker.SelectedDate.Value);
            }
            else
            {
                MessageBox.Show("Please select a Date of Birth.", "Missing Information", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (CreatedAtDatePicker.SelectedDate.HasValue)
            {
                _user.CreatedAt = CreatedAtDatePicker.SelectedDate.Value;
            }
            else
            {
                MessageBox.Show("Please select a Created At date.", "Missing Information", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            _user.Role = RoleComboBox.SelectedValue.ToString();
            _user.Status = (StatusComboBox.SelectedItem as ComboBoxItem).Content.ToString().StartsWith("1") ? 1 : 2;
            if (EditedUser == null)
            {
                iUserService.SaveCustomer(_user);
            }
            else
            {
                _service.UpdateCustomer(_user);
            }
            this.Close();

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void FillElements(User x)
        {
            if (x == null)
            {
                return;
            }
            else
            {
                UserIdTextBox.Text = x.Id.ToString();
                NameTextBox.Text = x.Name;
                EmailTextBox.Text = x.Email;
                PhoneNumberTextBox.Text = x.PhoneNumber.ToString();
                PasswordTextBox.Text = x.Password.ToString();
                DateOfBirthDatePicker.SelectedDate = x.DateOfBirth.HasValue ? x.DateOfBirth.Value.ToDateTime(new TimeOnly(0, 0))
                : (DateTime?)null;

                CreatedAtDatePicker.SelectedDate = x.CreatedAt;
                RoleComboBox.SelectedValue = x.Role;
                StatusComboBox.SelectedValue = x.Status;
            }
        }
    }
}
