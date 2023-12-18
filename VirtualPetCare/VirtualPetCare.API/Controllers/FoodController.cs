using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VirtualPetCare.Core.DTOs;
using VirtualPetCare.Service;
using VirtualPetCare.Service.Interfaces;

namespace VirtualPetCare.API.Controllers
{
    [Route("api/foods")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IFoodService _foodService;
        private readonly IPetService _petService;

        public FoodController(IFoodService foodService, IPetService petService)
        {
            _foodService = foodService;
            _petService = petService;
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] string? sort, int page = 1, int size = 10)
        {
            List<FoodDTO> foodDTOs = _foodService.GetAll(sort, page, size);
            return Ok(foodDTOs);
        }
        [HttpPost("{petId}")]
        public IActionResult Create(int petId, [FromBody] FoodCreateDTO foodCreateDTO)
        {
            bool petExist = _petService.IsExist(petId);
            if (petExist)
            {
            FoodDTO foodDTO = _foodService.Add(petId ,foodCreateDTO);
            return StatusCode(201,foodDTO);
            }
            return NotFound();
        }
    }
}
