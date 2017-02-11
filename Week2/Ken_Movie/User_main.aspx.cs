using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

public partial class User_main : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Get_user_ID();
        Personal_Data();

    }

    private int Get_user_ID()
    {
        int User_id;
        string username = "Ken";
        string CS = ConfigurationManager.ConnectionStrings["Movie_Database"].ConnectionString;

        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("Get_Client_ID", con);
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

    private void Personal_Data() {

        int user_ID =1;
        string CS = ConfigurationManager.ConnectionStrings["Movie_Database"].ConnectionString;

        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("Personal_info", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@user_ID_input", user_ID);

            con.Open();
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {

                    Profile_Info.Items[0].Text = "Name: " + rdr["First_Name"] + " " + rdr["Last_Name"];
                    Profile_Info.Items[1].Text = "Sex: " + rdr["Sex"];
                    Profile_Info.Items[2].Text = "Date of Birth: " + rdr["Date_Birth"];

                    if (System.IO.File.Exists("~/Images/User/" + rdr["First_Name"] + "_" + rdr["Last_Name"] + ".jpg"))
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



}