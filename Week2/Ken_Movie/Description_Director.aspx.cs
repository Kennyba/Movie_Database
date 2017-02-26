using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

public partial class Description_Director : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Get_Director_ID();
        Director_Info();
        Liked_by();
        List_of_Movies();
    }

    private void Get_Director_ID()
    {
        string name_director;
        name_director = Path.GetFileNameWithoutExtension(Global.GetName);
        string CS = ConfigurationManager.ConnectionStrings["Movie_Database"].ConnectionString;
        
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("spGet_Director_ID", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", name_director);

            con.Open();
            object id_director =cmd.ExecuteScalar();
            Global.GetID = Convert.ToInt32(id_director);
        }


    }

    private void Director_Info()
    {
        string CS = ConfigurationManager.ConnectionStrings["Movie_Database"].ConnectionString;

        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("spPersonnal_info_director", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@director_ID", Global.GetID);

            con.Open();
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {

                    Director_Description.Items[0].Text = "Name: " + rdr["Name"];
                    Director_Description.Items[1].Text = "Sex: " + rdr["Sex"];
                    Director_Description.Items[2].Text = "Date of Birth: " + rdr["Date_Birth"];
                    Director_Description.Items[3].Text = "Country: " + rdr["Country"];
                    Director_Picture.ImageUrl = Global.GetName;

                }
            }
        }
    }

    private void Liked_by()
    {
        string CS = ConfigurationManager.ConnectionStrings["Movie_Database"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("spPercentage_Liked_director", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@director_ID", Global.GetID);

            con.Open();
            object objpercentage = cmd.ExecuteScalar();
            string percentage_liked = Convert.ToString(objpercentage);

            Director_Description.Items[4].Text = "Liked by " + percentage_liked + "% from our users";


        }

    }
    private void List_of_Movies()
    {
        Directed_Movie.Items.Clear();

        string CS = ConfigurationManager.ConnectionStrings["Movie_Database"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("spdirector_list_of_Movie",con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@director_ID", Global.GetID);

            con.Open();
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                { 
                    ListItem li = new ListItem();
                    li.Text = (string)rdr["Movie_title"];
                    Directed_Movie.Items.Add(li);
                }
            }
        }
    }
}