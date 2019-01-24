using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoU.Models
{
    public class Instructor:Person
    {
        [DataType(DataType.Date)]
        [Display(Name = "Hire Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime HireDate { get; set; }

        // Navigation property
        // An instructor can teach any number of courses, so Courses is defined
        // As a collection of the CourseAssignment Entity
        public virtual ICollection<CourseAssignment> Courses { get; set; }

        // An instructor can only have at most one office, so the officeassignment
        // navigation property holds a single office assignment entity
        // (which may be null when no office is assigned)
        public virtual OfficeAssignment OfficeAssignment { get; set; }
    }
}
