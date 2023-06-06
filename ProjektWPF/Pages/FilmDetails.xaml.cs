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
        public FilmDetails()
        {
            InitializeComponent();
        }
        public FilmDetails(string title, DateTime date, bool viewed, string descr)
        {
            InitializeComponent();
            filmTitle.Text = title;
            filmDate.SelectedDate = date;
            filmViewed.IsChecked = viewed;
            filmDescription.Text = descr;
        }
    }
}
