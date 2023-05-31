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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjektWPF
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {


            ApplicationDatabaseEntities db = new ApplicationDatabaseEntities();
            MainWindow mainWindow = new MainWindow();
            var registeredUsers = from u in db.User select u;


            string username = UsernameTextBox.Text;
            string password = PasswordPasswordBox.Password;
            bool userFound = false;
            foreach (var user in registeredUsers)
            {
                if(username.Equals(user.Username) && password.Equals(user.Password))
                {
                    userFound = true;
                    mainWindow.Show();
                    this.Close();
                }
            }
            if(userFound==false)
            {
                AlertTextBlock.Text = "There is no such user ";
            }

        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
            this.Close();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
