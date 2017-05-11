namespace UNiVERSiTYwebapp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<UNiVERSiTYwebapp.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "UNiVERSiTYwebapp.Models.ApplicationDbContext";
        }

        protected override void Seed(UNiVERSiTYwebapp.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.AttendanceTypes.AddOrUpdate(
                    new Models.AttendanceType { AttendanceTypeId = 1, AttendanceTypeName = "Present" },
                    new Models.AttendanceType { AttendanceTypeId = 2, AttendanceTypeName = "Absent" },
                    new Models.AttendanceType { AttendanceTypeId = 3, AttendanceTypeName = "Late" }
                );
            context.Designations.AddOrUpdate(
                    new Models.Designation { DesignationId = 1, DesignationName = "Professor", DesignationType = "Educational" },
                    new Models.Designation { DesignationId = 2, DesignationName = "Asst. Professor", DesignationType = "Educational" },
                    new Models.Designation { DesignationId = 3, DesignationName = "Assoc. Professor", DesignationType = "Educational" },
                    new Models.Designation { DesignationId = 4, DesignationName = "Lecturer", DesignationType = "Educational" },
                    new Models.Designation { DesignationId = 5, DesignationName = "Sr. Accountant", DesignationType = "Administration" },
                    new Models.Designation { DesignationId = 6, DesignationName = "Jr. Accountant", DesignationType = "Administration" },
                    new Models.Designation { DesignationId = 7, DesignationName = "Principal", DesignationType = "Administration" },
                    new Models.Designation { DesignationId = 8, DesignationName = "Vise Principal", DesignationType = "Administration" },
                    new Models.Designation { DesignationId = 9, DesignationName = "Department Head", DesignationType = "Administration" },
                    new Models.Designation { DesignationId = 10, DesignationName = "Advisor", DesignationType = "Administration" }
                );
        }
    }
}
