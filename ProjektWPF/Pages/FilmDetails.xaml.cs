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
    /// Interaction logic for FilmDetails.xaml
    /// </summary>
    public partial class FilmDetails : Page
    {
        int filmId;
        ApplicationDatabaseEntities db = new ApplicationDatabaseEntities();
        private List<Film> filmsL;
        Film film;
        public int UserId { get; set; }
        string mode;
        public FilmDetails()
        {
            mode="creation";
            InitializeComponent();
            film = new Film();
            deleteFilmButton.Visibility = Visibility.Collapsed; //delete button not needed if the film is being added
        }
        public FilmDetails(int id,string title, DateTime date, bool viewed, string descr)
        {
            mode = "edition";
            InitializeComponent();
            deleteFilmButton.Visibility = Visibility.Visible;
            filmTitle.Text = title;     //set film data to UI
            filmDate.SelectedDate = date;
            filmViewed.IsChecked = viewed;
            filmDescription.Text = descr;
            filmsL = db.Film.ToList();
            film = filmsL.Find(el => el.Id == id);
        }

        private void saveAddFilm(object sender, RoutedEventArgs e)
        {
            film.Name = filmTitle.Text; //get values of changed data
            film.DateOfPremiere = (DateTime)filmDate.SelectedDate;
            film.Viewed = (bool)filmViewed.IsChecked;
            film.Description = filmDescription.Text;

            if (mode == "edition")
            {
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }  
            else
            { 
                film.UserId = UserId;

                try
                {
                    db.Film.Add(film);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            switchToFilmsList();
        }

        private void deleteFilm(object sender, RoutedEventArgs e)
        {
            try
            {
                db.Film.Remove(film);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            switchToFilmsList();
        }

        private void switchToFilmsList()
        {
            Films filmsList = new Films(UserId);  //we have to create a new page to refresh the list
            NavigationService navigationService = NavigationService.GetNavigationService(this);
            navigationService.Navigate(filmsList);
        }
    }
}
