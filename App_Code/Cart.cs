using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Orders
/// </summary>
public class Cart
{

    List<Movies> movielist = new List<Movies>();

   
    public List<Movies> movielistclass
    {
        get
        {
            return movielist;
        }

        set
        {
            movielist = value;
        }
    }
    public void addToCart(Movies m)
    {
        movielist.Add(m);
    }
    public Cart()
    {
        
    }
    
}