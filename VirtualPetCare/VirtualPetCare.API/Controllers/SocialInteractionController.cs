using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VirtualPetCare.Core.DTOs;
using VirtualPetCare.Service.Interfaces;

namespace VirtualPetCare.API.Controllers
{
    [Route("api/socialInteraction")]
    [ApiController]
    public class SocialInteractionController : CustomBaseController
    {
        private readonly ISocialInteractionService _socialInteractionService;

        public SocialInteractionController(ISocialInteractionService socialInteractionService)
        {
            _socialInteractionService = socialInteractionService;
        }
        [HttpGet("{petId}")]
        public async Task<ActionResult<List<SocialInteractionDTO>>> GetAllByPetId(int petId)
        {
            return CreateActionResultInstance(await _socialInteractionService.GetAllByPetId(petId));
        }
        [HttpPost]
        public async Task<ActionResult<SocialInteractionDTO>> Create(SocialInteractionCreateDTO socialInteractionCreateDTO)
        {
            return CreateActionResultInstance(await _socialInteractionService.Create(socialInteractionCreateDTO));
        }
    }
}
