using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VirtualPetCare.Core.DTOs;
using VirtualPetCare.Service.Interfaces;

namespace VirtualPetCare.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : CustomBaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("{userId}")]
        public async Task<ActionResult<UserDTO>> GetById(int userId)
        {
            return CreateActionResultInstance(await _userService.GetById(userId));
        }
        [HttpPost]
        public async Task<ActionResult<UserDTO>> Create([FromBody] UserCreateDTO userCreateDTO)
        {
            return CreateActionResultInstance(await _userService.Add(userCreateDTO));
        }
        [HttpGet("statistics/{userId}")]
        public async Task<ActionResult<List<PetDTO>>> GetPetsById(int userId)
        {
            return CreateActionResultInstance(await _userService.GetPetsById(userId));
        }
    }
}
