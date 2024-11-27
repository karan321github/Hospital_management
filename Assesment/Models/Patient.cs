using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assesment.Models
{
    public class Patient
    {
        [Key]
        public int PId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Mobile number should be a number. ")]
        [MaxLength(15, ErrorMessage = "Max 15  digits are allowed. ")]
        public string MobileNumber { get; set; }
        public int Age { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
        public ICollection<Bill> Bills { get; set; }
        public ICollection<TestReport> Tests { get; set; }
        public int? RoomId { get; set; } // Foreign Key
        public Room Room { get; set; } // One-to-Many

    }
}
