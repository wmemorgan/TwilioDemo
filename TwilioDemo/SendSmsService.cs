using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace TwilioDemo
{
    public class SendSmsService : ISendSmsService
    {
        private TwilioRestClient? _client;

        public SendSmsService(TwilioRestClient client) => _client = client;

        public async Task<MessageResource> RunSendSMSService(PhoneNumber toPhone, string messagingServiceSid, string? messageBody)
        {
            try
            {
                var messageResponse = await SendMessageAsync(CreateMessage(toPhone, messagingServiceSid, messageBody), _client);
                Console.WriteLine(messageResponse.Sid);
                return messageResponse;
            }
            catch (ApiException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine($"Twilio Error {e.Code} - {e.MoreInfo}");
                throw;
            }

        }

        protected async Task<MessageResource> SendMessageAsync(CreateMessageOptions messageOptions, TwilioRestClient? client)
        {
            return await MessageResource.CreateAsync(messageOptions, client: client);
        }

        protected CreateMessageOptions CreateMessage(PhoneNumber toPhone, string messagingServiceSid, string? messageBody)
        {
            CreateMessageOptions messageOptions = new(toPhone)
            {
                MessagingServiceSid = messagingServiceSid,
                Body = messageBody
            };

            return messageOptions;
        }
    }
}
