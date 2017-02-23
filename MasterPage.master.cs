﻿using System;
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
    //  List<Books> myBooks;
    // Books book;

    Customers actualCustomer;
    Administrator actualAdmin;
    protected void Page_Load(object sender, EventArgs e)
    {
        //    myBooks = new List<Books>();
        // myBooks = (List<Books>)Session["myBooks"];
        //labelPrice.Text = this.getPrice(myBooks);
        if (!IsPostBack)
        {

            // book = new Books();
            actualCustomer = new Customers();
            actualAdmin = new Administrator();

            actualAdmin = (Administrator)Session["myAdministrator"];

            actualCustomer = (Customers)Session["myCustomer"];
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

            /* if (myBooks.Count > 0)
             {
                 linckOut.Visible = true;
                 ddLstBks.Visible = true;

                 ddLstBks.DataTextField = "title";
                 ddLstBks.DataValueField = "isbn";
                 ddLstBks.DataSource = myBooks;
                 ddLstBks.DataBind();
              //   getPrice(myBooks);

             }
             else {
                 linckOut.Visible = false;
                 ddLstBks.Visible = false;

             }*/

            //   book = getAllBooks();

            //   LinkButton2.Text = book.Title;
            //   imageBook.ImageUrl = "~/Styles/" + book.Isbn + ".gif";
            // Session["bookAdd"] = book;

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }

    protected void Button8_Click(object sender, EventArgs e)
    {

    }

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }

    protected void Button8_Click1(object sender, EventArgs e)
    {
        
            if (logBtn.Text.Equals("Log in"))
            {
                logIn();
                logBtn.Text = "Log out";
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
    protected void logIn()
    {
        email = textBoxEmail.Text;
        pass = textBoxPassword.Text;
        string loginpass="";
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
                    labelName.Text = myCustomer.FirstName;

                }
                else if (loginpass.Equals(pass) && type.Equals("admin")) {
                    System.Diagnostics.Debug.Write("ADDDDDDDDDDDDDDDDDDDDMMMMMMMMMMMMMMMIIIIIIIIIIIIIIIIIINNNNNNNNNNNNNNN");
                    Administrator myAdmin = new Administrator( firstName, email, loginpass);
                    Session["myAdministrator"] = myAdmin;
                    labelName.Text ="Admin "+ myAdmin.Name;
                }
                else
                {

                    labelName.Text = "Invalid email or password";
                    Response.Redirect("Default.aspx");

                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Response.Redirect("Default.aspx");
                labelName.Text = "Your email is not valid";
            }

        }
        else
        {
            labelName.Text = "You must enter your email";
        }



    }
   

    protected void ddLstBks_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    protected void Button9_Click(object sender, EventArgs e)
    {
        /* int id = ddLstBks.SelectedIndex;
         string removedIsbn = myBooks[id].Isbn;
         string allQuantity = getAllQuantity(removedIsbn);
         int newQuantity = (Convert.ToInt32(myBooks[id].Quantity) + Convert.ToInt32(allQuantity));
         updateQuantity(newQuantity, removedIsbn);
         ddLstBks.Items.RemoveAt(id);
          myBooks.RemoveAt(id);      
         Session["myBooks"] = myBooks;
         Response.Redirect("BookPage.aspx");*/
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

    protected void XmlDataSource1_Transforming(object sender, EventArgs e)
    {

    }

    protected void XmlDataSource2_Transforming(object sender, EventArgs e)
    {

    }
    protected void getAllBooks()
    {
        /*   it was BOOKS   Books addBook = new Books();
          List<Books> lib = new List<Books>();
          rnd = new Random();
          String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebbAppConnString"].ToString();
          conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
          conn.Open();
          queryStr = "";
          queryStr = "Select * from (SELECT * FROM books ORDER BY date DESC limit 0,3) as alias ORDER BY date desc;";
          cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
          reader = cmd.ExecuteReader();
          while (reader.Read())
          {
               string title = reader.GetString(reader.GetOrdinal("title"));
              string  isbn = reader.GetString(reader.GetOrdinal("isbn"));
              lib.Add(new Books(title, isbn));

          }
          conn.Close();
          int r = rnd.Next(lib.Count);
          addBook = lib[r];


          return addBook;*/
    }


    protected void LinkButton2_Click(object sender, EventArgs e)
    {

        /* Books bookAdd = (Books)Session["bookAdd"];
          Session["ISBN"] = bookAdd.Isbn;
        //  LinkButton2.Text = bookAdd.Title;

          Response.Redirect("SelectedProduct.aspx");*/
    }

    protected void linkBooks_Click(object sender, EventArgs e)
    {
        /*  Session["searchQuerry"] ="";
          Response.Redirect("BookPage.aspx");*/
    }

    protected void LinkButton7_Click(object sender, EventArgs e)
    {
        Response.Redirect("OrdersLogg.aspx");
    }

    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Session["searchQuerry"] = "£science£";
        Response.Redirect("BookPage.aspx");
    }

    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        Session["searchQuerry"] = "£romance£";
        Response.Redirect("BookPage.aspx");
    }

    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        Session["searchQuerry"] = "£thriller£";
        Response.Redirect("BookPage.aspx");
    }

    protected void LinkButton6_Click(object sender, EventArgs e)
    {
        Session["searchQuerry"] = "£children£";
        Response.Redirect("BookPage.aspx");
    }

    protected void LinkButton8_Click(object sender, EventArgs e)
    {
        if(actualCustomer != null) { 
        Response.Redirect("CheckOut.aspx");
    }
}
    protected string getPrice()
    {
        double totalPrice = 0;
        string price = "0";

        /* for (int i = 0; i < b.Count; i++)
         {
             string tempPrice = b[i].Price;
             double tempPrice1 = Convert.ToDouble(tempPrice, CultureInfo.InvariantCulture);
             totalPrice = totalPrice + tempPrice1;
         }
         price = totalPrice + "";*/



        return price;
    }
    protected string getAllQuantity(string s)
    {
        string q = "0";

        /* String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebbAppConnString"].ToString();
         conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
         conn.Open();
         queryStr = "";
         queryStr = "SELECT * from books where isbn= '" + s + "'";
         cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
         reader = cmd.ExecuteReader();
         while (reader.Read())
         {
             q = reader.GetString(reader.GetOrdinal("quantity"));
         }
         conn.Close();*/
        return q;
    }
    protected void updateQuantity(int q, string isbn)
    {

        /*  String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebbAppConnString"].ToString();
          conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
          conn.Open();
          queryStr = "";
          queryStr = "update  books set quantity = '" + q + "' where isbn = '" + isbn + "'";
          cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
          cmd.ExecuteReader();
          conn.Close();*/

    }



    protected void LinkButton8_Click1(object sender, EventArgs e)
    {
        if (actualCustomer != null)
        {
            Response.Redirect("SetRate.aspx");
        }
        
    }

    
}
