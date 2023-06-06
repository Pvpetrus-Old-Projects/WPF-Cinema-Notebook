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
        ApplicationDatabaseEntities db = new ApplicationDatabaseEntities();
        private List<Film> filmsL;
        public Films()
        {
            InitializeComponent();
            filmsL = db.Film.ToList();       
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
            FilmDetails filmDetails = new FilmDetails(selectedElement.Name, selectedElement.DateOfPremiere, selectedElement.Viewed, selectedElement.Description);

            NavigationService navigationService = NavigationService.GetNavigationService(this);
            navigationService.Navigate(filmDetails);
        }
    }
}
