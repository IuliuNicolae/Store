using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Security.Cryptography;

public partial class insertUser : System.Web.UI.Page
{
    string firstName,lastName,pass,email,adress, phone,opr,myPass;

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
        myPass = GenerateSHA256String(pass);
        
        email = Request.QueryString["email"].ToString();
        adress = Request.QueryString["adr"].ToString();
        phone = Request.QueryString["phone"].ToString();
        System.Diagnostics.Debug.WriteLine("Begin+ "+email);
        
        String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebbAppConnString"].ToString();
        conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
        conn.Open();
        queryStr = "";
     
        queryStr = " INSERT INTO user (email,firstName,lastName,password,address,phone,type ) values ('" + email + "','" + firstName + "','" + lastName + "','" + myPass + "','" + adress + "','" + phone + "','user')";
        cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
        cmd.ExecuteReader();
        conn.Close();
        sendMail();
    }
    private void sendMail()
    {
        MailMessage o = new MailMessage("pstudent345@gmail.com", email, "grattis", "you have a new acount");
        NetworkCredential netCred = new NetworkCredential("pstudent345@gmail.com", "student123");
        SmtpClient smtpobj = new SmtpClient("smtp.gmail.com", 587);
        smtpobj.EnableSsl = true;
        smtpobj.Credentials = netCred;
        smtpobj.Send(o);
    }
    public static string GenerateSHA256String(string inputString)
    {
        SHA256 sha256 = SHA256Managed.Create();
        byte[] bytes = Encoding.UTF8.GetBytes(inputString);
        byte[] hash = sha256.ComputeHash(bytes);
        string myHash;
        myHash = GetStringFromHash(hash);
        return myHash ;
    }
    private static string GetStringFromHash(byte[] hash)
    {
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < hash.Length; i++)
        {
            result.Append(hash[i].ToString("X2"));
        }
        return result.ToString();
    }

}
