using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Clients;

/// <summary>
/// Summary description for sms
/// </summary>
public class sms
{
    TwilioRestClient twilio;
    public void sendSMS()
    {
        // Your Account SID from twilio.com/console
        var accountSid = "AC676beff501968449ad15264e3725b8ee";
        // Your Auth Token from twilio.com/console
        var authToken = "9de765d60758145d1c45b9bb50db6629";
        TwilioClient.Init(accountSid, authToken);
        twilio = new TwilioRestClient(accountSid, authToken);
        twilio.SendMessage("+1YYYYYYYYYY","+1ZZZZZZZZZZ","Hey, Monkey Party at 6PM.Bring Bananas!");

    }
}