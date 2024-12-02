using Assesment.Interfaces;
using Assesment.ModelDto;
using Assesment.Models;
using Assesment.Respositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Assesment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmplyeeController : Controller
    {
        private IEmployeeRespository _employeeRespository;
        private IMapper _mapper;
        public EmplyeeController(IEmployeeRespository employeeRepository, IMapper mapper)
        {
            _employeeRespository = employeeRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Employee>))]
        public IActionResult GetAllEmployees()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var emplyees = _mapper.Map<List<EmployeeDto>>(_employeeRespository.GetEmployees());
            return Ok(emplyees);
        }

        [HttpGet("{employeeId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Employee>))]
        [ProducesResponseType(400)]
        public IActionResult GetEmployee(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var emplyeeExist = _employeeRespository.isEmployeeExist(id);
            var employeeMap = _mapper.Map<EmployeeDto>(_employeeRespository.GetEmployeeById(id));
            if (!emplyeeExist)
            {
                return NotFound();
            }
            return Ok(employeeMap);
        }
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Employee>))]
        [ProducesResponseType(400)]
        public IActionResult CreateEmplyee([FromBody] EmployeeDto employee)
        {
            if (employee == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employeeMap = _mapper.Map<Employee>(employee);
            if (!_employeeRespository.CreateEmplyee(employeeMap))
            {
                ModelState.AddModelError("", "Something went wrong");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully created");
        }

        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult DeleteEmplyee(int employeeId)
        {
            if (!_employeeRespository.isEmployeeExist(employeeId))
            {
                NotFound();
            }
            var deletedEmplyee = _employeeRespository.GetEmployeeById(employeeId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_employeeRespository.DeleteEmplyee(deletedEmplyee))
            {
                ModelState.AddModelError("", "Something went wrong");
                return StatusCode(500, ModelState);
            }
            return Ok("Deleted successfully");
        }

    }
}
