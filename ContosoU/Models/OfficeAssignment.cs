using System.ComponentModel.DataAnnotations;

namespace ContosoU.Models
{
    // tlannigan - Part 2L Create the data models
    public class OfficeAssignment
    {
        [Key]
        public int InstructorID { get; set; }

        [StringLength(60)]
        [Display(Name = "Office Location")]
        public string Location { get; set; }

        // Navigation Property - back to one instructor
        public virtual Instructor Instructor { get; set; }
    }
}