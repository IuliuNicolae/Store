using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {

        addmoviestotable();

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        
    }
    private void addmoviestotable()
    {
        int id;
        string title ="";
        string cat = "";
        string artist = "";
        string price = "";
        string quant = "";
        string imdb = "";
        string pic = "";
        MySqlDataReader reader;
        List<Movies> movielist = new List<Movies>();
        string quarySql = "Select * from movies";
        dbConnection dbc = dbConnection.Instance();
        reader = dbc.Select(quarySql);
        while (reader.Read())
        {
            id = reader.GetInt32(reader.GetOrdinal("id"));
            title = reader.GetString(reader.GetOrdinal("title"));
            cat = reader.GetString(reader.GetOrdinal("category"));
            artist = reader.GetString(reader.GetOrdinal("artists"));
            price = reader.GetString(reader.GetOrdinal("price"));
            quant = reader.GetString(reader.GetOrdinal("quantity"));
            imdb = reader.GetString(reader.GetOrdinal("imdbLink"));
            pic = reader.GetString(reader.GetOrdinal("picture"));

            Movies mov = new Movies(id,title,cat,artist,price,quant,imdb,pic);
            movielist.Add(mov);
        }
        
        for (int i = 0;i < 3 ;i++)
        {
            Random ran = new Random();
            int number = ran.Next(0,movielist.Count);
            title = movielist[number].Title;
            cat = movielist[number].Category;
            artist = movielist[number].Artists;
            price = movielist[number].Price;
            quant = movielist[number].Quantity;
            imdb = movielist[number].ImdbLink;
            pic = movielist[number].Picture;

            Image1.ImageUrl = pic;

           
        }
    }
    
        
    

}