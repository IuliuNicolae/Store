using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Security.Cryptography;
public partial class Login : System.Web.UI.Page
{
    string email = "";
    string pass = "";

    string queryStr = "";
    MySqlDataReader reader;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void login_Click(object sender, EventArgs e)
    {
        logIn();
    }

    protected void createUser_Click(object sender, EventArgs e)
    {
        Response.Redirect("RegisterNewCustomer.aspx");
    }
    protected void logIn()
    {
        email = emailTB.Text;
        pass =passTB.Text;
        string myPass = GenerateSHA256String(pass);
        
        string loginpass = "";
        string firstName = "";
        string lastName = "";
        string adress = "";
        string phone = "";
        string type = "";
        if (email != " ")
        {
            try
            {
                dbConnection dbc = dbConnection.Instance();
                queryStr = "SELECT * from user where email = '" + email + "'";

                reader = dbc.Select(queryStr);
                System.Diagnostics.Debug.WriteLine("read reader");
                while (reader.Read())
                {
                    

                    firstName = reader.GetString(reader.GetOrdinal("firstName"));
                    lastName = reader.GetString(reader.GetOrdinal("lastName"));
                    loginpass = reader.GetString(reader.GetOrdinal("password"));
                    adress = reader.GetString(reader.GetOrdinal("address"));
                    phone = reader.GetString(reader.GetOrdinal("phone"));
                    type = reader.GetString(reader.GetOrdinal("type"));

                }
                dbc.close();
              
                if (loginpass.Equals(myPass) && type.Equals("user"))
                {
                    System.Diagnostics.Debug.WriteLine("pASSS hASH "+pass);
                    Customers myCustomer = new Customers(firstName, lastName, email, loginpass, adress, phone);
                    Session["myCustomer"] = myCustomer;
                    Response.Redirect("Default.aspx");
                }
                else if (loginpass.Equals(myPass) && type.Equals("admin"))
                {
                    System.Diagnostics.Debug.WriteLine("pASSS hASH " + pass);
                    Administrator admin = new Administrator(firstName, email, loginpass);
                    Session["myAdministrator"] = admin;
                    Response.Redirect("Default.aspx");
                }
                else
                {

                    errorL.Text = "Invalid email or password";
                    

                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                
                errorL.Text = "Your email is not valid";
            }

        }
        else
        {
            errorL.Text = "You must enter your email";
        }



    }
    public static string GenerateSHA256String(string inputString)
    {
        SHA256 sha256 = SHA256Managed.Create();
        byte[] bytes = Encoding.UTF8.GetBytes(inputString);
        byte[] hash = sha256.ComputeHash(bytes);
        string myHash;
        myHash = GetStringFromHash(hash);
        return myHash;
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