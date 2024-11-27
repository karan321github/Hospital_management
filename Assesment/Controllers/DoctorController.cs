using Assesment.Interfaces;
using Assesment.ModelDto;
using Assesment.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Assesment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DoctorController : Controller
    {
        private IDoctorRepository _doctorRepository;
        private IEmployeeRespository _employeeRepository;
        private IMapper _mapper;
        public DoctorController(IDoctorRepository doctorRepository, IEmployeeRespository employeeRespository, IMapper mapper)
        {
            _employeeRepository = employeeRespository;
            _doctorRepository = doctorRepository;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Doctor>))]
        [ProducesResponseType(400)]

        public IActionResult GetDoctor(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var doctorExist = _doctorRepository.isDoctorExist(id);
            if (!doctorExist)
            {
                return NotFound();
            }

            var doctorMap = _mapper.Map<DoctorDto>(_doctorRepository.GetDoctor(id));
            return Ok(doctorMap);


        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Doctor>))]
        public IActionResult GetDoctors()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var doctors = _mapper.Map<List<DoctorDto>>(_doctorRepository.GetDoctors());
            if (doctors == null)
            {
                return Ok("No record found");
            }

            return Ok(doctors);
        }
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Doctor>))]
        [ProducesResponseType(400)]

        public async Task<IActionResult> CreateDoctor([FromBody] DoctorDto doctorCreate)
        {
            if (doctorCreate == null)
            {
                return BadRequest("Invalid doctor data");
            }
          
            var newEmployee = new Employee
            {
                Name = doctorCreate.Employee.Name,
                Salary = doctorCreate.Employee.Salary,
                Gender = doctorCreate.Employee.Gender,
                Address = doctorCreate.Employee.Address,
                ContactNumber = doctorCreate.Employee.ContactNumber,
                State = doctorCreate.Employee.State,
                City = doctorCreate.Employee.City,
                Employee_code = doctorCreate.Employee.Employee_code
            };

            var newDoctor = new Doctor
            {
                EId = doctorCreate.Employee.EId,
                Qualification = doctorCreate.Qualification,
                Department = doctorCreate.Department
            };
            newDoctor.Employee = newEmployee;
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mapDoctor = _mapper.Map<Doctor>(doctorCreate);
            if (mapDoctor == null)
            {
                return BadRequest(ModelState);
            }
            if (!_doctorRepository.CreateDoctor(mapDoctor))
            {
                return BadRequest("Something went wrong");
            }
            return Ok("succesfully created");


        }
    }
}
