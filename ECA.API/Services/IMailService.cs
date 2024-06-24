namespace ECA.API.Services
{
    public interface IMailService
    {
        string GenerateOtp();
        Task SendEmailAsync(string mailTo, string subject, string body, IList<IFormFile> attachments = null);
        Task SendFromCustomsMailAsync(string mailTo, string subject, string body, IList<IFormFile> attachments = null);
    }
}
