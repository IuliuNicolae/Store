﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminTools : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }



    protected void linkAllCusomers_Click(object sender, EventArgs e)
    {
        Response.Redirect("AllCustomers.aspx");
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("RegisterNewMovie.aspx");
    }

    protected void LinkButton8_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewAdData.aspx");
    }

    protected void LinkButton9_Click(object sender, EventArgs e)
    {
        Response.Redirect("Test.cshtml");
    }

    protected void LinkButton10_Click(object sender, EventArgs e)
    {
        Response.Redirect("AllMovies.aspx");
    }
}