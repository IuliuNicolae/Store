using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{

    MySql.Data.MySqlClient.MySqlDataReader reader;
    string queryStr;
    string id;
    string name;
    string pass = "#£#£0*";
    string email;
    string street;
    string phone;
    
    string totalPrice = "";
    static Random rnd;

    Customers actualCustomer;
    Administrator actualAdmin;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            
            actualCustomer = new Customers();
            

            actualCustomer = (Customers)Session["myCustomer"];
            actualAdmin = (Administrator)Session["myAdministrator"];
            string name = "";
            if (actualCustomer == null && actualAdmin == null)
            {
                name = "You are not logged in as customer or admin!";
            }
            else if (actualCustomer == null && actualAdmin != null)
            {
                name = actualAdmin.Name;
                logBtn.Text = "Log out";
            }
            else if (actualCustomer != null && actualAdmin == null)
            {
                name = actualCustomer.FirstName;
                logBtn.Text = "Log out";
            }


            labelName.Text = name;

           

        }
    }
   

    protected void Button8_Click1(object sender, EventArgs e)
    {
        
            if (logBtn.Text.Equals("Log in"))
            {
                
                logBtn.Text = "Log out";
            Response.Redirect("Login.aspx");
        }
            else if (logBtn.Text.Equals("Log out"))
            {
                logOut();

            }
        
    }
    protected void logOut()
    {
        Session.Clear();
        Response.Redirect("Default.aspx");
    }
   
   


    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("RegisterNewCustomer.aspx");
    }

    protected void linkAdministrator_Click(object sender, EventArgs e)
    {
        Administrator actualAdminNew = new Administrator();

        actualAdminNew = (Administrator)Session["myAdministrator"];

        if (actualAdminNew == null)
        {
            name = "You are not logged in as administrator!";
        }
        else
        {
            Response.Redirect("AdminTools.aspx");
            logBtn.Text = "Log out";
        }

    }

    protected void linkProfile_Click(object sender, EventArgs e)
    {
        Administrator actualAdminNew = new Administrator();

        actualAdminNew = (Administrator)Session["myAdministrator"];
        Customers actualCustomerNew = new Customers();
        actualCustomerNew = (Customers)Session["myCustomer"];


        if ((actualCustomerNew == null) && (actualAdminNew == null))
        {
            labelName.Text = "You are not logged in as administrator or customer!";
        }
        else
        {
            Response.Redirect("Edit.aspx");

        }
    }

    protected void linkHome_Click(object sender, EventArgs e)
    {
      
        Response.Redirect("Default.aspx");
    }


    protected void linkBooks_Click(object sender, EventArgs e)
    {
        Session["searchQuerry"] ="all";
          Response.Redirect("BookPage.aspx");
    }

    protected void LinkButton7_Click(object sender, EventArgs e)
    {
        Response.Redirect("OrdersLogg.aspx");
    }

    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Session["searchQuerry"] = "Science";
        Response.Redirect("BookPage.aspx");
    }

    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        Session["searchQuerry"] = "Romance";
        Response.Redirect("BookPage.aspx");
    }

    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        Session["searchQuerry"] = "Thriller";
        Response.Redirect("BookPage.aspx");
    }

    protected void LinkButton6_Click(object sender, EventArgs e)
    {
        Session["searchQuerry"] = "Children";
        Response.Redirect("BookPage.aspx");
    }

    protected void LinkButton8_Click(object sender, EventArgs e)
    {
        actualCustomer = (Customers)Session["myCustomer"];
        if (actualCustomer != null) { 
        Response.Redirect("CheckOut.aspx");
    }
}
    protected string getPrice()
    {
        double totalPrice = 0;
        string price = "0";
        

        return price;
    }
    protected string getAllQuantity(string s)
    {
        string q = "0";

        
        return q;
    }
    protected void LinkButton8_Click1(object sender, EventArgs e)
    {
        actualCustomer = (Customers)Session["myCustomer"];
        System.Diagnostics.Debug.WriteLine("Click på rate" + actualCustomer.FirstName);
        if (actualCustomer != null)
        {
            Response.Redirect("SetRate.aspx");
        }
        
    }

    
}
