namespace ProjektWPF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FilmViewing")]
    public partial class FilmViewing
    {
        public int Id { get; set; }

        public int FilmId { get; set; }

        public DateTime DateOfViewing { get; set; }

        public virtual Film Film { get; set; }
    }
}
