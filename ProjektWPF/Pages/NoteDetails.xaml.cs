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
    /// Interaction logic for NoteDetails.xaml
    /// </summary>
    public partial class NoteDetails : Page
    {
        ApplicationDatabaseEntities db = new ApplicationDatabaseEntities();
        private List<Note> notesL;
        Note note;
        public int UserId { get; set; }
        string mode;
        public NoteDetails()
        {
            mode = "creation";
            InitializeComponent();
            note = new Note();
            deleteNoteButton.Visibility = Visibility.Collapsed; //delete button not needed if the film is being added
        }
        public NoteDetails(int filmId, string title, DateTime date, int rating, string text)
        {
            mode = "edition";
            InitializeComponent();
            deleteNoteButton.Visibility = Visibility.Visible;
            noteTitle.Text = title;
            noteText.Text = text;
            notesL = db.Note.ToList();
            //note = notesL.Find(el => el.Id == id); //ND
        }

        private void saveAddFilm(object sender, RoutedEventArgs e, DateTime dateTime)
        {

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
                note.UserId = UserId;

                try
                {
                    db.Note.Add(note);
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
                db.Note.Remove(note);
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
            Notes notesList = new Notes(UserId);  //we have to create a new page to refresh the list
            NavigationService navigationService = NavigationService.GetNavigationService(this);
            navigationService.Navigate(notesList);
        }

        private void deleteNote(object sender, RoutedEventArgs e)
        {

        }

        private void saveAddNote(object sender, RoutedEventArgs e)
        {

        }
    }
}
