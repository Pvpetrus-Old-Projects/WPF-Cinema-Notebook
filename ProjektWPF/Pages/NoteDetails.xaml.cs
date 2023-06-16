using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
    /// Interaction logic for NoteDetails.xaml
    /// </summary>
    public partial class NoteDetails : Page
    {
        Model1 db = new Model1();
        private List<Note> notesL;
        private List<Film> filmsL;
        Note note;
        public int LoggedUserId { get; set; }
        string mode;
        public NoteDetails()
        {
            mode = "creation";
            InitializeComponent();
            bindcombo();
            note = new Note();
            deleteNoteButton.Visibility = Visibility.Collapsed; //delete button not needed if the film is being added
        }
        public NoteDetails(int? filmId, string title, int? rating, string text)
        {
            mode = "edition";
            InitializeComponent();
            bindcombo();
            deleteNoteButton.Visibility = Visibility.Visible;
            noteTitle.Text = title;
            noteText.Text = text;
            noteRating.Text = rating.ToString();
            notesL = db.Note.ToList();
            note = notesL.FirstOrDefault(el => el.FilmId == filmId);
        }

        private void saveAddNote(object sender, RoutedEventArgs e)
        {
            bool validData = true;
            string message = "";

            if (noteTitle.Text.Length > 1)
                note.NoteTitle = noteTitle.Text;
            else
            {
                message = "Title is too short";
                validData = false;
            }

            if (noteText.Text.Length > 1)
                note.Text = noteText.Text;
            else
            {
                message = "Fill content";
                validData = false;
            }
            if (noteRating.Text.Length > 0)
                try {
                    note.Rating = Int16.Parse(noteRating.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            else
            {
                message = "Fill rating";
                validData = false;
            }
            if(note.Rating <0 || note.Rating>10)
            {
                message = "Rating is incorrect";
                validData = false;
            }

            if (mode == "edition" && validData)
            {
                try
                {
                    db.SaveChanges();
                    switchToNotesList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else if (validData)
            {
                filmsL = db.Film.ToList();
                try
                {
                    note.FilmId = filmsL.FirstOrDefault(el => el.Name == noteFilmTitle.Text).Id;
                }
                catch (Exception ex) {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                note.DateOfCreation = DateTime.Today;
                try
                {
                    db.Note.Add(note);
                    db.SaveChanges();
                    switchToNotesList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                validationBorder.Visibility = Visibility.Visible;
                validationBox.Text = message;
            }
        }

        private void deleteNote(object sender, RoutedEventArgs e)
        {
            try
            {
                db.Note.Remove(note);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            switchToNotesList();
        }

        private void switchToNotesList()
        {
            Notes notesList = new Notes(LoggedUserId);  //we have to create a new page to refresh the list
            NavigationService navigationService = NavigationService.GetNavigationService(this);
            navigationService.Navigate(notesList);
        }

        private void bindcombo()
        {
            var item = db.Film.ToList();
            DataContext = item;
        }
    }
}
