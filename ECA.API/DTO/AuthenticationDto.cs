using System.Text.Json.Serialization;

namespace ECA.API.DTO
{
    public class AuthenticationDto
    {
        public string Message { get; set; }
        public bool IsAuthenticated { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Mobile { get; set; }
        public List<string> Roles { get; set; }
        public string Token { get; set; }
        public DateTime ExpiresOn { get; set; } // 3shan el RefreshToken

        [JsonIgnore] // kda el property de msh htrg3 fel response
        public string? RefreshToken { get; set; }

        public DateTime RefreshTokenExpiration { get; set; }
    }
}
