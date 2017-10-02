namespace MVC_OnlineCourse.Models.MSSQL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CourseModel : DbContext
    {
        public CourseModel()
            : base("name=CourseModel")
        {
        }

        public virtual DbSet<Booking> Booking { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Student> Student { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .Property(e => e.price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Course>()
                .HasMany(e => e.Booking)
                .WithRequired(e => e.Course1)
                .HasForeignKey(e => e.course)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.gender)
                .IsFixedLength();

            modelBuilder.Entity<Student>()
                .HasMany(e => e.Booking)
                .WithRequired(e => e.Student1)
                .HasForeignKey(e => e.student)
                .WillCascadeOnDelete(false);
        }
    }
}
