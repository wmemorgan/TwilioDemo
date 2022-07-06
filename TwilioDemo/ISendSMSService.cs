using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace TwilioDemo
{
    public interface ISendSMSService
    {
        Task<MessageResource> RunSendSMSService(PhoneNumber toPhone, string messagingServiceSid, string? messageBody);
    }
}