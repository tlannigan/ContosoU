using ContosoU.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoU.Data
{
    public class SchoolContext:DbContext
    {
        // Constructor
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {

        }

        // Specifying Entity Sets - corresponding to database tables and each single entity corresponds to a row in a table
        public DbSet<Person> People { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseAssignment> CourseAssignments { get; set; }

        /*
         * Plural table names by default:
         * When the database is created from migration process, Entity Framework creates
         * tables that have the same names as the DbSet property.
         * -- Just a developer debate (plural vs singular table names)
         */

        //  Override the behaviour using Fluent API.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<CourseAssignment>().ToTable("CourseAssignment");
            //modelBuilder.Entity<Student>().ToTable("Student");
            //modelBuilder.Entity<Instructor>().ToTable("Instructor");
            modelBuilder.Entity<Person>().ToTable("Person");

            // Composite PK on COurseAssignment (CourseID, InstructorID)
            modelBuilder.Entity<CourseAssignment>()
                .HasKey(c => new { c.CourseID, c.InstructorID });
        }

    }
}
