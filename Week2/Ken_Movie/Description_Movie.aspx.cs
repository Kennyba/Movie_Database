using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

public partial class Description_Movie : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Get_poster();
        Get_ID();

    }
    private void Get_poster()
    {
        Movie_Poster.ImageUrl = Global.GetName;

    }

    private void Get_ID()
    {
        string CS= ConfigurationManager.ConnectionStrings["Movie_Database"].ConnectionString;
        string[] mov_dir;
        string movie_title;
        string movie_director;

        mov_dir = Path.GetFileNameWithoutExtension(Global.GetName).Split('_');
        movie_title = mov_dir[0];
        movie_director = mov_dir[1];

        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("spGet_movie_ID", con);
            cmd.CommandType= System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Movie_Title", movie_title);
            cmd.Parameters.AddWithValue("@Director_name", movie_director);

            con.Open();
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    Global.GetID = Convert.ToInt32(rdr["movie_id"]);
                }
            }

        }

    }


}