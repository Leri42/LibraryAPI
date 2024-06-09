using Application.Services;
using Application.UserService.LoginUser;
using Application.UserService.RegisterUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUserService _userService;
        public UsersController(IMediator mediator, IUserService userService)
        {
            _mediator = mediator;
            _userService = userService;
        }

        [HttpPost("register")]
        [Authorize(Roles = "SuperUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand model)
        {
            var command = new RegisterUserCommand { Email = model.Email, Password = model.Password };
            var result = await _mediator.Send(command);

            if (result.Succeeded)
            {
                return Ok(result);
            }
            return BadRequest(result.Errors);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand model)
        {
            var command = new LoginUserCommand { Email = model.Email, Password = model.Password };
            var token = await _mediator.Send(command);

            if (token != null)
            {
                return Ok(new { Token = token });
            }
            return BadRequest("Invalid login attempt.");
        }

        [HttpPost("logout")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Logout()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                return BadRequest("User not found.");
            }

            var result = await _userService.LogoutUserAsync(userId);

            if (result.Succeeded)
            {
                return Ok("Logout successful.");
            }

            return BadRequest("Logout failed.");
        }
    }
}
