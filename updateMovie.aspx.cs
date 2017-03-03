using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
public partial class updateMovie : System.Web.UI.Page
{ 
 MySqlConnection conn;
    MySqlCommand cmd;
    MySqlDataReader reader;
    String queryStr;
    //int count=0;
    string title;
    string category;
    string artists;
    string price;
    string quantity;
    string imdbLink;
    string picture;
    string opr;
    string id;
    protected void Page_Load(object sender, EventArgs e)
    {
        System.Diagnostics.Debug.WriteLine("SomeText1 ");

        id = (string)Session["myID"];


        System.Diagnostics.Debug.Write("BOOOOOOOOOOOOOOUUUUUUUUUUUUUUUUUUUUU UPdaste");
            title = Request.QueryString["title"].ToString();
            category = Request.QueryString["cat"].ToString();
            artists = Request.QueryString["artists"].ToString();
            price = Request.QueryString["price"].ToString();
            quantity = Request.QueryString["quan"].ToString();
            imdbLink = Request.QueryString["link"].ToString();
            picture = Request.QueryString["pict"].ToString();
        
            System.Diagnostics.Debug.WriteLine("SomeText2 " + category);
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebbAppConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();
            queryStr = "";
          
            queryStr = "update movies set title='" + title + "', category='" + category + "',artists='" + artists + "',price='" + price + "',quantity='" + quantity + "',imdbLink='" + imdbLink + "',picture='" + picture + "' where id='" + id + "'";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
            cmd.ExecuteReader();
            conn.Close();

        
    }

}
