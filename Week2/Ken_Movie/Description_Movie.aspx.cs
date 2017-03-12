using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Data;

public partial class Description_Movie : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Get_Poster();
            Get_ID();
            Get_Movie_Title();
            Get_Actor_Movie();
            Get_Director_Movie();
            Get_Average_Rating();
            Get_Genre_Movie();
            Views_Movie();
            Get_Movie_Description();
            Get_Distribution_Rating();
        }

    }
    private void Get_Poster()
    {
        Movie_Poster.ImageUrl = Global.GetName;

    }

    private void Get_ID()
    {
        string CS = ConfigurationManager.ConnectionStrings["Movie_Database"].ConnectionString;
        string[] mov_dir;
        string movie_title;
        string movie_director;

        mov_dir = Path.GetFileNameWithoutExtension(Global.GetName).Split('_');
        movie_title = mov_dir[0];
        movie_director = mov_dir[1];

        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("spGet_movie_ID", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
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

    private void Get_Movie_Title() /*solution temporaire I will put the path of the image directly in the database*/
    {
        string[] mov_dir;
        string movie_title;
        mov_dir = Path.GetFileNameWithoutExtension(Global.GetName).Split('_');
        movie_title = mov_dir[0];
        Movie_Title.Text = movie_title;
    }

    private void Get_Actor_Movie()
    {
        string CS = ConfigurationManager.ConnectionStrings["Movie_Database"].ConnectionString;

        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("spActor_in_movie", con);
            cmd.CommandType = cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Movie_ID", Global.GetID);

            con.Open();
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    ListItem li = new ListItem();
                    li.Text = (string)rdr["First_Name"] + " " + (string)rdr["Last_Name"];
                    Actor_in_Movie.Items.Add(li);
                }
            }
        }
    }
    private void Get_Director_Movie() /*solution temporaire I will put the path of the image directly in the database*/
    {
        string[] mov_dir;
        string movie_director;
        mov_dir = Path.GetFileNameWithoutExtension(Global.GetName).Split('_');
        movie_director = mov_dir[1];
        Director_Movie.Text = "Director: " + movie_director;
    }

    private void Get_Average_Rating()
    {
        string CS = ConfigurationManager.ConnectionStrings["Movie_Database"].ConnectionString;
        string Avr_Rating;

        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("spRating_Movie", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Movie_ID", Global.GetID);

            con.Open();
            Avr_Rating = cmd.ExecuteScalar().ToString();

            Average_Rating.Text = "Average Rating: " + Avr_Rating;
        }
    }
    private void Get_Genre_Movie()
    {
        string CS = ConfigurationManager.ConnectionStrings["Movie_Database"].ConnectionString;

        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("spGenre_of_Movies", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Movie_ID", Global.GetID);

            con.Open();
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    ListItem li = new ListItem();
                    li.Text = (string)rdr["Genre"];
                    Genre_Movie.Items.Add(li);
                }
            }
        }
    }

    private void Views_Movie()
    {
        string CS = ConfigurationManager.ConnectionStrings["Movie_Database"].ConnectionString;
        int views;

        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("spViews_Movie", con);
            cmd.CommandType = cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Movie_ID", Global.GetID);

            con.Open();
            views = Convert.ToInt32(cmd.ExecuteScalar());
            Number_of_views.Text = "Viewed: " + views;

        }
    }

    private void Get_Movie_Description()
    {
        string description;
        string CS = ConfigurationManager.ConnectionStrings["Movie_Database"].ConnectionString;

        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("spDescription_of_Movie", con);
            cmd.CommandType = cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Movie_ID", Global.GetID);

            con.Open();
            description = cmd.ExecuteScalar().ToString();
            Label_Description_Movie.Text = description;
        }

    }

    private void Get_Distribution_Rating()
    {
        string CS = ConfigurationManager.ConnectionStrings["Movie_Database"].ConnectionString;

        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("spDistribution_rating", con);
            cmd.CommandType = cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Movie_ID", Global.GetID);

            DataTable table = new DataTable();
            table.Columns.Add("Rating");
            table.Columns.Add("Distribution of the rating");

            con.Open();
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    DataRow dataR = table.NewRow();

                    if (rdr["rating"]==DBNull.Value) //Check if there's a null in the row
                    {
                        dataR["Rating"] = "No Star assigned";
                    }
                    else
                    {
                        dataR["Rating"] = rdr["rating"];
                    }

                    dataR["Distribution of the rating"] = rdr["Percentage movie distribution"];

                    table.Rows.Add(dataR);
                }
                GridView_Rating_distribution.DataSource = table;
                GridView_Rating_distribution.DataBind();
            }


        }
    }

    private void Get_Comments_Movie()
    {
        string CS = ConfigurationManager.ConnectionStrings["Movie_Database"].ConnectionString;

        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("spComment_From", con);
            cmd.CommandType = cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Movie_ID", Global.GetID);

            DataTable table = new DataTable();
            table.Columns.Add("Comment");
            table.Columns.Add("Comment From");

            con.Open();
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        DataRow dataR = table.NewRow();
                        dataR["Comment"] = rdr["comment"];
                        dataR["Comment From"] = rdr["Comment from"];
                        table.Rows.Add(dataR);

                    }

                    Comments_Movies.DataSource = table;
                    Comments_Movies.DataBind();

                }
                else
                {
                    No_Comments.Text = "There's no comments for the movie for now";
                }
            }
        }
    }
}


