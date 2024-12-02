using Assesment.Interfaces;
using Assesment.ModelDto;
using Assesment.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Assesment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NurseController : Controller
    {
        private readonly INurseRepository _nurseRepository;
        private readonly IMapper _mapper;
        public NurseController(INurseRepository nurseRepository, IMapper mapper)
        {
            _mapper = mapper;
            _nurseRepository = nurseRepository;
        }
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Nurse>))]

        public IActionResult CreateNurse(NurseDto nurse)
        {
            if (nurse == null)
            {
                return BadRequest(ModelState);
            }

            var nurseAlreadyExist = _nurseRepository.CheckByName(nurse.Employee.Name);

            if (nurseAlreadyExist)
            {
                return BadRequest("Nurse already exist");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdNurse = _mapper.Map<Nurse>(nurse);
            if (!_nurseRepository.CreateNurse(createdNurse))
            {
                ModelState.AddModelError("", "Something went wrong");
                return StatusCode(500, ModelState);
            }

            return Ok("successfully created");


        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Nurse>))]

        public IActionResult GetAllNurses()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mappedAllNurses = _mapper.Map<List<NurseDto>>(_nurseRepository.GetAllNurses());

            if (mappedAllNurses == null)
            {
                return Ok("No record found");
            }

            return Ok(mappedAllNurses);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Nurse>))]

        public IActionResult GetNurseById(int Eid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isNurseExist = _nurseRepository.IsNurseExist(Eid);
            if (!isNurseExist)
            {
                return NotFound("result not found");
            }

            var mappedNurse = _mapper.Map<NurseDto>(_nurseRepository.GetNurseByEid(Eid));
            if (mappedNurse == null)
            {
                return BadRequest(ModelState);
            }
            return Ok(mappedNurse);
        }

        //[HttpDelete("{id}")]
        //[ProducesResponseType(200, Type = typeof(IEnumerable<Nurse>))]
        ////public IActionResult DeleteNurse(NurseDto nurse)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var isNurseExist = _nurseRepository.IsNurseExist(nurse.Employee.EId);
        //    if (!isNurseExist)
        //    {
        //        return NotFound("result not found");
        //    }

        //    var nurseToRemove = _nurseRepository.GetNurseByEid(nurse.Employee.EId);
        //    if (!_nurseRepository.DeleteNurse(nurseToRemove))
        //    {
        //        ModelState.AddModelError("", "Something went wrong in deleting category");

        //    }

        //    return Ok("Nurse delete successfully");

        //}

    }
}
