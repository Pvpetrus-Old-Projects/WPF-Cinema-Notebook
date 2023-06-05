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
            filmsL = new List<Film>(from u in db.Film select u);
/*            filmsL = new List<Film>(filmsFromDb);
*/            
            filmsList.DataContext = filmsL;
        }
        void OnChecked(object sender, RoutedEventArgs e)
        {
            Film selectedElement = filmsList.SelectedItem as Film;
            if (selectedElement != null)
            {
                Film film = filmsL.Find(el => el.Id == selectedElement.Id);
                film.Viewed = !film.Viewed;
                db.SaveChanges();
            }
        }

    }
}
