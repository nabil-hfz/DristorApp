using System;
using System.Security.Claims;
using DristorApp.Data.DTOs.User;
using DristorApp.Data.Models;
using DristorApp.Repositories.UserRepository;
using DristorApp.UserManagementService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DristorApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserManagementService _userService;
        private readonly IUserRepository _userRepository;
        public AccountsController(
            UserManager<User> userManager,
            IUserManagementService userService,
            IUserRepository userRepository)
        {
            _userManager = userManager;
            _userService = userService;
            _userRepository = userRepository;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterUserDTO dto)
        {

            var user = await _userManager.FindByEmailAsync(dto.Email);

            if (user is not null)
            {
                return BadRequest("This email already in use");
            }

            var result = await _userService.RegisterUserAsync(dto);
            if (result.Succeeded)
            {

                return Ok(result);
            }
            return BadRequest(result.Errors.ToList());
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginUserDTO dto)
        {
            var token = await _userService.LoginUserAsync(dto);

            if (token is null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
        [HttpGet("me")]
        [Authorize]
        public async Task<ActionResult<UserDTO>> GetCurrentUser()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userRepository.GetByIdAsync(int.Parse(id));
            if (user is null)
            {
                return NotFound();
            }

            return new UserDTO
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Roles = user.Roles.Select(x => x.Name).ToList(),
                //Addresses = user.Addresses.Select(x => x.Id).ToList()
            };
        }
    }
}

