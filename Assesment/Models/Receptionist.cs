using System.ComponentModel.DataAnnotations.Schema;

namespace Assesment.Models
{
    public class Receptionist
    {
        public int Id { get; set; }
        [ForeignKey("Employee")]
        public int EId { get; set; }

        public Employee Employee { get; set; }
        public ICollection<Record> Records { get; set; } // Many-to-Many
    }
}
