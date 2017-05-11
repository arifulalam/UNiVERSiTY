namespace UNiVERSiTYwebapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class version10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        AttendanceId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        CourseId = c.Int(nullable: false),
                        AttendanceTypeId = c.Int(nullable: false),
                        Datetime = c.DateTime(nullable: false),
                        AttendanceNote = c.String(unicode: false, storeType: "text"),
                    })
                .PrimaryKey(t => t.AttendanceId)
                .ForeignKey("dbo.AttendanceTypes", t => t.AttendanceTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.CourseId)
                .Index(t => t.AttendanceTypeId);
            
            CreateTable(
                "dbo.AttendanceTypes",
                c => new
                    {
                        AttendanceTypeId = c.Int(nullable: false, identity: true),
                        AttendanceTypeName = c.String(),
                    })
                .PrimaryKey(t => t.AttendanceTypeId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        CourseCode = c.String(nullable: false, maxLength: 5),
                        CourseName = c.String(nullable: false, maxLength: 30),
                        CourseCredit = c.Double(nullable: false),
                        CourseDescription = c.String(unicode: false, storeType: "text"),
                        DepartmentId = c.Int(nullable: false),
                        SemesterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Semesters", t => t.SemesterId, cascadeDelete: true)
                .Index(t => t.CourseCode, unique: true)
                .Index(t => t.DepartmentId)
                .Index(t => t.SemesterId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmentCode = c.String(nullable: false, maxLength: 15),
                        DepartmentName = c.String(nullable: false),
                        DepartmentEstablishedOn = c.DateTime(),
                        BuildingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentId)
                .ForeignKey("dbo.Buildings", t => t.BuildingId, cascadeDelete: true)
                .Index(t => t.DepartmentCode, unique: true)
                .Index(t => t.BuildingId);
            
            CreateTable(
                "dbo.Buildings",
                c => new
                    {
                        BuildingId = c.Int(nullable: false, identity: true),
                        BuildingCode = c.String(nullable: false, maxLength: 15),
                        BuildingName = c.String(nullable: false, maxLength: 80),
                        BuiltOn = c.DateTime(nullable: false),
                        Floors = c.Int(nullable: false),
                        BuildingDescription = c.String(),
                    })
                .PrimaryKey(t => t.BuildingId)
                .Index(t => t.BuildingCode, unique: true);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        RoomId = c.Int(nullable: false, identity: true),
                        RoomCode = c.String(nullable: false, maxLength: 4),
                        RoomFloors = c.Int(nullable: false),
                        RoomNote = c.String(),
                        BuildingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RoomId)
                .ForeignKey("dbo.Buildings", t => t.BuildingId, cascadeDelete: true)
                .Index(t => t.BuildingId);
            
            CreateTable(
                "dbo.Semesters",
                c => new
                    {
                        SemesterId = c.Int(nullable: false, identity: true),
                        SemesterName = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.SemesterId)
                .Index(t => t.SemesterName, unique: true);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(maxLength: 30),
                        MiddleName = c.String(maxLength: 30),
                        LastName = c.String(maxLength: 30),
                        BirthDate = c.DateTime(),
                        Photo = c.String(unicode: false, storeType: "text"),
                        Address = c.String(unicode: false, storeType: "text"),
                        City = c.String(maxLength: 80),
                        ZipCode = c.String(maxLength: 10),
                        CreatedOn = c.DateTime(),
                        RegNo = c.String(maxLength: 30),
                        RegDate = c.DateTime(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.UserId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.UserClaims",
                c => new
                    {
                        UserClaimId = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.UserClaimId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Designations",
                c => new
                    {
                        DesignationId = c.Int(nullable: false, identity: true),
                        DesignationName = c.String(nullable: false, maxLength: 30),
                        DesignationType = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.DesignationId)
                .Index(t => t.DesignationName, unique: true);
            
            CreateTable(
                "dbo.Faculties",
                c => new
                    {
                        FacultyId = c.Int(nullable: false, identity: true),
                        FacultyCode = c.String(nullable: false, maxLength: 15),
                        FacultyName = c.String(nullable: false, maxLength: 80),
                        FacultyDescription = c.String(),
                    })
                .PrimaryKey(t => t.FacultyId)
                .Index(t => t.FacultyCode, unique: true);
            
            CreateTable(
                "dbo.FacultyBuildings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FacultyId = c.Int(nullable: false),
                        BuildingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Buildings", t => t.BuildingId, cascadeDelete: true)
                .ForeignKey("dbo.Faculties", t => t.FacultyId, cascadeDelete: true)
                .Index(t => t.FacultyId)
                .Index(t => t.BuildingId);
            
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        GradeId = c.Int(nullable: false, identity: true),
                        GradeMarkMin = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GradeMarkMax = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GradeLetter = c.String(nullable: false),
                        GradeText = c.String(),
                    })
                .PrimaryKey(t => t.GradeId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.RoleId)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.StudentCourses",
                c => new
                    {
                        StudentCourseId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        CourseId = c.Int(nullable: false),
                        EnrollDate = c.DateTime(nullable: false),
                        Mark = c.Single(nullable: false),
                        IsDeleted = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.StudentCourseId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentCourses", "UserId", "dbo.Users");
            DropForeignKey("dbo.StudentCourses", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.FacultyBuildings", "FacultyId", "dbo.Faculties");
            DropForeignKey("dbo.FacultyBuildings", "BuildingId", "dbo.Buildings");
            DropForeignKey("dbo.Attendances", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserLogins", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserClaims", "UserId", "dbo.Users");
            DropForeignKey("dbo.Attendances", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Courses", "SemesterId", "dbo.Semesters");
            DropForeignKey("dbo.Courses", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Departments", "BuildingId", "dbo.Buildings");
            DropForeignKey("dbo.Rooms", "BuildingId", "dbo.Buildings");
            DropForeignKey("dbo.Attendances", "AttendanceTypeId", "dbo.AttendanceTypes");
            DropIndex("dbo.StudentCourses", new[] { "CourseId" });
            DropIndex("dbo.StudentCourses", new[] { "UserId" });
            DropIndex("dbo.Roles", "RoleNameIndex");
            DropIndex("dbo.FacultyBuildings", new[] { "BuildingId" });
            DropIndex("dbo.FacultyBuildings", new[] { "FacultyId" });
            DropIndex("dbo.Faculties", new[] { "FacultyCode" });
            DropIndex("dbo.Designations", new[] { "DesignationName" });
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropIndex("dbo.UserLogins", new[] { "UserId" });
            DropIndex("dbo.UserClaims", new[] { "UserId" });
            DropIndex("dbo.Users", "UserNameIndex");
            DropIndex("dbo.Semesters", new[] { "SemesterName" });
            DropIndex("dbo.Rooms", new[] { "BuildingId" });
            DropIndex("dbo.Buildings", new[] { "BuildingCode" });
            DropIndex("dbo.Departments", new[] { "BuildingId" });
            DropIndex("dbo.Departments", new[] { "DepartmentCode" });
            DropIndex("dbo.Courses", new[] { "SemesterId" });
            DropIndex("dbo.Courses", new[] { "DepartmentId" });
            DropIndex("dbo.Courses", new[] { "CourseCode" });
            DropIndex("dbo.Attendances", new[] { "AttendanceTypeId" });
            DropIndex("dbo.Attendances", new[] { "CourseId" });
            DropIndex("dbo.Attendances", new[] { "UserId" });
            DropTable("dbo.StudentCourses");
            DropTable("dbo.Roles");
            DropTable("dbo.Grades");
            DropTable("dbo.FacultyBuildings");
            DropTable("dbo.Faculties");
            DropTable("dbo.Designations");
            DropTable("dbo.UserRoles");
            DropTable("dbo.UserLogins");
            DropTable("dbo.UserClaims");
            DropTable("dbo.Users");
            DropTable("dbo.Semesters");
            DropTable("dbo.Rooms");
            DropTable("dbo.Buildings");
            DropTable("dbo.Departments");
            DropTable("dbo.Courses");
            DropTable("dbo.AttendanceTypes");
            DropTable("dbo.Attendances");
        }
    }
}
