using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Statistique : System.Web.UI.Page
{
    MySql.Data.MySqlClient.MySqlConnection conn;
    MySql.Data.MySqlClient.MySqlCommand cmd;
    MySql.Data.MySqlClient.MySqlDataReader reader;
    string queryStr;
    string category;
    int countChildren;
    int countRomance;
    int countThriller;
    int countScience;

    protected void Page_Load(object sender, EventArgs e)
    {
        countChildren = 0;
        countRomance = 0;
        countThriller = 0;
        countScience = 0;
        if (!IsPostBack)
        {

            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebbAppConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();
            queryStr = "";
            queryStr = " select category from movies, bookings, bookings_has_movies where movies.id = bookings_has_movies.movies_id and bookings.idBookings = bookings_has_movies.Bookings_id";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                category = reader.GetString(reader.GetOrdinal("category"));
                System.Diagnostics.Debug.WriteLine(category);
                switch (category)
                {

                    case "Science":
                        countScience = countScience + 1;
                        break; /* optional */

                    case "Children":
                        countChildren = countChildren + 1;
                        break;
                    case "Romance":
                        countRomance = countRomance + 1;
                        break; /* optional */

                    case "Thriller":
                        countThriller = countThriller + 1;
                        break;
                }
                
            }

            conn.Close();
        }

    }
}