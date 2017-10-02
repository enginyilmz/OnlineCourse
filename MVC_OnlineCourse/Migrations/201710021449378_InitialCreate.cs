namespace MVC_OnlineCourse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Booking",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        course = c.Int(nullable: false),
                        student = c.Int(nullable: false),
                        createDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Course", t => t.course)
                .ForeignKey("dbo.Student", t => t.student)
                .Index(t => t.course)
                .Index(t => t.student);
            
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        courseName = c.String(maxLength: 50),
                        city = c.String(maxLength: 50),
                        instructor = c.String(maxLength: 50),
                        hour = c.Int(),
                        price = c.Decimal(precision: 18, scale: 0),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        name = c.String(maxLength: 50),
                        surname = c.String(maxLength: 50),
                        dateOfBirth = c.DateTime(),
                        schoolName = c.String(maxLength: 50),
                        gender = c.String(maxLength: 10, fixedLength: true),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Booking", "student", "dbo.Student");
            DropForeignKey("dbo.Booking", "course", "dbo.Course");
            DropIndex("dbo.Booking", new[] { "student" });
            DropIndex("dbo.Booking", new[] { "course" });
            DropTable("dbo.Student");
            DropTable("dbo.Course");
            DropTable("dbo.Booking");
        }
    }
}
