using System.ComponentModel.DataAnnotations;

namespace ContosoU.Models
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; } // PK will be set due to the naming convention

        public int CourseID { get; set; } // FK to course entity

        public int StudentID { get; set; } // FK to student entity

        // Show "No grade" in client instead of blank when Grade is null
        [DisplayFormat(NullDisplayText = "No grade yet")]
        public Grade? Grade { get; set; } // ? Nullable: because we don't get a grade upon registration
        
        // Navigation property
        public virtual Student Student { get; set; } // many enrollments to 1 student

        public virtual Course Course { get; set; }
    }

    // Grade enumeration
    public enum Grade
    {A, B, C, D, F}
}