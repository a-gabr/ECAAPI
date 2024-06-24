namespace ECA.API.Services
{
    public interface IAuthenticationService
    {
        Task<AuthenticationDto> ActivateAsync(ActivateDto model);
        Task<AuthenticationDto> RegisterAsync(RegisterDto model);
        Task<AuthenticationDto> GetTokenAsync(TokenRequestDto model);
        Task<string> AddRoleAsync(AddRoleDto model);
        Task<AuthenticationDto> RefreshTokenAsync(string token);
        Task<bool> RevokeTokenAsync(string token);
    }
}
