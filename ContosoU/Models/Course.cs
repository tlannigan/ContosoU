using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoU.Models
{
    public class Course
    {
        // Remove Identity - autonumber feature
        // Choices are Computed, Identity, None
        // Computed: Database generates a value when a row is inserted or updated
        // Identity: Database generates a value when a row is inserted
        // None: Database does not generate a value

        // User will have to enter the CourseID manually
        [DatabaseGenerated(DatabaseGeneratedOption.None)] 
        [Display(Name = "Course Number")]
        public int CourseID { get; set; } // PK due to the naming convention

        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        public int Credits { get; set; }

        // Calculate readonly property
        // Return the courseID and course title
        public string CourseIDTitle
        {
            get
            {
                return CourseID + ", " + Title;
            }
        }

        // Navigation Properties
        // 1 course to many enrollments
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}