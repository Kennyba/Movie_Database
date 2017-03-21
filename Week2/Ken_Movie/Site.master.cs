using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Site : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)//Welcome the user on the label
    {
        if (!IsPostBack)
        {
            string username = Convert.ToString(Session["username"]);
            Welcome_User.Text = "Welcome " + username;
        }
    }

protected void Logout_Button_Click(object sender, EventArgs e)//Button to logout of the website
    {
        Session.Clear();
        Response.Redirect("Login.aspx");
    }


}