namespace ContosoU.Models
{
    public class CourseAssignment
    {
        public int CourseID { get; set; } // Part of the Composite PK, and FK to Course
        public int InstructorID { get; set; } // Part of the Composite PK, and FK to Instructor

        /*
         * The only way to identify composite PK to the Entity Framework is by using the Fluent API
         * within the DbContext class (in this case, the SchoolContext class)
         * 
         * It cannot be done using attributes
         */

        // Navigation Property
        // Many-to-many (this is the junction table between courses and instructors)
        // Many instructors teaching many courses
        // 1 course with many Course assignemnts
        // 1 instructor with many course assignments
        public virtual Instructor Instructor { get; set; }
        public virtual Course Course { get; set; }
    }
}