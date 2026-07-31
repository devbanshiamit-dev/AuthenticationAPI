using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Registration_System.DTO;
using Registration_System.Services;
using System.Security.Claims;

namespace Registration_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService _authService;

        public AuthController(IAuthenticationService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")] 
        public async Task<IActionResult> Register(RequestDTO dto)
        {
            var result = await _authService.RegisterAsync(dto);

            if (result == null)
                return BadRequest("Email already exists.");

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            var result = await _authService.LoginAsync(dto);

            if (result == null)
                return Unauthorized("Invalid email or password.");

            return Ok(result);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh(RefreshTokenDTO dto)
        {
            var result = await _authService.NewTokensAsync(dto.RefreshToken);

            if (result == null)
                return Unauthorized("Invalid refresh token.");

            return Ok(result);
        }

        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout(RefreshTokenDTO dto)
        {
            var result = await _authService.LogOutAsync(dto.RefreshToken);

            if (!result)
                return BadRequest("Refresh token not found.");

            return Ok("Logged out successfully.");
        }

        [Authorize]
        [HttpPost("logout-all")]
        public async Task<IActionResult> LogoutAll()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            await _authService.LogOutFromAllAsync(userId);

            return Ok("Logged out from all devices.");
        }

        [Authorize]
        [HttpGet("me")]
        public IActionResult Me() 
        {
            return Ok(new
            {
                UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value,
                UserName = User.FindFirst(ClaimTypes.Name)?.Value,
                Email = User.FindFirst(ClaimTypes.Email)?.Value,
                Role = User.FindFirst(ClaimTypes.Role)?.Value
            });
        }

        [Authorize]
        [HttpPost("change-password")]
        public async Task<IActionResult> PasswordChange(ChangePasswordDTO dto)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            await _authService.ChangePasswordAsync(dto, userId);

            return Ok("Password Changed");
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Remove()
        {
            var userid = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            await _authService.RemoveAsync(userid);

            return NoContent();
        }
    }
}