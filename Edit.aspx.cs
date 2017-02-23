using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Edit : System.Web.UI.Page
{
    
    Customers actualCustomerNew;
    Customers newCustomer;
    string user = "";
    

    MySql.Data.MySqlClient.MySqlConnection conn;
    MySql.Data.MySqlClient.MySqlCommand cmd;
    MySql.Data.MySqlClient.MySqlDataReader reader;
    string queryStr;

    protected void Page_Load(object sender, EventArgs e)
    {

        actualCustomerNew = new Customers();
        actualCustomerNew = (Customers)Session["myCustomer"];


        if (actualCustomerNew != null)
        {
            user = actualCustomerNew.Type;


        }

        if (!IsPostBack)
        {

            {
                lbEm.Text = actualCustomerNew.Email;

                textBoxFirstName.Text = actualCustomerNew.FirstName;
                textBoxLastName.Text = actualCustomerNew.LastName;
                textBoxPass.Text = actualCustomerNew.Pass;
                textBoxPass2.Text = actualCustomerNew.Pass;
                textBoxStreet.Text = actualCustomerNew.Adress;
                textBoxPhone.Text = actualCustomerNew.Phone;



            }
        }
    }
        
    protected void Button10_Click(object sender, EventArgs e)
    {
            queryStr = "";
        String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebbAppConnString"].ToString();
        conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
        conn.Open();
       
            System.Diagnostics.Debug.WriteLine(actualCustomerNew.Email + "      userrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr   " + user);
            queryStr = "update  user set firstName='" + textBoxFirstName.Text +"',lastName='"+textBoxLastName.Text+ "', password='" + textBoxPass.Text + "', address='" + textBoxStreet.Text + "', phone='" + textBoxPhone.Text + "' where email='" + actualCustomerNew.Email + "'";
                newCustomer = new Customers(actualCustomerNew.Email,textBoxFirstName.Text,textBoxPass.Text,actualCustomerNew.Pass,textBoxStreet.Text,textBoxPhone.Text, actualCustomerNew.Type );
                Session["myCustomer"] = newCustomer;
               

            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
            cmd.ExecuteReader();
            conn.Close();
        Response.Redirect("Default.aspx");

    }
    protected void Button11_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

}