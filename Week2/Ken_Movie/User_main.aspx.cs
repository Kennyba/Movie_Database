using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

public partial class User_main : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        int User_Id_Client = Get_user_ID();//Getting the user ID
        Personal_Data(User_Id_Client);//Function that will give the name, sex and date of birth of the user
        Genre_User_liked(User_Id_Client);//Function that will give the genre of movie that the user like
        Actor_User_liked(User_Id_Client);//Function that will give the actors that the user like
        Director_User_liked(User_Id_Client);//Function that will give the directors that the user like
        Recommended_Mov_from(User_Id_Client);//Function that give the list of movie that was recommended for the user
        Movie_Seen(User_Id_Client);//Function that the list of movies that have been seen by the user
        Comment_Movie(User_Id_Client);//Function that gives the comments that the user have made
    }

    private int Get_user_ID()
    {
        int User_id;
        string username = Convert.ToString(Session["username"]);
        string CS = ConfigurationManager.ConnectionStrings["Movie_Database"].ConnectionString;

        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("Get_Client_ID", con);
            /*(Not a good way, not sure): this procedure will give the ID of the user.
             * I put the user ID in a output parameter
             * I could simply do a procedure that give only the user ID and do after
             * an ExecuterScalar*/
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@username", username);

            SqlParameter outParam = new SqlParameter();
            outParam.ParameterName = "@user_id";
            outParam.SqlDbType = System.Data.SqlDbType.Int;
            outParam.Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add(outParam);

            con.Open();
            cmd.ExecuteNonQuery();

            User_id =(int)outParam.Value;
         }

        return User_id;
    }

    private void Personal_Data(int U_ID) {

        int user_ID = U_ID;
        string CS = ConfigurationManager.ConnectionStrings["Movie_Database"].ConnectionString;

        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("Personal_info", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@user_ID_input", user_ID);

            con.Open();
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())//rdr will only have one line with the column First_Name, Last_Name, Sex and Date_Birth
                {

                    Profile_Info.Items[0].Text = "Name: " + rdr["First_Name"] + " " + rdr["Last_Name"];
                    Profile_Info.Items[1].Text = "Sex: " + rdr["Sex"];
                    Profile_Info.Items[2].Text = "Date of Birth: " + rdr["Date_Birth"];

                    if (File.Exists(Server.MapPath("~/Images/User/" + rdr["First_Name"] + "_" + rdr["Last_Name"] + ".jpg")))//Condition that will verify if the user has a picture
                    {
                        profile_pic.ImageUrl = "~/Images/User/" + rdr["First_Name"] + "_" + rdr["Last_Name"] + ".jpg";
                    }
                    else
                    {
                        profile_pic.ImageUrl = "~/Images/User/No_Image_Profile.jpg";

                    }
                }
            }
        }
    }

    private void Genre_User_liked(int U_ID)
    {
        int user_ID = U_ID;
        string CS = ConfigurationManager.ConnectionStrings["Movie_Database"].ConnectionString;

        BulletedList_GenreLiked.Items.Clear();

        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("Genre_Liked_user", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@user_id", user_ID);

            con.Open();
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                while(rdr.Read())
                {
                    ListItem li = new ListItem();
                    li.Text = (string)rdr["genre"];
                    BulletedList_GenreLiked.Items.Add(li);
                }
           
            }
        }
    }

    private void Actor_User_liked(int U_ID)
    {
        int user_ID = U_ID;
        string CS = ConfigurationManager.ConnectionStrings["Movie_Database"].ConnectionString;

        BulletedList_ActorLiked.Items.Clear();

        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("Actor_Liked_user", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@user_id", user_ID);

            con.Open();
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    ListItem li = new ListItem();
                    li.Text = rdr["First_Name"]+" "+rdr["Last_Name"];
                    BulletedList_ActorLiked.Items.Add(li);
                }

            }
        }
    }

    private void Director_User_liked(int U_ID)
    {
        int user_ID = U_ID;
        string CS = ConfigurationManager.ConnectionStrings["Movie_Database"].ConnectionString;

        BulletedList_DirectorLiked.Items.Clear();

        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("Director_Liked_user", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@user_id", user_ID);

            con.Open();
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    ListItem li = new ListItem();
                    li.Text = rdr["First_Name"] + " " + rdr["Last_Name"];
                    BulletedList_DirectorLiked.Items.Add(li);
                }

            }
        }
    }

    private void Recommended_Mov_from(int U_ID)
    {
        int user_ID = U_ID;
        string CS = ConfigurationManager.ConnectionStrings["Movie_Database"].ConnectionString;

        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("Recommended_Movie_From", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@user_id", user_ID);

            con.Open();

            GridView_Recommend_movie.DataSource = cmd.ExecuteReader();
            GridView_Recommend_movie.DataBind();

        }

    }

    private void Movie_Seen(int U_ID)
    {
        int user_ID = U_ID;
        string CS = ConfigurationManager.ConnectionStrings["Movie_Database"].ConnectionString;

        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("spMovie_seen", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@user_id", user_ID);

            con.Open();

            GridView_Movie_seen.DataSource = cmd.ExecuteReader();
            GridView_Movie_seen.DataBind();

        }

    }

    private void Comment_Movie(int U_ID)
    {
        int user_ID = U_ID;
        string CS = ConfigurationManager.ConnectionStrings["Movie_Database"].ConnectionString;

        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("Comment_Client_Movie", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@user_id", user_ID);

            con.Open();

            GridView_Comment.DataSource = cmd.ExecuteReader();
            GridView_Comment.DataBind();

        }

    }
}