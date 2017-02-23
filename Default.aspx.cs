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
        
        
        Image img = new Image();
        for (int i = 0;i < 3 ;i++)
        {
            TableRow tr = new TableRow();
            movietable.Rows.Add(tr);
            for ( int j = 0; j < 3; j++) {
                TableCell tc = new TableCell();
                tr.Cells.Add(tc);
                Random ran = new Random();
                int number = ran.Next(0,movielist.Count);
                System.Diagnostics.Debug.WriteLine("new random: "+ number);
                title = movielist[number].Title;
                cat = movielist[number].Category;
                artist = movielist[number].Artists;
                price = movielist[number].Price;
                quant = movielist[number].Quantity;
                imdb = movielist[number].ImdbLink;
                pic = movielist[number].Picture;
                img.ImageUrl = pic;
                tc.Controls.Add(img);
                
                System.Diagnostics.Debug.WriteLine("added cell to row");
            }
            
            System.Diagnostics.Debug.WriteLine("added row to table");

        }
       
    }
    
        
    

}