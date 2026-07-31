namespace Registration_System.Models
{
    public class UserRefreshToken
    {
        public int Id { get; set; }

        public string RefreshToken { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime ExpiresAt { get; set; }

        public bool IsRevoked { get; set; }

        public int UserId { get; set; }

        public User? User { get; set; }
    }
}
