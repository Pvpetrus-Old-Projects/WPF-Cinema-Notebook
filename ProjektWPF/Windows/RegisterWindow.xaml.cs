using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjektWPF
{
    /// <summary>
    /// Logika interakcji dla klasy RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            Model1 db = new Model1();

            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Text;
            string email = EmailTextBox.Text;

            if(username.Length == 0)
            {
                AlertTextBlock.Text = "Username cannot be empty";
                return;
            }
            if (password.Length == 0)
            {
                AlertTextBlock.Text = "Password cannot be empty";
                return;
            }
            if (email.Length == 0)
            {
                AlertTextBlock.Text = "Email cannot be empty";
                return;
            }
            if (username.Length < 5)
            {
                AlertTextBlock.Text = "Username is too short (<5)";
                return;
            }
            if (password.Length < 5)
            {
                AlertTextBlock.Text = "Password is too short (<5)";
                return;
            }
            if (username.Length >20)
            {
                AlertTextBlock.Text = "Username is too long (>20)";
                return;
            }
            if (password.Length >20)
            {
                AlertTextBlock.Text = "Password is too long (>20)";
                return;
            }
            if (email.Length > 50)
            {
                AlertTextBlock.Text = "Password is too long (>20)";
                return;
            }
            if (!new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$").IsMatch(email))
            {
                AlertTextBlock.Text = "Email is of wrong format";
                return;
            }

            User newUser = new User()
            {
                Email = EmailTextBox.Text,
                Password = PasswordTextBox.Text,
                Username = UsernameTextBox.Text
            };

            var registeredUsers = from u in db.User select u;
            foreach (var user in registeredUsers)
            {
                if (username.Equals(user.Username))
                {
                    AlertTextBlock.Text = "User with this username already exists";
                    return;
                }
            }
            db.User.Add(newUser);
            //db.User.Remove(newUser); USUWANIE
            // var registeredUsers = from u in db.User where u.Username.StartsWith("Pjoter") select u; UŻYCIE WHERE
            db.SaveChanges();

            LoginWindow loginWindow = new LoginWindow();
            loginWindow.AlertTextBlock.Text = "Registered successfully";
            loginWindow.Show();
            this.Close();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
