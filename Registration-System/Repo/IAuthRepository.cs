using Registration_System.Models;

namespace Registration_System.Repo
{
    public interface IAuthRepository
    {
        Task<User?> GetUserByEmailAsync(string email);
        Task<User?> GetUserByIdAsync(int Id);
        Task<List<UserRefreshToken>> GetRefreshTokensByUserIdAsync(int Id);
        Task<UserRefreshToken?> GetRefreshTokenAsync(string refreshToken);
        Task<User> AddUserAsync(User user);
        Task AddRefreshTokenAsync(UserRefreshToken RF);
        Task RemoveRefreshTokenAsync(UserRefreshToken token);
        Task RevokeAllRefreshTokensAsync(int UserId);
        Task RemoveUserAsync(User user);
        Task UpdateAsync(User user);
    }
}