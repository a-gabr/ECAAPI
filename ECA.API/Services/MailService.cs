
using ECA.API.Helper;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using NuGet.Protocol.Plugins;
using System.Net.Mail;
using System.Net;
using SmtpClient = System.Net.Mail.SmtpClient;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using MimeKit.Text;

namespace ECA.API.Services
{
    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;
        public MailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }
        public string GenerateOtp()
        {
            var allChar = "0123456789";//"abcdefghijklmnopqrstuvxyz0123456789";
            var random = new Random();
            var resultToken = new string(Enumerable.Repeat(allChar, 6)
                .Select(token => token[random.Next(token.Length)]).ToArray());
            return resultToken.ToString();
        }

        public async Task SendEmailAsync(string mailTo, string subject, string body, IList<IFormFile> attachments = null)
        {
            var email = new MimeMessage
            {
                Sender = MailboxAddress.Parse(_mailSettings.Email),
                Subject = subject
            };

            email.To.Add(MailboxAddress.Parse(mailTo));

            var builder = new BodyBuilder();

            if (attachments != null)
            {
                byte[] fileBytes;
                foreach (var file in attachments)
                {
                    if (file.Length > 0)
                    {
                        using var ms = new MemoryStream();
                        file.CopyTo(ms);
                        fileBytes = ms.ToArray();

                        builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                    }
                }
            }

            builder.HtmlBody = body;
            email.Body = builder.ToMessageBody();
            email.From.Add(new MailboxAddress(_mailSettings.DisplayName, _mailSettings.Email));

            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            smtp.ServerCertificateValidationCallback = (s, c, h, e) => true;
            smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.Email, _mailSettings.Password);
            await smtp.SendAsync(email);

            smtp.Disconnect(true);
        }
        public async Task SendFromCustomsMailAsync(string mailTo, string subject, string body, IList<IFormFile> attachments = null)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient client = new SmtpClient();
                message.From = new MailAddress(_mailSettings.Email, _mailSettings.DisplayName);
                message.To.Add(mailTo);
                message.Subject = subject;
                message.Body = "Sender Name: Ahmed";
                message.Body += "Sender Email: d.elghitany@customs.gov.eg";
                message.Body += "Subject: Important";
                message.Body += "Message: test message";
                client.Host = "mail.customs.gov.eg";
                client.Port = 587;
                client.EnableSsl = false;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential(_mailSettings.Email, _mailSettings.Password);
                client.Timeout = 50000;
                client.Send(message);
                message.Dispose();
            }
            catch (Exception ex) { }
            
            //var email = new MimeMessage
            //{
            //    Sender = MailboxAddress.Parse(_mailSettings.Email),
            //    Subject = subject
            //};

            //email.To.Add(MailboxAddress.Parse(mailTo));

            //var builder = new BodyBuilder();

            //if (attachments != null)
            //{
            //    byte[] fileBytes;
            //    foreach (var file in attachments)
            //    {
            //        if (file.Length > 0)
            //        {
            //            using var ms = new MemoryStream();
            //            file.CopyTo(ms);
            //            fileBytes = ms.ToArray();

            //            builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
            //        }
            //    }
            //}

            //builder.HtmlBody = body;
            //email.Body = builder.ToMessageBody();
            //email.From.Add(new MailboxAddress(_mailSettings.DisplayName, _mailSettings.Email));

            //using var smtp = new MailKit.Net.Smtp.SmtpClient();
            ////smtp.ServerCertificateValidationCallback = (s, c, h, e) => true;
            //smtp.Connect(_mailSettings.Host, _mailSettings.Port,false);
            //smtp.Timeout = 50000;
            ////smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            ////smtp.Authenticate(_mailSettings.Email, _mailSettings.Password);
            //await smtp.SendAsync(email);

            //smtp.Disconnect(true);          
        }
    }
}
