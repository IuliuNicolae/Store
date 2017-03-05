using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class paymentConfermation : System.Web.UI.Page
{
    Customers c;
    List<Movies> movies;
    string queryStr = "";
    MySqlDataReader reader;
    double totalPrice = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        c = new Customers();
        c = (Customers)Session["myCustomer"];
        movies = (List<Movies>)Session["myMovies"];
        addOrder();
        sms s = new sms();
        s.Sendsms(c.Phone, "Your order att MovieStore have been mabe and payed");
        string emailCustomer = c.Email;
        System.Diagnostics.Debug.WriteLine("sending mail to" + emailCustomer);
        sendEmail email = new sendEmail();
        email.booking_mail(emailCustomer);

        
    }
    
protected void toHome(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
    protected void addOrder()
    {
        string allTitles = null;
        int lastID = 0;
        string price = getPrice(movies);
        string emailCustomer = c.Email;
        for (int i = 0; i < movies.Count; i++)
        {
            allTitles = allTitles + movies[i].Title + "; ";

        }
        dbConnection dbc = dbConnection.Instance();
        queryStr = "insert into bookings (totalPrice,bookingdate,user_email) values ('" + price + "',now(),'" + emailCustomer + "');SELECT LAST_INSERT_ID();";

        reader = dbc.Select(queryStr);
        System.Diagnostics.Debug.WriteLine("read reader");
        while (reader.Read())
        {
            lastID = reader.GetInt32(reader.GetOrdinal("LAST_INSERT_ID()"));
            System.Diagnostics.Debug.WriteLine("got last index id " + lastID);

        }
        dbc.close();
        
        

        System.Diagnostics.Debug.WriteLine("Last id: " + lastID);
        System.Diagnostics.Debug.WriteLine("number in movies: " + movies.Count);
        for (int j = 0; j < movies.Count; j++)
        {
            insertMoviesIntoBooking(lastID, Convert.ToInt32(movies[j].Id));
            System.Diagnostics.Debug.WriteLine("Last id: " + lastID);
            insertNewRateRow(Convert.ToInt32(movies[j].Id), emailCustomer);
            

        }
    }
    protected void insertMoviesIntoBooking(int idB, int idM)
    {
        System.Diagnostics.Debug.WriteLine("Added movieID: " + idB + " to bookingid: " + idM);
        dbConnection dbc = dbConnection.Instance();
        queryStr = "insert into bookings_has_movies (Bookings_id,movies_id) values (" + idB + " , " + idM + " )";
        

        dbc.insert(queryStr);
        dbc.close();
    }
    protected string getPrice(List<Movies> b)
    {
        totalPrice = 0;
        string price = "";
        if (b.Count > 0)
        {
            for (int i = 0; i < b.Count; i++)
            {
                string tempPrice = b[i].Price;
                double tempPrice1 = Convert.ToDouble(tempPrice, CultureInfo.InvariantCulture);
                totalPrice = totalPrice + tempPrice1;
            }
            price = totalPrice + "";
        }
        else
        {
            price = "0";
        }
        return price;
    }
    protected void insertNewRateRow(int idM, string email)
    {
        try
        {
            dbConnection dbc = dbConnection.Instance();


            queryStr = "insert into comments(movies_id, user_email,betyg, comment, isSetBetyg) values('" + idM + "','" + email + "' ,'" + 0 + "','NONE',false)";
            dbc.insert(queryStr);
            dbc.close();

        }
        catch
        {
            System.Diagnostics.Debug.WriteLine("You already bought this movie!!");
        }

    }
}