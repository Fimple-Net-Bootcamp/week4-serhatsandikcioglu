using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VirtualPetCare.Core.DTOs;
using VirtualPetCare.Service.Interfaces;

namespace VirtualPetCare.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("{userId}")]
        public IActionResult GetById(int userId)
        {
            var user = _userService.GetById(userId);
            if (user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Create([FromBody] UserCreateDTO userCreateDTO)
        {
            UserDTO userDTO = _userService.Add(userCreateDTO);
            return CreatedAtAction(nameof(GetById), new { userId = userDTO.Id }, userDTO);
        }
    }
}
