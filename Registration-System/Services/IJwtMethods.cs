using Registration_System.DTO;
using Registration_System.Models;
using System.Security.Claims;

namespace Registration_System.Services
{
    public interface IJwtMethods
    {
        public string GenerateAccessToken(User user);
        public UserRefreshToken GenerateRefreshToken(User user);
        ClaimsPrincipal? ValidateToken(string token);
    }
}
