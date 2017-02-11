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
        Personal_Data();

    }

    private int Get_user_ID()
    {
        int User_id;
        string username = "Ken";
        string CS = ConfigurationManager.ConnectionStrings["Movie_Database"].ConnectionString;




        return User_id;

    }

    private void Personal_Data() {

        string username ="Ken";
        string CS = ConfigurationManager.ConnectionStrings["Movie_Database"].ConnectionString;

        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("Personal_info", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@username_input", username);

            con.Open();
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {

                    Profile_Info.Items[0].Text = "Name: " + rdr["First_Name"] + " " + rdr["Last_Name"];
                    Profile_Info.Items[1].Text = "Sex: " + rdr["Sex"];
                    Profile_Info.Items[2].Text = "Date of Birth: " + rdr["Date_Birth"];
                    profile_pic.ImageUrl = "~/Images/User/" + rdr["First_Name"] + "_" + rdr["Last_Name"] + ".jpg";

                }

            }


        }

    }



}