using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Description_Director : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Get_Director_Picture();
    }

    private void Get_Director_Picture()
    {
        Director_Picture.ImageUrl = Global.GetName;
    }
    
}