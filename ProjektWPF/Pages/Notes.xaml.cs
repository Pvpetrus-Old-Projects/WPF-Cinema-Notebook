using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for Notes.xaml
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
            NoteDetails noteDetails = new NoteDetails(selectedElement.FilmId, selectedElement.NoteTitle, selectedElement.Rating, selectedElement.Text);
            noteDetails.LoggedUserId = UserId; //set user data
            NavigationService navigationService = NavigationService.GetNavigationService(this);
            navigationService.Navigate(noteDetails);
        }

        private void addNote(object sender, RoutedEventArgs e)
        {
            NoteDetails notesDetails = new NoteDetails();
            notesDetails.LoggedUserId = UserId;
            NavigationService navigationService = NavigationService.GetNavigationService(this);
            navigationService.Navigate(notesDetails);
        }

        private void displayAllNotes()
        {
            notesList.DataContext = notesL;
        }

        private void searchNoteInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (searchNoteInput.Text.Length > 0)
            notesList.DataContext = notesL.Where(el => el.NoteTitle.ToLower().Contains(searchNoteInput.Text)).ToList();
            else displayAllNotes();
        }
    }
}
