using ProjektWPF.Pages;
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

namespace ProjektWPF
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int UserId { get; set; }
        public MainWindow(int id)
        {
            UserId = id;
            InitializeComponent();
            Films filmsPage = new Films(UserId);
            mainFrame.Content = filmsPage;
        }
        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.AlertTextBlock.Text = "Logged out";
            Close();
            loginWindow.Show();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void showFilmsList(object sender, RoutedEventArgs e)
        {
            Films filmsPage = new Films(UserId);
            mainFrame.Content = filmsPage;
        }
        private void showNotesList(object sender, RoutedEventArgs e)
        {
            Notes notesPage = new Notes(UserId);
            mainFrame.Content = notesPage;
        }
        private void showShowingsList(object sender, RoutedEventArgs e)
        {
            Showings showingsPage = new Showings(UserId);
            mainFrame.Content = showingsPage;
        }
    }
}
