using System.ComponentModel.DataAnnotations.Schema;

namespace Assesment.Models
{
    public class Doctor
    {
        public int id { get; set; }
        [ForeignKey("Employee")]
        public int EId { get; set; }
        public string Department { get; set; }
        public string Qualification { get; set; }
        public Employee Employee { get; set; } // One-to-One
        public ICollection<Patient> Patients { get; set; }
    }
}
