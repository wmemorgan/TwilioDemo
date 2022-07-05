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

        var accountSid = configuration.GetSection("TWILIO_ACCOUNT_SID").Value;
        var authToken = configuration.GetSection("TWILIO_AUTH_TOKEN").Value;
        Console.WriteLine($"TWILIO_ACCOUNT_SID: {accountSid}");
        Console.WriteLine($"TWILIO_AUTH_TOKEN: {authToken}");

        var fromPhone = configuration.GetSection("Phone:From").Value;
        var toPhone = configuration.GetSection("Phone:To").Value;
        Console.WriteLine($"FROM PHONE: {fromPhone}");
        Console.WriteLine($"TO PHONE: {toPhone}");

        TwilioClient.Init(accountSid, authToken);

        var message = MessageResource.Create(
            body: "This is the ship that made the Kessel Run in fourteen parsecs?",
            from: new PhoneNumber(fromPhone),
            to: new PhoneNumber(toPhone)
        );

        Console.WriteLine(message.Sid);
    }
}


