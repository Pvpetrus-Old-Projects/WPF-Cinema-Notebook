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
    /// Logika interakcji dla klasy Showings.xaml
    /// </summary>
    public partial class Showings : Page
    {
        Model1 db = new Model1();
        private List<FilmViewing> showingsL;

        public int UserId { get; set; }

        public Showings(int userId)
        {
            InitializeComponent();
            showingsL = db.FilmViewing.ToList();
            showingsList.DataContext = showingsL;
            UserId = userId;
        }
    }
}