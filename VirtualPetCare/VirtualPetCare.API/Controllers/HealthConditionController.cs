using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using VirtualPetCare.Core.DTOs;
using VirtualPetCare.Core.Entities;
using VirtualPetCare.Service;
using VirtualPetCare.Service.Interfaces;

namespace VirtualPetCare.API.Controllers
{
    [Route("api/healthconditions")]
    [ApiController]
    public class HealthConditionController : ControllerBase
    {
        private readonly IHealthConditionService _healthConditionService;

        public HealthConditionController(IHealthConditionService healthConditionService)
        {
            _healthConditionService = healthConditionService;
        }
        [HttpPatch("{petId}")]
        public IActionResult Patch(int petId, [FromBody] JsonPatchDocument<HealthCondition> patchDoc)
        {
            HealthConditionDTO healthConditionDTO = _healthConditionService.GetById(petId);
            if (healthConditionDTO != null)
            {
                _healthConditionService.Patch(petId, patchDoc);
                return Ok();
            }
            return NotFound();
        }
        [HttpGet("{petId}")]
        public IActionResult GetById(int petId)
        {
            HealthConditionDTO healthConditionDTO = _healthConditionService.GetById(petId);
            if (healthConditionDTO != null)
            {
            return Ok(healthConditionDTO);

            }
            return NotFound();
        }
    }
}
