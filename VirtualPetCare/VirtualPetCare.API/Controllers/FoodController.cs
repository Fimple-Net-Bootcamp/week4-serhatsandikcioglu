using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VirtualPetCare.Core.DTOs;
using VirtualPetCare.Service;
using VirtualPetCare.Service.Interfaces;
using VirtualPetCare.Shared.Model;

namespace VirtualPetCare.API.Controllers
{
    [Route("api/foods")]
    [ApiController]
    public class FoodController : CustomBaseController
    {
        private readonly IFoodService _foodService;

        public FoodController(IFoodService foodService)
        {
            _foodService = foodService;
        }

        [HttpGet]
        public async Task<ActionResult<CustomResponse<FoodDTO>>> GetAll([FromQuery] string? sort, int page = 1, int size = 10)
        {
            return CreateActionResultInstance(await _foodService.GetAll(sort,page,size));
        }
        [HttpPost("{petId}")]
        public async Task<ActionResult<CustomResponse<FoodDTO>>> Create(int petId, [FromBody] FoodCreateDTO foodCreateDTO)
        {

            return CreateActionResultInstance(await _foodService.Add(petId,foodCreateDTO));
        }
    }
}
