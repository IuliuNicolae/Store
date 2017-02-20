using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SetRate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        /*
        actualCustomer = new Customers();
        actualCustomer = (Customers)Session["myCustomer"];
        String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebbAppConnString"].ToString();
        conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
        conn.Open();
        queryStr = "";
        queryStr = "SELECT title from movies,bookings,bookings_has_movies where movies.id = bookings_has_movies.movies_id and bookings_has_movies.Bookings_id = bookings.idBookings and bookings.user_email = '"+email11@hhh.com+"'";

        cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
        reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            lastID = reader.GetInt32(reader.GetOrdinal("LAST_INSERT_ID()"));
        }

        conn.Close();
       */
        buttonComments.Visible = false;
        buttonRate.Visible = false;
        DropDownListComments.Visible = false;
        DropDownListRate.Visible = false;

    }

   
    protected void RadioButtonList1_SelectedIndexChanged1(object sender, EventArgs e)
    {
        
    }
}