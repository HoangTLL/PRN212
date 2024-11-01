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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly IUserService userService;
        public LoginWindow()
        {
            InitializeComponent();
            userService = new UserService();
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailTextBox.Text;
            string password = PasswordBox.Password;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Email or password cannot be empty.", "Validation Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var user = userService.GetCustomerByEmail(email);


            if (user.Password != password || user == null)
            {
                StatusTextBlock.Text = "Invalid email or password. Please try again.";
                return;
            }

            // Check if user is banned
            if (user.Status == 2)
            {
                MessageBox.Show("Your account has been banned.", "Access Denied",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Check user role and redirect accordingly
            if (user.Role.ToLower() == "admin")
            {
                //AdminWindow adminWindow = new AdminWindow();
                //adminWindow.Show();
                //this.Close();
            }
            else if (user.Role.ToLower() == "user")
            {
                MessageBox.Show($"Welcome, {user.Name}!", "Success",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                CustomerWindow customerWindow = new CustomerWindow(user);
                customerWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid user role.", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
