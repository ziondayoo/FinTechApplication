using FinTechApplication.Models;
using FinTechApplication.Models.DTO;
using FinTechApplication.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FinTechApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Signup([FromBody] SignUpRequestDTO signupRequest)
        {
            // Validate the signup request
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Create a new user
            var user = new AppUser()
            {

                //Name = signupRequest.Name,
                //EmailAddress = signupRequest.EmailAddress,

            };

            // Save the new user to the database
            await _userService.CreateUserAsync(user);

            // Return a response indicating that the user was created successfully
            return Ok();
        }
    }
}
