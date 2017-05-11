using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UNiVERSiTYwebapp.Models
{
    //Administrator/Teacher/Student/Parents/Employees all are Person
    public class Person
    {
        public string PersonId {get; set;} //UserId of AspNetUsers table
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string RegNo { get; set; }
        public DateTime RegDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Division { get; set; }
        public string PostOffice { get; set; }
        public string PostCode { get; set; }
        //public long DepartmentId { get; set; }
        //public long DesignationId { get; set; }
    }

    public class Building
    {
        public int BuildingId { get; set; }
        [Required(ErrorMessage = "Code is required."), 
            MaxLength(15, ErrorMessage = "Code should not more than 15 characters long."),
            Index(IsUnique = true),
            Display(Name = "Building Code")]
        public string BuildingCode { get; set; }
        [Required(ErrorMessage = "Name is required."),
            MaxLength(80, ErrorMessage = "Name should not more than 80 characters long."),
            Display(Name = "Building Name")]
        public string BuildingName { get; set; }
        [Required(ErrorMessage = "Build date is required."),
            Display(Name = "Built On")]
        public DateTime? BuiltOn { get; set; }
        [Required(ErrorMessage = "You have to define current total floors of the building.")]
        public int Floors { get; set; }
        [Display(Name = "Description")]
        public string BuildingDescription { get; set; }

        public virtual List<Room> Room { get; set; }
    }

    public class Room
    {
        public int RoomId { get; set; }
        [Required(ErrorMessage = "Code is required."),
            StringLength(4, MinimumLength = 4, ErrorMessage = "Code should be 4 characters long."),
            Display(Name = "Room Code")]
        public string RoomCode { get; set; }
        [Display(Name = "Floors")]
        public int RoomFloors { get; set; }
        [Display(Name = "Short Note")]
        public string RoomNote { get; set; }

        [Required(ErrorMessage = "You have to select a building"),
            Display(Name = "Building Code/Name")]
        public int BuildingId { get; set; }

        [ForeignKey("BuildingId")]
        public virtual Building Building { get; set; }
    }

    public class Faculty
    {
        public int FacultyId { get; set; }
        [Required(ErrorMessage = "Code is required."),
            StringLength(15, ErrorMessage = "Code should not more than 15 characters long."),
            Index(IsUnique = true),
            Display(Name = "Faculty Code")]
        public string FacultyCode { get; set; }
        [Required(ErrorMessage = "Name is required."),
            StringLength(80, ErrorMessage = "Name should not more that 80 characters long."),
            Display(Name = "Faculty Name")]
        public string FacultyName { get; set; }
        [Display(Name = "Short Description")]
        public string FacultyDescription { get; set; }
    }

    public class FacultyBuilding
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "You have to select a faculty."),
            Display(Name = "Faculty Code/Name")]
        public int FacultyId { get; set; }
        [Required(ErrorMessage = "You have to select a building"),
            Display(Name = "Building Code/Name")]
        public int BuildingId { get; set; }

        [ForeignKey("FacultyId")]
        public virtual Faculty Faculty { get; set; }
        [ForeignKey("BuildingId")]
        public virtual Building Building { get; set; }
    }

    public class Department
    {
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Code is required."),
            StringLength(15, ErrorMessage = "Code should not more that 15 characters long."),
            Index(IsUnique = true),
            Display(Name = "Department Code")]
        public string DepartmentCode { get; set; }
        [Required(ErrorMessage = "Name is required."),
            Display(Name = "Department Name")]
        public string DepartmentName { get; set; }
        [Display(Name = "Established On")]
        public DateTime? DepartmentEstablishedOn { get; set; }
        [Required(ErrorMessage = "You have to select a building."),
            Display(Name = "Building Code/Name")]
        public int BuildingId { get; set; }

        [ForeignKey("BuildingId")]
        public virtual Building Building { get; set; }
    }

    public class Semester
    {
        public int SemesterId { get; set; }
        [Required(ErrorMessage = "Semester is required."),
            StringLength(15, ErrorMessage = "Semester name should not more than 15 characters long."),
            Index(IsUnique = true),
            Display(Name = "Semester")]
        public string SemesterName { get; set; }
    }

    public class Course
    {
        public int CourseId { get; set; }
        [Required(ErrorMessage = "Code is required."),
            StringLength(5, MinimumLength = 3, ErrorMessage = "Code should be between 3 and 5 characters."),
            Index(IsUnique = true),
            Display(Name = "Course Code")]
        public string CourseCode { get; set; }
        [Required(ErrorMessage = "Name is required."),
            StringLength(30, ErrorMessage = "Name should not more that 30 characters long."),
            Display(Name = "Course Name")]
        public string CourseName { get; set; }
        [Required(ErrorMessage = "Credit is required."),
            Column(TypeName = "float"),
            Range(0.5, 5.0, ErrorMessage = "Credit point should be between 0.5 and 5.0"),
            Display(Name = "Course Credit")]
        public float CourseCredit { get; set; }
        [StringLength(1000, ErrorMessage = "Description should not more than 1000 characters long."),
            Column(TypeName = "Text"),
            DataType(DataType.MultilineText),
            Display(Name = "Course Description")]
        public string CourseDescription { get; set; }
        [Required(ErrorMessage = "You have to select a department."),
            Display(Name = "Department Code/Name")]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "You have to select a semester."),
            Display(Name = "Semester")]
        public int SemesterId { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }
        [ForeignKey("SemesterId")]
        public virtual Semester Semester { get; set; }
    }

    public class Designation
    {
        public int DesignationId { get; set; }
        [Required(ErrorMessage = "Name is required"),
            Index(IsUnique = true),
            StringLength(30, ErrorMessage = "Designation name should not more that 30 characters long."),
            Display(Name = "Designation Name")]
        public string DesignationName { get; set; }
        [Required(ErrorMessage = "Type is required"),
            StringLength(30, ErrorMessage = "Designation type should not more that 30 characters long."),
            Display(Name = "Designation Type")]
        public string DesignationType { get; set; }
    }

    public class Attendance
    {
        [Key]
        public string AttendanceId { get; set; }
        [Required(ErrorMessage = "You have to select a student."),
            StringLength(128),
            Column(TypeName = "nvarchar"),
            Display(Name = "Student")]
        public string UserId { get; set; }
        [Required(ErrorMessage = "You have to select course."),
            Display(Name = "Course")]
        public int CourseId { get; set; }
        [Required(ErrorMessage = "You have to mark attendance."),
            Display(Name = "Attendance Type")]
        public int AttendanceTypeId { get; set; }  
        public DateTime Datetime { get; set; }
        [DataType(DataType.MultilineText),
            Column(TypeName = "Text"),
            Display(Name = "Student")]
        public string AttendanceNote { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }
        [ForeignKey("AttendanceTypeId")]
        public virtual AttendanceType AttendanceType { get; set; }
    }

    public class AttendanceType
    {
        public int AttendanceTypeId { get; set; }
        public string AttendanceTypeName { get; set; }
        /*
         * Values:
         * Absent
         * Present
         * Late
         */
    }

    public class StudentCourse
    {
        [Key]
        public string StudentCourseId { get; set; }
        [Required(ErrorMessage = ""),
            StringLength(128),
            Column(TypeName = "nvarchar"),
            Display(Name = "Student")]
        public string UserId { get; set; }
        [Required(ErrorMessage = ""),
            Display(Name = "Course")]
        public int CourseId { get; set; }
        public DateTime EnrollDate { get; set; }
        [DefaultValue(0.0)]
        public float Mark { get; set; }
        [DefaultValue(0)]
        public byte IsDeleted { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }
    }

    public class Grade
    {
        public int GradeId { get; set; }
        [Required(ErrorMessage = "You have to set minimum mark for grade."),
            Range(0, 100, ErrorMessage = "Mark must be between 0 to 100."),
            Display(Name = "Minimum Mark")]
        public decimal GradeMarkMin { get; set; }
        [Required(ErrorMessage = "You have to set maximum mark for grade."),
            Range(0, 100, ErrorMessage = "Mark must be between 0 to 100."),
            Display(Name = "Maximum Mark")]
        public decimal GradeMarkMax { get; set; }
        [Required(ErrorMessage = "Grade Letter is required."),
            Display(Name = "Grade Letter")]
        public string GradeLetter { get; set; } // A+, A, B etc
        [Display(Name = "Grade Text")]
        public string GradeText { get; set; } // Excellent, Outstanding, Good etc
    }
}