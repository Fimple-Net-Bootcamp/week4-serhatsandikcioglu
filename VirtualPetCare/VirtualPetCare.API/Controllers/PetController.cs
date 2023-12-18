using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VirtualPetCare.Core.DTOs;
using VirtualPetCare.Service.Interfaces;

namespace VirtualPetCare.API.Controllers
{
    [Route("api/pets")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetController(IPetService petService)
        {
            _petService = petService;
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] string? sort, int page = 1, int size = 10)
        {
            List<PetDTO> petDTOs = _petService.GetAll(sort, page, size);
            return Ok(petDTOs);
        }
        [HttpGet("{petId}")]
        public IActionResult GetById(int petId)
        {
            bool petExist = _petService.IsExist(petId);
            if (petExist)
            {
                PetDTO petDTO = _petService.GetById(petId);
                return Ok(petDTO);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Create([FromBody] PetCreateDTO petCreateDTO)
        {
            PetDTO petDTO = _petService.Add(petCreateDTO);
            return CreatedAtAction(nameof(GetById), new { petId = petDTO.Id }, petDTO);
        }
        [HttpPut("{petId}")]
        public IActionResult Update(int petId, [FromBody] PetUpdateDTO petUpdateDTO)
        {
            bool petExist = _petService.IsExist(petId);
            if (petExist)
            {
                _petService.Update(petId , petUpdateDTO);
                return Ok();
            }
            return NotFound();
        }
    }
}
