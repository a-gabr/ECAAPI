using Twilio.Rest.Api.V2010.Account;
namespace ECA.API.Services
{
    public interface IWhatsAppService
    {
        MessageResource Send(string mobileNumber, string body);
    }
}
