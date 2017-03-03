using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;



public partial class ChangeMovie : System.Web.UI.Page
{
    MySql.Data.MySqlClient.MySqlConnection conn;
    MySql.Data.MySqlClient.MySqlCommand cmd;
    MySql.Data.MySqlClient.MySqlDataReader reader;
    string queryStr;
    string id;
    string title;
    string category;
    string artists;
    string price;
    string quantity;
    string imdbLink;
    string picture;
    int myQuantity;
    int numberOfItems;
    String connString;
    protected void Page_Load(object sender, EventArgs e)
    {
        id = (string)Session["myID"];
        System.Diagnostics.Debug.Write("aici"+id + "aici");
        // 
         connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebbAppConnString"].ToString();
        conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
        conn.Open();
        queryStr = "";
        queryStr = "SELECT * from movies where id= '" + id + "'";
        cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
        reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            title = reader.GetString(reader.GetOrdinal("title"));
            artists = reader.GetString(reader.GetOrdinal("artists"));
            category = reader.GetString(reader.GetOrdinal("category"));
            // customerRate = reader.GetString(reader.GetOrdinal("customerRate"));
            //coments = reader.GetString(reader.GetOrdinal("coments"));
            price = reader.GetString(reader.GetOrdinal("price"));
            quantity = reader.GetString(reader.GetOrdinal("quantity"));
            imdbLink = reader.GetString(reader.GetOrdinal("imdbLink"));
            picture = reader.GetString(reader.GetOrdinal("picture"));
            ddlCategory.Text = category;
        }
        conn.Close();

        textBoxTitle.Text = title;
        textBoxDistribution.Text = artists;
        textBoxPicture.Text = picture;
        textBoxPrice.Text = price;
        textBoxQuantity.Text = quantity;
        textBoxIMBD.Text = imdbLink;


    }

    protected void Button11_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminTools.asps");
    }



    protected void Button1_Click(object sender, EventArgs e)
    {
        queryStr = "";
        id = (string)Session["myID"];
        int myId = Convert.ToInt32(id);
        title =textBoxTitle.Text;
        artists=textBoxDistribution.Text;
       picture= textBoxPicture.Text;
        price=textBoxPrice.Text;
        quantity=textBoxQuantity.Text;
        imdbLink=textBoxIMBD.Text;
        category = ddlCategory.SelectedItem.Text;

        conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
        conn.Open();


        queryStr = "update movies set title='" + title + "', category='" + category + "',artists='" + artists + "',price='" + price + "',quantity='" + quantity + "',imdbLink='" + imdbLink + "',picture='" + picture + "' where id=" + myId+";" ;


        cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
        cmd.ExecuteReader();
        conn.Close();
        System.Diagnostics.Debug.WriteLine(queryStr);
        Response.Redirect("AdminTools.aspx");
    }
}