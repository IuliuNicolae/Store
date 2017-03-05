
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

/// <summary>
/// Summary description for sms
/// </summary>
public class sms
{
    public void Sendsms(string toNumber,string message)
    {
        var accountSid = "AC0fe67581460dac474a520d18faed3d1a";// id från twilio
        var authToken = "796260fdb69a948b6305e95d862fd7bf";
        var twilionumber = "+46769449597";
        TwilioClient.Init(accountSid, authToken);
       MessageResource.Create(
                    from: new PhoneNumber(twilionumber), // From number, must be an SMS-enabled Twilio number
                    to: new PhoneNumber(toNumber), // To number, if using Sandbox see note above
                                                         // Message content
                    body: message);
    }
}
