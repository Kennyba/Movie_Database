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

public partial class List_Directors : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)//if I don't put !IspostBack I will get an error why ?
        {
            Get_Director_Picture();
        }
        
    }
    private void Get_Director_Picture()
    {
        string[] filePaths = Directory.GetFiles(Server.MapPath("~/Images/Director/"));
        List<ListItem> files = new List<ListItem>();
        foreach (string filePath in filePaths)
        {
            string fileName = Path.GetFileNameWithoutExtension(filePath);
            files.Add(new ListItem(fileName, "~/Images/Director/" + fileName + ".jpg"));
        }
        DataList_Director.DataSource = files;
        DataList_Director.DataBind();
    }

 

 protected void Director_Image_ItemCommand(object sender, DataListCommandEventArgs e)
    {
        if(e.CommandName == "Get_Url")
        {
            ImageButton btn = e.CommandSource as ImageButton;
            Test.Text = btn.ImageUrl;
        }

    }



}