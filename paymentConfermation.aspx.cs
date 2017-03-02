using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class paymentConfermation : System.Web.UI.Page
{
    Customers c;
    protected void Page_Load(object sender, EventArgs e)
    {
        c = new Customers();
        c = (Customers)Session["myCustomer"];
        string emailCustomer = c.Email;
        System.Diagnostics.Debug.WriteLine("sending mail to" + emailCustomer);
        sendEmail email = new sendEmail();
        email.booking_mail(emailCustomer);
    }
    
protected void toHome(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}