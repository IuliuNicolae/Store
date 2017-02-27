using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
        pass = passTB.Text;
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
                    System.Diagnostics.Debug.WriteLine("reads");

                    firstName = reader.GetString(reader.GetOrdinal("firstName"));
                    lastName = reader.GetString(reader.GetOrdinal("lastName"));
                    loginpass = reader.GetString(reader.GetOrdinal("password"));
                    adress = reader.GetString(reader.GetOrdinal("address"));
                    phone = reader.GetString(reader.GetOrdinal("phone"));
                    type = reader.GetString(reader.GetOrdinal("type"));

                }
                dbc.close();
                if (loginpass.Equals(pass) && type.Equals("user"))
                {

                    Customers myCustomer = new Customers(firstName, lastName, email, loginpass, adress, phone);
                    Session["myCustomer"] = myCustomer;
                    Response.Redirect("Default.aspx");
                }
                else
                {

                    errorL.Text = "Invalid email or password";
                    ;

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
}