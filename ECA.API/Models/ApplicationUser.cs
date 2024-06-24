using Microsoft.AspNetCore.Identity;

namespace ECA.API.Models
{
    public class ApplicationUser :IdentityUser
    {
        public decimal? ComputerUserId { get; set; }
        public string UserOTP { get; set; }
        public bool? UserActive { get; set; }
        public string UserMobile { get; set; }
        public List<RefreshToken>? RefreshTokens { get; set; }

    }
}
