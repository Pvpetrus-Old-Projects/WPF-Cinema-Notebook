using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ProjektWPF
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=BestDatabase")
        {
        }

        public virtual DbSet<Film> Film { get; set; }
        public virtual DbSet<FilmViewing> FilmViewing { get; set; }
        public virtual DbSet<Note> Note { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Film>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Film>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Note>()
                .Property(e => e.NoteTitle)
                .IsUnicode(false);

            modelBuilder.Entity<Note>()
                .Property(e => e.Text)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);
        }
    }
}
