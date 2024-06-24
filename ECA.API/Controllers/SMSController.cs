using ECA.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SMSController : ControllerBase
    {
        private readonly ISMSService _smsService;

        public SMSController(ISMSService smsService)
        {
            _smsService = smsService;
        }

        [HttpPost("send")]
        public IActionResult Send(SendSMSDto dto)
        {
            var result = _smsService.Send(dto.MobileNumber, dto.Body);
            if (!string.IsNullOrEmpty(result.ErrorMessage))
            {
                return BadRequest(result.ErrorMessage);
            }
            return Ok(result);
        }

    }
}
