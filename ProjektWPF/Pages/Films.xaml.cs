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

namespace ProjektWPF.Pages
{
    /// <summary>
    /// Interaction logic for Films.xaml
    /// </summary>
    public partial class Films : Page
    {
        Model1 db = new Model1();
        private List<Film> filmsL;
        public int UserId { get; set; }

        public Films(int userId)
        {
            UserId = userId;
            InitializeComponent();
            filmsL = db.Film.Where(item => item.UserId == UserId).ToList();
            filmsList.DataContext = filmsL;
        }
        void OnChecked(object sender, RoutedEventArgs e)
        {
            Film selectedElement = filmsList.SelectedItem as Film;
            if (selectedElement != null)
            {
                Film film = filmsL.Find(el => el.Id == selectedElement.Id);
                film.Viewed = !film.Viewed;
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    // Handle or log the exception
                    Console.WriteLine("SaveChanges error: " + ex.Message);
                }
            }
            filmsList.SelectedItem = null;  //change selectedItem to null to prevent checking box by mistake again
        }

        private void doubleClickOnFilm(object sender, MouseButtonEventArgs e)
        {
            Film selectedElement = filmsList.SelectedItem as Film;
            FilmDetails filmDetails = new FilmDetails(selectedElement.Id, selectedElement.Name, (DateTime)selectedElement.DateOfPremiere, (bool)selectedElement.Viewed, selectedElement.Description);
            filmDetails.LoggedUserId = UserId; //set user data
            NavigationService navigationService = NavigationService.GetNavigationService(this);
            navigationService.Navigate(filmDetails);            
        }

        private void addFilm(object sender, RoutedEventArgs e)
        {
            FilmDetails filmDetails = new FilmDetails();
            filmDetails.LoggedUserId = UserId;
            NavigationService navigationService = NavigationService.GetNavigationService(this);
            navigationService.Navigate(filmDetails);
        }

        private void viewPendingFilms(object sender, RoutedEventArgs e)
        {
            bool showPendingFilms = (bool)viewPendingFilmsCheckbox.IsChecked;
            if ((bool)viewCompletedFilmsCheckbox.IsChecked) viewCompletedFilmsCheckbox.IsChecked = false;
            //uncheck above checkbox since only one can be checked
            if (showPendingFilms) displayParticularFilmsStatus(false);
            else displayAllFilms();
        }

        private void viewCompletedFilms(object sender, RoutedEventArgs e)
        {
            bool showCompletedFilms = (bool)viewCompletedFilmsCheckbox.IsChecked;
            if ((bool)viewPendingFilmsCheckbox.IsChecked) viewPendingFilmsCheckbox.IsChecked = false;
            if (showCompletedFilms) displayParticularFilmsStatus(true);
            else displayAllFilms();

        }

        private void displayParticularFilmsStatus(bool seen)
        {
            filmsList.DataContext = filmsL.Where(el => el.Viewed == seen).ToList();
        }
        private void displayAllFilms()
        {
            filmsList.DataContext = filmsL;
        }

        private void searchFilm(object sender, TextChangedEventArgs e)
        {
            if (searchFilmInput.Text.Length > 1)
                filmsList.DataContext = filmsL.Where(el => el.Name.ToLower().Contains(searchFilmInput.Text)).ToList();
            else displayAllFilms();
        }
    }
}
