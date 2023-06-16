namespace ProjektWPF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Note")]
    public partial class Note
    {
        public int FilmId { get; set; }

        [StringLength(50)]
        public string NoteTitle { get; set; }

        [StringLength(500)]
        public string Text { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateOfCreation { get; set; }

        public int? Rating { get; set; }

        public int Id { get; set; }

        public virtual Film Film { get; set; }
    }
}
