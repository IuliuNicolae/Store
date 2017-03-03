using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
public partial class insertUser : System.Web.UI.Page
{
    string firstName,lastName,pass,email,adress, phone,opr;

    MySql.Data.MySqlClient.MySqlConnection conn;
    MySql.Data.MySqlClient.MySqlCommand cmd;
    MySql.Data.MySqlClient.MySqlDataReader reader;
    String queryStr;

    protected void Page_Load(object sender, EventArgs e)
    {
        //  
      
        opr = Request.QueryString["opr"].ToString();
        firstName = Request.QueryString["fnm"].ToString();
        lastName = Request.QueryString["lnm"].ToString();
        pass = Request.QueryString["pass"].ToString();
        email = Request.QueryString["email"].ToString();
        adress = Request.QueryString["adr"].ToString();
        phone = Request.QueryString["phone"].ToString();
        System.Diagnostics.Debug.WriteLine("Begin+ "+email);
        
        String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebbAppConnString"].ToString();
        conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
        conn.Open();
        queryStr = "";
     
        queryStr = " INSERT INTO user (email,firstName,lastName,password,address,phone,type ) values ('" + email + "','" + firstName + "','" + lastName + "','" + pass + "','" + adress + "','" + phone + "','user')";
        cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
        cmd.ExecuteReader();
        conn.Close();
        sms s = new sms();
        s.Sendsms(phone, "You have been registered att Movie Store");
        System.Diagnostics.Debug.WriteLine("Phone+ " + email);
        sendEmail mail = new sendEmail();
        mail.newuser_mail(email);
    }
    
}