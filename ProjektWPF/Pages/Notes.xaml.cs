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
    public partial class Notes : Page
    {
        Model1 db = new Model1();
        private List<Note> notesL;
        public int UserId { get; set; }

        public Notes(int userId)
        {
            InitializeComponent();
            notesL = db.Note.ToList();
            notesList.DataContext = notesL;
            UserId = userId;
        }

        private void doubleClickOnNote(object sender, MouseButtonEventArgs e)
        {
            Note selectedElement = notesList.SelectedItem as Note;
            NoteDetails noteDetails = new NoteDetails(); // ND
            noteDetails.UserId = UserId; //set user data
            NavigationService navigationService = NavigationService.GetNavigationService(this);
            navigationService.Navigate(noteDetails);
        }

        private void addNote(object sender, RoutedEventArgs e)
        {
            NoteDetails notesDetails = new NoteDetails();
            notesDetails.UserId = UserId; // ND
            NavigationService navigationService = NavigationService.GetNavigationService(this);
            navigationService.Navigate(notesDetails);
        }

        private void displayAllNotes()
        {
            notesList.DataContext = notesL;
        }

        private void searchFilm(object sender, TextChangedEventArgs e)
        {
            if (searchNoteInput.Text.Length > 1)
                notesList.DataContext = notesL.Where(el => el.NoteTitle.ToLower().Contains(searchNoteInput.Text)).ToList();
            else displayAllNotes();
        }

        private void notesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }private void OnChecked(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
