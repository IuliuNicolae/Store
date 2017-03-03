using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

public partial class smstest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Unnamed_Click(object sender, EventArgs e)
    {
        var accountSid = "AC0fe67581460dac474a520d18faed3d1a";
        var authToken = "796260fdb69a948b6305e95d862fd7bf";
        var twilionumber = "+46769449597";
        TwilioClient.Init(accountSid, authToken);
        MessageResource.Create(
                    from: new PhoneNumber(twilionumber), // From number, must be an SMS-enabled Twilio number
                    to: new PhoneNumber("+46705408915"), // To number, if using Sandbox see note above
                                                     // Message content
                    body: "Hey {person.Value} Monkey Party at 6PM. Bring Bananas!");
    }
}