using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Assesment.Models;

namespace Assesment.ModelDto
{
    public class DoctorDto
    {
       
        public EmployeeDto Employee { get; set; }

        [Required(ErrorMessage = "Department is required.")]
        public string Department { get; set; }

        [Required(ErrorMessage = "Qualification is required.")]
        public string Qualification { get; set; }
    }
}
