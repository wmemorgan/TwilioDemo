// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.Configuration;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

class Program
{
    static void Main(string[] args)
    {
        var builder = new ConfigurationBuilder().AddUserSecrets<Program>();
        var configuration = builder.Build();

        var accountSid = configuration.GetSection("TWILIO_ACCOUNT_SID").Value;
        var authToken = configuration.GetSection("TWILIO_AUTH_TOKEN").Value;
        Console.WriteLine($"TWILIO_ACCOUNT_SID: {accountSid}");
        Console.WriteLine($"TWILIO_AUTH_TOKEN: {authToken}");
        //string authToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");

        //TwilioClient.Init(accountSid, authToken);

        //var message = MessageResource.Create(
        //    body: "This is the ship that made the Kessel Run in fourteen parsecs?",
        //    from: new Twilio.Types.PhoneNumber("+15017122661"),
        //    to: new Twilio.Types.PhoneNumber("+15558675310")
        //);

        //Console.WriteLine(message.Sid);
    }
}


