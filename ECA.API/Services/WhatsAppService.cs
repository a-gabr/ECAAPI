using ECA.API.Helper;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace ECA.API.Services
{
    public class WhatsAppService : IWhatsAppService
    {
        private readonly TwilioSettings _twilio;

        public WhatsAppService(IOptions<TwilioSettings> twilio)
        {
            _twilio = twilio.Value;
        }

        public MessageResource Send(string mobileNumber, string body)
        {
            TwilioClient.Init(_twilio.AccountSID, _twilio.AuthToken);
            var messageOptions = new CreateMessageOptions(new PhoneNumber("whatsapp:+"+mobileNumber));
            messageOptions.From = new PhoneNumber("whatsapp:"+_twilio.TwilioWhatsAppNumber);
            messageOptions.Body = body;
            var result = MessageResource.Create(messageOptions);





            
            return result;
        }
    }
}
