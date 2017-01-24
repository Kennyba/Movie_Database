using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Main_page : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {

            LoadDataMovie();

        };

    }

    private void LoadDataMovie() {

        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\dbMovie_week1.mdf;Integrated Security=True");
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT * FROM movie", con);
        SqlDataReader dr = cmd.ExecuteReader();
        GridView_movie.DataSource = dr;
        GridView_movie.DataBind();
        con.Close();

    }
}