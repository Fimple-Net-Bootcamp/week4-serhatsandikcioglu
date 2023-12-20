using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using VirtualPetCare.Core.DTOs;
using VirtualPetCare.Service.Interfaces;

namespace VirtualPetCare.API.Controllers
{
    [Route("api/pets")]
    [ApiController]
    public class PetController : CustomBaseController
    {
        private readonly IPetService _petService;

        public PetController(IPetService petService)
        {
            _petService = petService;
        }

        [HttpGet]
        public async Task<ActionResult<PetDTO>> GetAll([FromQuery] string? sort, int page = 1, int size = 10)
        {
            return CreateActionResultInstance(await _petService.GetAll(sort, page, size));
        }
        [HttpGet("{petId}")]
        public async Task<ActionResult<PetDTO>> GetById(int petId)
        {
            return CreateActionResultInstance(await _petService.GetById(petId,false));
        }
        [HttpGet("statistics/{petId}")]
        public async Task<ActionResult<PetDTO>> GetByIdRelational(int petId)
        {
            return CreateActionResultInstance(await _petService.GetById(petId,true));
        }
        [HttpPost]
        public async Task<ActionResult<PetDTO>> Create([FromBody] PetCreateDTO petCreateDTO)
        {
            return CreateActionResultInstance(await _petService.Add(petCreateDTO));
        }
        [HttpPut("{petId}")]
        public async Task<ActionResult<NoContent>> Update(int petId, [FromBody] PetUpdateDTO petUpdateDTO)
        {
            return CreateActionResultInstance(await _petService.Update(petId, petUpdateDTO));
        }
    }
}
