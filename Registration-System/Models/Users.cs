using System.Diagnostics.CodeAnalysis;

namespace Registration_System.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty; 
        public string PasswordHash { get; set; } = string.Empty;
        public string PhoneNumber {  get; set; } = string.Empty;
        public Role Role { get; set; } = Role.User;
        public DateTime AccountCreatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<UserRefreshToken> RefreshTokens { get; set; }
        = new List<UserRefreshToken>();
    }

    public enum Role
    {
        User,
        Admin
    }
}
