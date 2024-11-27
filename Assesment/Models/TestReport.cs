using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assesment.Models
{
    public class TestReport
    {
        [Key]
        public int ReportId { get; set; }

        [ForeignKey("Patient")]
        public int PId { get; set; }
        public Patient Patient { get; set; }
        public string TestType { get; set; }
        public string Result { get; set; }
    }
}
