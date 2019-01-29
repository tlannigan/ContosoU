using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoU.Models
{
    public class Department
    {
        public int DepartmentID { get; set; } // PK

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }

        [DataType(DataType.Currency)] // Client side only
        [Column(TypeName = "money")] // SQL Server money data type
        public decimal Budget { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date Created")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MMM-dd", ApplyFormatInEditMode = true)]
        public DateTime CreatedDate { get; set; }

        // Relationship to instructor
        // A department MAY have an Administrator (Instructor), and an
        // Administrator is always an Instructor
        [Display(Name = "Administrator")]
        public int? InstructorID { get; set; } // ? denotes nullable

        // Navigation properties
        // Administrator is always an Instructor
        public virtual Instructor Administrator { get; set; }

        // One department to many courses
        public virtual ICollection<Course> Courses { get; set; }
    }
}
