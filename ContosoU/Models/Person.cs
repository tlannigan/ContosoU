using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoU.Models
{
    // tlannigan - Part 2: Creat the data models
    // 1. Create the person abstract class (inheritance)
    public abstract class Person
    {
        public int ID { get; set; }
        // THe ID property will become the PK column of the database table
        // by default EF interprets a property named "ID" or "classnameID" as the PK


        // String types will become nvarchar
        // Without a stringlength they are set to max: nvarchar(max)
        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(65, ErrorMessage = "Last name cannot be longer than 65 characters.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)] // nvarchar(max)
        public string Email { get; set; }

        [Required]
        [StringLength(150)]
        public string Address { get; set; }

        [Required]
        [StringLength(60)]
        public string City { get; set; }

        [Required]
        [StringLength(7)]
        [Column(TypeName = "nchar(7)")] //nchar(7)
        [DataType(DataType.PostalCode)]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        [Required]
        [StringLength(2)]
        [Column(TypeName = "nchar(2)")] // nchar(2)
        public string Province { get; set; }

        // Fullname: readonly property
        [Display(Name = "Name")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }

        // IDFullName: readonly property
        public string IDFullName
        {
            get
            {
                return "(" + ID + ") " + LastName + ", " + FirstName;
            }
        }

        // FullAddress: readonly property
        public string FullAddress
        {
            get
            {
                return Address + ", " + City + ", " + Province + ", " + PostalCode;
            }
        }
    }
}
