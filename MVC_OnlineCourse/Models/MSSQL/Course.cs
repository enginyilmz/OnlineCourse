namespace MVC_OnlineCourse.Models.MSSQL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Course")]
    public partial class Course
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Course()
        {
            Booking = new HashSet<Booking>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string courseName { get; set; }

        [StringLength(50)]
        public string city { get; set; }

        [StringLength(50)]
        public string instructor { get; set; }

        public int? hour { get; set; }

        public decimal? price { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Booking> Booking { get; set; }
    }
}
