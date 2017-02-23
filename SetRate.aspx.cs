using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SetRate : System.Web.UI.Page
{
    Customers actualCustomer;
    MySql.Data.MySqlClient.MySqlConnection conn;
    MySql.Data.MySqlClient.MySqlCommand cmd;
    MySql.Data.MySqlClient.MySqlDataReader reader;
    string queryStr;
    string title;
    string id;
    string em;
    Movies movie;
    List<Movies> allTitles;
    protected void Page_Load(object sender, EventArgs e)
    {
        title = "";
        
        allTitles = new List<Movies>();
        actualCustomer = new Customers();

        actualCustomer = (Customers)Session["myCustomer"];
        if (!IsPostBack)
        {
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebbAppConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();
            em = actualCustomer.Email;
            queryStr = "";
           queryStr = "SELECT id, title from movies,bookings,bookings_has_movies,comments where movies.id = bookings_has_movies.movies_id and bookings_has_movies.Bookings_id = bookings.idBookings and bookings.user_email = '" + em + "' and bookings_has_movies.movies_id=comments.movies_id and bookings.user_email=comments.user_email and comments.isSetBetyg=false";
           
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                id = reader.GetString(reader.GetOrdinal("id"));
                title = reader.GetString(reader.GetOrdinal("title"));
                allTitles.Add(new Movies(id, title));

            }

            conn.Close();

              ddlMovies.DataValueField = "id";
            ddlMovies.DataTextField = "title";
            ddlMovies.DataSource = allTitles;
            ddlMovies.DataBind();
        }

       
    }

    

    protected void buttonComments_Click(object sender, EventArgs e)
    {
   
        em = actualCustomer.Email;
        var dateAsString = DateTime.Now.ToString("yyyy-MM-dd");
        string comments = actualCustomer.FirstName+" said at: " + dateAsString+": "+TextBox1.Text;
        int idTemp = Convert.ToInt32(ddlMovies.SelectedValue);
        int betyg = Convert.ToInt32(DropDownListRate.SelectedValue);
      
       System.Diagnostics.Debug.Write("Movies: "+ddlMovies.SelectedItem + "Esti prost: "+ DropDownListRate.SelectedValue+"id: "+ddlMovies.SelectedItem.Text);
       updateComments(comments,betyg,em,idTemp);

    }

    protected void updateComments(string s,int betyg, string email,int id)
    {
        try
        {
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebbAppConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();
            queryStr = "";
            queryStr = "update  comments set comment = '" + s + "', betyg= "+betyg+", isSetBetyg="+true+"  where movies_id =" + id + " and user_email='"+email+"' and isSetBetyg=false";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
            cmd.ExecuteReader();
            conn.Close();
            TextBox1.Text = "";
            DropDownListRate.SelectedValue = "None";

        }
        catch (MySql.Data.MySqlClient.MySqlException ex)
        {
            System.Diagnostics.Debug.Write("error: "+ex);
            errorLabel.Text = " It is not possible to set a new rate for this movie!!";
        }

    }

}