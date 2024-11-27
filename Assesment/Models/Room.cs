using System.ComponentModel.DataAnnotations;

namespace Assesment.Models
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }
        public string Type { get; set; }    
        public int Capactiy { get; set; }
        public bool Availability { get; set; }    

        public ICollection<Patient> Patients { get; set; } //One-to-Many
        public ICollection<Nurse> Nurses { get; set; } // Many-to-Many
    }
}
