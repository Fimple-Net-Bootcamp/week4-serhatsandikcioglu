using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VirtualPetCare.Core.DTOs;
using VirtualPetCare.Service.Interfaces;

namespace VirtualPetCare.API.Controllers
{
    [Route("api/trainings")]
    [ApiController]
    public class TrainingController : CustomBaseController
    {
        private readonly ITrainingService _trainingService;

        public TrainingController(ITrainingService trainingService)
        {
            _trainingService = trainingService;
        }
        [HttpGet("{petId}")]
        public async Task<ActionResult<List<TrainingDTO>>> GetAllByPetId(int petId)
        {
            return CreateActionResultInstance( await _trainingService.GetAllByPetId(petId));
        }
        [HttpPost]
        public async Task<ActionResult<TrainingDTO>> Create(TrainingCreateDTO trainingCreateDTO)
        {
            return CreateActionResultInstance(await _trainingService.Add(trainingCreateDTO));
        }
    }
}
