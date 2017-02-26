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
        Get_Director_Picture();
       
    }

    private void Get_Director_ID()
    {
        string name_director;
        int id_director;

        name_director = Path.GetFileNameWithoutExtension(Global.GetName);
        string CS = ConfigurationManager.ConnectionStrings["Movie_Database"].ConnectionString;

        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("spGet_Director_ID", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", name_director);

            con.Open();
            id_director = (int)cmd.ExecuteScalar();
            Global.GetID = id_director;
        }

        
    }

    private void Get_Director_Picture()
    {
        Director_Picture.ImageUrl = Global.GetName;
    }


}