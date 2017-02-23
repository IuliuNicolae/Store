using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Orders
/// </summary>
public class Cart
{
    string customerId;
    List<Movies> titles;
    string price;

    public string CustomerId
    {
        get
        {
            return customerId;
        }

        set
        {
            customerId = value;
        }
    }

    public List<Movies> Titles
    {
        get
        {
            return titles;
        }

        set
        {
            titles = value;
        }
    }
    public void addToCart(Movies mov) {
        titles.Add(mov);
    }
    public void removeFromCart(Movies mov)
    {
        titles.Remove(mov);
    }

    public string Price
    {
        get
        {
            return price;
        }

        set
        {
            price = value;
        }
    }

    public Cart()
    {
        this.titles = new List<Movies>();
    }
    
}