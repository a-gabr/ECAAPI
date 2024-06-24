using ECA.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using System.Text.RegularExpressions;
using MimeKit.Text;
using MimeKit;
using Humanizer;

namespace ECA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailingController : ControllerBase
    {
        private readonly IMailService _mailService;

        public MailingController(IMailService mailService)
        {
            _mailService = mailService;
        }
        [HttpPost("send")]
        public async Task<IActionResult> SendMail([FromForm] MailRequestDto dto)
        {            
            await _mailService.SendEmailAsync(dto.ToEmail, dto.Subject, dto.Body, dto.Attachments);
            return Ok();
        }
        [HttpPost("welcome")]
        public async Task<IActionResult> SendWelcomeEmail([FromBody] WelcomeRequestDto dto)
        {
            var filePath = $"{Directory.GetCurrentDirectory()}\\Template\\EmailTemplate.html";
            var str = new StreamReader(filePath);

            var mailText = str.ReadToEnd();
            str.Close();

            mailText = mailText.Replace("[username]", dto.UserName).Replace("[email]", dto.Email);
            
            await _mailService.SendEmailAsync(dto.Email, "Welcome to our channel", mailText);
            return Ok();
        }
    }
}
