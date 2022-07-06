using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace TwilioDemo
{
    public interface ISendSmsService
    {
        Task<MessageResource> RunSendSMSService(PhoneNumber toPhone, string messagingServiceSid, string? messageBody);
    }
}