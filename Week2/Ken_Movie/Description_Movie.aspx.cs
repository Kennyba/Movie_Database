using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Description_Movie : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Get_poster();

    }

    private void Get_poster()
    {
        Movie_Poster.ImageUrl = Global.GetName;

    }
}