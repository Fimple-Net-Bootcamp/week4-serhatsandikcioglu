using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using VirtualPetCare.Core.DTOs;
using VirtualPetCare.Core.Entities;
using VirtualPetCare.Service;
using VirtualPetCare.Service.Interfaces;
using VirtualPetCare.Shared.Model;

namespace VirtualPetCare.API.Controllers
{
    [Route("api/healthconditions")]
    [ApiController]
    public class HealthConditionController : CustomBaseController
    {
        private readonly IHealthConditionService _healthConditionService;

        public HealthConditionController(IHealthConditionService healthConditionService)
        {
            _healthConditionService = healthConditionService;
        }
        [HttpPatch("{petId}")]
        public async Task<ActionResult<NoContent>> Patch(int petId, [FromBody] JsonPatchDocument<HealthCondition> patchDoc)
        {
            return CreateActionResultInstance(await _healthConditionService.Patch(petId,patchDoc));
        }
        [HttpGet("{petId}")]
        public async Task<ActionResult<HealthConditionDTO>> GetById(int petId)
        {
            return CreateActionResultInstance(await _healthConditionService.GetByPetId(petId));
        }
    }
}
