using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

/// <summary>
/// Summary description for email
/// </summary>
public class sendEmail
{
    string reciver = "";
    string sender = "pstudent345@gmail.com";
    string senderpass = "student123";
    string subject = "";
    string content = "";
    string smtp = "smtp.gmail.com";
    int port = 587;

    public void send()
    {
        MailMessage o = new MailMessage(sender, reciver, subject, content);
        NetworkCredential netCred = new NetworkCredential(sender, senderpass);
        SmtpClient smtpobj = new SmtpClient(smtp, port);
        smtpobj.EnableSsl = true;
        smtpobj.Credentials = netCred;
        smtpobj.Send(o);
    }
    public void newuser_mail(string recivermail)
    {
        this.reciver = recivermail;
        this.subject = "You have registred a new user";
        this.content = "A new user have been created with username " + recivermail;
    }
}