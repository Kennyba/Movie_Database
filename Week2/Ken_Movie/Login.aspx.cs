using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private bool UserLogin(string un, string pw)
    {
        string CS = ConfigurationManager.ConnectionStrings["Movie_Database"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("Login", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@username", un);
            cmd.Parameters.AddWithValue("@password", pw);
            con.Open();
            string result = Convert.ToString(cmd.ExecuteScalar());
            if(String.IsNullOrEmpty(result))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }

    protected void Login_Movie_Authenticate(object sender, AuthenticateEventArgs e)
    {
        string un = Login_Movie.UserName;
        string pw = Login_Movie.Password;
        bool result = UserLogin(un, pw);

        if (result)
        {
            e.Authenticated = true;
            Session["username"] = un;
        }
        else
        {
            e.Authenticated = false;
        }
    }
}