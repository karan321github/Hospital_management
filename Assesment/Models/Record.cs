using System.ComponentModel.DataAnnotations;

namespace Assesment.Models
{
    public class Record
    {
        [Key] 
        public int RecordNo { get; set; } // Primary Key
        public int AppNo { get; set; } // Unique appointment number

        // Navigation Properties
        public ICollection<Receptionist> Receptionists { get; set; } // Many-to-Many
    }
}
