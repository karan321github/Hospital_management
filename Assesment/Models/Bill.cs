using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assesment.Models
{
    public class Bill
    {
        [Key]
        public int BId { get; set; }
        [ForeignKey("Patient")]
        public int  PId { get; set; }
        public decimal Amount { get; set; }
        public Patient Patient { get; set; } //One to Many
    }
}
