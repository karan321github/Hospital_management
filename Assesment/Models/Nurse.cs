using System.ComponentModel.DataAnnotations.Schema;

namespace Assesment.Models
{
    public class Nurse
    {
        public int Id { get; set; }
        [ForeignKey("Employee")]
        public int EId { get; set; }
        public Employee Employee { get; set; } // One-to-One
        public ICollection<Room> Rooms { get; set; }
    }
}
