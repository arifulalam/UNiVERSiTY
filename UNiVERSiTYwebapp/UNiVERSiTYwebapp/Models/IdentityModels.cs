using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UNiVERSiTYwebapp.Models
{
    // You can add profile data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class User : IdentityUser
    {
        /*
         * Following fields/properties are extra, which will be added to 
         * Users table
         */
        [MaxLength(30),
            Display(Name = "First Name")]
        public string FirstName { get; set; }
        [MaxLength(30),
            Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [MaxLength(30),
            Display(Name = "Last Name")]
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        [Column(TypeName = "Text")]
        public string Photo { get; set; }
        [Column(TypeName = "Text")]
        public string Address { get; set; }
        [MaxLength(80)]
        public string City { get; set; }
        [MaxLength(10)]
        public string ZipCode { get; set; }
        public DateTime? CreatedOn { get; set; }
        [MaxLength(30)]
        public string RegNo { get; set; }
        public DateTime? RegDate { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext()
            : base("UniversityDBContext", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        /*
         * By default ASP.net OWIN Identity tables names like
         * AspNetUsers, AspNetUserClaims, AspNetRoles, AspNetUserRoles, AspNetUserLogins
         * Using following override method, we are going to change this table name to as 
         * we required. Now I used to remove AspNet prefix from each table name.
         * And also changed primary key column default name to custom name.
         */
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("Users").Property(p => p.Id).HasColumnName("UserId");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims").Property(p => p.Id).HasColumnName("UserClaimId"); ;
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles").Property(p => p.Id).HasColumnName("RoleId");
        }

        public DbSet<Building> Buildings { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<FacultyBuilding> FacultyBuildings { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<AttendanceType> AttendanceTypes { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
    }
}