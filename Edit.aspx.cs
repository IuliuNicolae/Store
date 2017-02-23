using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Edit : System.Web.UI.Page
{
    Administrator actualAdminNew;
    Administrator newAdministrator;
    Customers actualCustomerNew;
    Customers newCustomer;
    string user = "";
    

    MySql.Data.MySqlClient.MySqlConnection conn;
    MySql.Data.MySqlClient.MySqlCommand cmd;
    MySql.Data.MySqlClient.MySqlDataReader reader;
    string queryStr;

    protected void Page_Load(object sender, EventArgs e)
    {
        actualAdminNew = new Administrator();
        actualAdminNew = (Administrator)Session["myAdministrator"];
        actualCustomerNew = new Customers();
        actualCustomerNew = (Customers)Session["myCustomer"];
        
            if (actualAdminNew != null)  
            {
                user = "admin";
               
            }
            else if (actualCustomerNew != null)
            {
                user = "customer";
               

            }
           
        if (!IsPostBack) {

            if (user.Equals("admin"))
            {

                lbEm.Text = actualAdminNew.Email;
                textBoxFirstName.Text = actualAdminNew.Name;
              
                textBoxPass.Text = actualAdminNew.Pass;
              
                textBoxPass2.Text = actualAdminNew.Pass;
                textBoxPhone.Visible = false;
                textBoxStreet.Visible = false;
          
            }
            else
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
        if (user.Equals("customer"))
            {
            System.Diagnostics.Debug.WriteLine(actualCustomerNew.Email + "      userrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr   " + user);
            queryStr = "update  user set firstName='" + textBoxFirstName.Text +"',lastName='"+textBoxLastName.Text+ "', password='" + textBoxPass.Text + "', address='" + textBoxStreet.Text + "', phone='" + textBoxPhone.Text + "' where email='" + actualCustomerNew.Email + "'";
                newCustomer = new Customers(actualCustomerNew.Email,textBoxFirstName.Text,textBoxPass.Text,actualCustomerNew.Pass,textBoxStreet.Text,textBoxPhone.Text);
                Session["myCustomer"] = newCustomer;
               
            }
            else if (user.Equals("admin"))
            {
                queryStr = "update administrator set administratorName='" + textBoxFirstName.Text + "', administratorPass='" + textBoxPass.Text + "' where administratorEmail='" + actualAdminNew.Email + "'";
               newAdministrator = new Administrator(textBoxFirstName.Text,actualAdminNew.Email,textBoxPass.Text);
                Session["myAdministrator"] = newAdministrator;
            }
           

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