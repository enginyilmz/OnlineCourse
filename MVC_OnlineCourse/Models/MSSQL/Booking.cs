namespace MVC_OnlineCourse.Models.MSSQL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Booking")]
    public partial class Booking
    {
        public int ID { get; set; }

        public int course { get; set; }

        public int student { get; set; }

        public DateTime? createDate { get; set; }

        public virtual Course Course1 { get; set; }

        public virtual Student Student1 { get; set; }
    }
}
