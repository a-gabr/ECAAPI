using ECA.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService)o
        {
            _authenticationService = authenticationService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody]RegisterDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _authenticationService.RegisterAsync(model);
            if (!result.IsAuthenticated)
            {
                if (!string.IsNullOrEmpty(result.Email) && !string.IsNullOrEmpty(result.Message))
                {
                    return Ok(result.Message);
                }
                return BadRequest(result.Message);
            }
            SetRefreshTokenInCookie(result.RefreshToken, result.RefreshTokenExpiration);
            return Ok(result);
            //return Ok(new { token = result.Token, expiresOn = result.ExpiresOn });
        }
        [HttpPost("activate")]
        public async Task<IActionResult> ActivateAsync([FromBody] ActivateDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _authenticationService.ActivateAsync(model);
            if (!result.IsAuthenticated)
            {
                return BadRequest(result.Message);
            }
            SetRefreshTokenInCookie(result.RefreshToken, result.RefreshTokenExpiration);
            return Ok(result);
            //return Ok(new { token = result.Token, expiresOn = result.ExpiresOn });
        }
        [HttpPost("token")] //login
        public async Task<IActionResult> GetTokenAsync([FromBody] TokenRequestDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _authenticationService.GetTokenAsync(model);
            if (!result.IsAuthenticated)
            {
                return BadRequest(result.Message);
            }
            if(!string.IsNullOrEmpty(result.RefreshToken))
            {
                SetRefreshTokenInCookie(result.RefreshToken, result.RefreshTokenExpiration);
            }
            return Ok(result);
            //return Ok(new { token = result.Token, expiresOn = result.ExpiresOn });
        }

        [HttpPost("addrole")]
        [Authorize(Roles ="PASSENGER-MANAGER")]
        public async Task<IActionResult> AddRoleAsync([FromBody] AddRoleDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _authenticationService.AddRoleAsync(model);
            if (!string.IsNullOrEmpty(result))
            {
                return BadRequest(result);
            }
            return Ok(model);
        }
        [HttpGet("refreshToken")]
        public async Task<IActionResult> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];

            var result = await _authenticationService.RefreshTokenAsync(refreshToken);

            if (!result.IsAuthenticated)
                return BadRequest(result);

            SetRefreshTokenInCookie(result.RefreshToken, result.RefreshTokenExpiration);

            return Ok(result);
        }
        [HttpPost("revokeToken")]
        public async Task<IActionResult> RevokeToken([FromBody] RevokeToken model)
        {
            var token = model.Token ?? Request.Cookies["refreshToken"];

            if (string.IsNullOrEmpty(token))
                return BadRequest("Token is required!");

            var result = await _authenticationService.RevokeTokenAsync(token);

            if (!result)
                return BadRequest("Token is invalid!");

            return Ok();
        }
        private void SetRefreshTokenInCookie(string refreshToken, DateTime expires)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = expires.ToLocalTime(),
                Secure = true,
                IsEssential = true,
                SameSite = SameSiteMode.None
            };

            Response.Cookies.Append("refreshToken", refreshToken, cookieOptions);
        }
    }
}
