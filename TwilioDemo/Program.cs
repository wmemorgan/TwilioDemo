// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.Configuration;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

class Program
{
    static void Main(string[] args)
    {
        var builder = new ConfigurationBuilder()
            .AddJsonFile("local.settings.json")
            .AddUserSecrets<Program>();
        var configuration = builder.Build();

        Console.WriteLine("Enter SMS message");
        string? smsMessage = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(smsMessage))
        {
            Console.WriteLine("Missing content. Please enter SMS message.");
            smsMessage = Console.ReadLine();
        }

        SendSMS(
            configuration.GetSection("TWILIO_ACCOUNT_SID").Value,
            configuration.GetSection("TWILIO_AUTH_TOKEN").Value,
            configuration.GetSection("Phone:From").Value,
            configuration.GetSection("Phone:To").Value,
            smsMessage
            ).Wait();

        Console.ReadKey();
    }

    static async Task SendSMS(
        string accountSid,
        string authToken,
        string fromPhone,
        string toPhone,
        string messageBody
        )
    {
        Console.WriteLine($"TWILIO_ACCOUNT_SID: {accountSid}");
        Console.WriteLine($"TWILIO_AUTH_TOKEN: {authToken}");
        Console.WriteLine($"FROM PHONE: {fromPhone}");
        Console.WriteLine($"TO PHONE: {toPhone}");
        Console.WriteLine($"MESSAGE BODY: {messageBody}");

        TwilioClient.Init(accountSid, authToken);

        var message = await MessageResource.CreateAsync(
            body: messageBody,
            from: new PhoneNumber(fromPhone),
            to: new PhoneNumber(toPhone)
        );

        Console.WriteLine(message.Sid);
    }
}


