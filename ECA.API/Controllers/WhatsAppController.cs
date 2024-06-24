using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Twilio;
using Twilio.Types;
using Twilio.Rest.Api.V2010.Account;
using ECA.API.Services;
namespace ECA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhatsAppController : ControllerBase
    {
        private readonly IWhatsAppService _whatsAppService;

        public WhatsAppController(IWhatsAppService whatsAppService)
        {
            _whatsAppService = whatsAppService;
        }

        [HttpPost("send")]
        public IActionResult Send(SendSMSDto dto)
        {
            var result = _whatsAppService.Send(dto.MobileNumber, dto.Body);
            if (!string.IsNullOrEmpty(result.ErrorMessage))
            {
                return BadRequest(result.ErrorMessage);
            }
            return Ok(result);
        }

    }
}
