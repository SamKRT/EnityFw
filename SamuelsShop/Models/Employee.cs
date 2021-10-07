using System;
using System.ComponentModel.DataAnnotations;

namespace SamuelsShop.Models
{
    class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        
        [Required, MaxLength(50)]
        public string FirstName { get; set; }

        [Required, MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        [Required, MaxLength(50)]
        public string Street { get; set; }

        [Required]
        public int HouseNumber { get; set; }

        [Required] 
        public int PostalCode { get; set; }

        [Required, MaxLength(50)] 
        public string City { get; set; }

        [Required, MaxLength(50)] 
        public string Username { get; set; }

        [Required, MaxLength(50)] 
        public string Password { get; set; }

        [Required] 
        public char WorkPostion { get; set; }

        [Required]
        public int VacationLength { get; set; }

        [Required] 
        public double VacationTaken { get; set; }
    }
}
