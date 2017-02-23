using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Administrator
/// </summary>
public class Administrator
{
  
    string name;
    string pass;
    string email;

   

    public string Name
    {
        get
        {
            return name;
        }

        set
        {
            name = value;
        }
    }

    public string Pass
    {
        get
        {
            return pass;
        }

        set
        {
            pass = value;
        }
    }

    public string Email
    {
        get
        {
            return email;
        }

        set
        {
            email = value;
        }
    }

    public Administrator()
    {
        
    }
    public Administrator(string name, string email,string pass) {

        
        this.name = name;
        this.email = email;
        this.pass = pass;      
    }
}