using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web.UI.WebControls;
using Twilio;
public partial class AllMovies : System.Web.UI.Page
{
    MySqlConnection conn;
    MySqlCommand cmd;

    String queryStr;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();

        }
    }

    protected void BindData()
    {


        String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebbAppConnString"].ToString();
        DataTable dt = new DataTable();
        using (MySqlConnection cn = new MySqlConnection(connString))
        {


            MySqlDataAdapter adp = new MySqlDataAdapter("Select id,title,category,artists,price,quantity from movies", cn);
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                allMoviesTable.DataSource = dt;
                allMoviesTable.DataBind();
            }
        }

    }


    private void DeleteRecord(string id)
    {


        try
        {
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebbAppConnString"].ToString();
            conn = new MySqlConnection(connString);
            conn.Open();
            queryStr = "";
            queryStr = "delete from movies where id='" + id + "'";
            cmd = new MySqlCommand(queryStr, conn);
            cmd.ExecuteReader();
            conn.Close();
        }
        catch (System.Data.SqlClient.SqlException ex)
        {
            string msg = "Deletion Error:";
            msg += ex.Message;
            throw new Exception(msg);

        }

    }

    protected void allCustomersTable_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string id = allMoviesTable.Rows[e.RowIndex].Cells[2].Text;       
        DeleteRecord(id);
        BindData();
    }

    protected void allMoviesTable_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = allMoviesTable.SelectedRow;

        string id = row.Cells[2].Text;
        System.Diagnostics.Debug.Write("IDD: "+id);
        Session["myID"] = id;
        Response.Redirect("ChangeMovie.aspx");
    }
}