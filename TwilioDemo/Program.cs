// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.Configuration;
using Twilio.Clients;

namespace TwilioDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("local.settings.json")
                .AddUserSecrets<Program>();
            var configuration = builder.Build();

            TwilioRestClient client = new(
                 configuration.GetSection("TWILIO_ACCOUNT_SID").Value,
                 configuration.GetSection("TWILIO_AUTH_TOKEN").Value);

            SendSMSService smsService = new(client);

            Console.WriteLine("Enter SMS message");
            string? smsMessage = Console.ReadLine();

            smsService.RunSendSMSService(
                configuration.GetSection("Phone:To").Value,
                configuration.GetSection("MessagingServiceSid").Value,
                smsMessage
                ).Wait();

            Console.Write("Press any key to continue.");
            Console.ReadKey();
        }
    }
}



