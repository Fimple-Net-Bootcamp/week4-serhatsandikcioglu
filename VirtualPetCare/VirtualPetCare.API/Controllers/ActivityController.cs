using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VirtualPetCare.Core.DTOs;
using VirtualPetCare.Service;
using VirtualPetCare.Service.CustomResponse;
using VirtualPetCare.Service.Interfaces;

namespace VirtualPetCare.API.Controllers
{
    [Route("api/activities")]
    [ApiController]
    public class ActivityController : CustomBaseController
    {
        private readonly IActivityService _activityService;

        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }
        [HttpPost]
        public async Task<ActionResult<CustomResponse<ActivityDTO>>> Create([FromBody] ActivityCreateDTO activityCreateDTO)
        {
            return CreateActionResultInstance( await _activityService.Add(activityCreateDTO));
        }
        [HttpGet("{petId}")]
        public async Task<ActionResult<CustomResponse<List<ActivityDTO>>>> GetById(int petId)
        {
            return  CreateActionResultInstance( await _activityService.GetById(petId));
        }
    }
}
