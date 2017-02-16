using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Data;

public partial class List_Actors : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Get_Actor_Picture();
    }

    private void Get_Actor_Picture()
    {
        string[] filePaths = Directory.GetFiles(Server.MapPath("~/Images/Actor/"));
        List<ListItem> files = new List<ListItem>();
        foreach (string filePath in filePaths)
        {
            string fileName = Path.GetFileNameWithoutExtension(filePath);
            files.Add(new ListItem(fileName, "~/Images/Actor/" + fileName + ".jpg"));
        }
        DataList_Actor.DataSource = files;
        DataList_Actor.DataBind();
    }
}