using System.ComponentModel.DataAnnotations;

namespace Assesment.Models
{
    public class Employee
    {
        [Key]
        public int EId { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Employee_code { get; set; }

        public Doctor Doctor { get; set; } // One-to-One
        public Nurse Nurse { get; set; } // One-to-One
        public Receptionist Receptionist { get; set; } // One-to-One

    }
}
