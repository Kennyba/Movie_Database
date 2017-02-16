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



public partial class List_Movie : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Get_Poster_Movie();

    }

    private void Get_Poster_Movie()
    {
        string[] filePaths = Directory.GetFiles(Server.MapPath("~/Images/Movie/"));
        List<ListItem> files = new List<ListItem>();
        foreach (string filePath in filePaths)
        {
            string fileName = Path.GetFileNameWithoutExtension(filePath);
            files.Add(new ListItem(fileName, "~/Images/Movie/" + fileName + ".jpg"));
        }
        DataList_Movie.DataSource = files;
        DataList_Movie.DataBind();
    }

}


