using FinTechApplication.Infrastructure.Security;
using FinTechApplication.Infrastructure.Settings;
using FinTechApplication.Models;
using FinTechApplication.Models.DTO;
using FinTechApplication.Services.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FinTechApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IAuthService _authService;
        private readonly IOptions<JWTData> _JWTData;
        private readonly UserManager<AppUser> _userManager;

        public AuthController(IAuthService authService, IOptions<JWTData> options, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
            _authService = authService;
            _JWTData = options;
            _userManager = userManager;
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO userDTO)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var user = await _authService.ValidateUser(userDTO);
                if (user == null)
                {
                    return Unauthorized();
                }
                var userRoles = await _userManager.GetRolesAsync(user) as List<string>;
                return Ok(new { Token = JWTService.GenerateToken(user, userRoles, _JWTData) });
            }
            catch (Exception ex)
            {

                return Problem($"Something Went Wrong in the {nameof(Login)}", statusCode: 500);
            }
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            HttpContext.Session.Clear();
            return Ok();
        }


    }
}
