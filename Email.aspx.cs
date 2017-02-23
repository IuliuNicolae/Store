using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Email : System.Web.UI.Page
{
    Customers c = new Customers();
    protected void Page_Load(object sender, EventArgs e)
    {
        c = (Customers)Session["myCustomer"];
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        MailMessage o = new MailMessage("iuliunicolaebarcan@gmail.com", c.Email, "grattis", "you have a new acount");
        NetworkCredential netCred = new NetworkCredential("iuliunicolaebarcan@gmail.com", "tarabostes");
        SmtpClient smtpobj = new SmtpClient("smtp.gmail.com", 587);
        smtpobj.EnableSsl = true;
        smtpobj.Credentials = netCred;
        smtpobj.Send(o);
    }
}