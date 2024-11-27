using Assesment.Interfaces;
using Assesment.ModelDto;
using Assesment.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Assesment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ILogger<PatientController> _logger;
        private readonly IPatientRepository _patientRepository;

        public PatientController(ILogger<PatientController> logger, IPatientRepository patientRepository, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _patientRepository = patientRepository;
        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Patient>))]
        public IActionResult GetAllPatients()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var patients = _mapper.Map<List<PatientDto>>(_patientRepository.GetPatients());
            return Ok(patients);
        }
        [HttpGet("{patientId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Patient>))]
        [ProducesResponseType(400)]
        public IActionResult GetPatient(int id)
        {
            var isPatientExist = _patientRepository.isPatientExist(id);
            var patient = _mapper.Map<PatientDto>(_patientRepository.GetPatient(id));
            if(!isPatientExist)
            {
                return NotFound();
            }
            return Ok(patient);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]

        public IActionResult CreatePatient([FromBody] PatientDto patient)
        {
            if (patient == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var patientMap = _mapper.Map<Patient>(patient);

            if (!_patientRepository.CreatePatient(patientMap))
            {
                ModelState.AddModelError("", "Something went wrong");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }


    }
}
