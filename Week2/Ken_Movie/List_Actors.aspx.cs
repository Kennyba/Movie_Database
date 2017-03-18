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
        if (!IsPostBack)//if I don't put !IspostBack I will get an error why ?
        {
            Get_Actor_Picture();//method that fill the datalist
        }
            
    }

    private void Get_Actor_Picture()
    {
        string[] filePaths = Directory.GetFiles(Server.MapPath("~/Images/Actor/")); //I put in an array all the images that are in the indicated path.
        List<ListItem> files = new List<ListItem>(); //I create a list where each element is a ListItem
        foreach (string filePath in filePaths)
        {
            string fileName = Path.GetFileNameWithoutExtension(filePath);//Get the name of the actor (it is the name of the image)
            files.Add(new ListItem(fileName, "~/Images/Actor/" + fileName + ".jpg"));
            //in the list, I add a Listitem. 
            //the first argument of the constructor is the Text, and the second is the Value
            //the code delimiter Eval will take the Text as the name of the actor, and the Value as the Url of the image of the actor.
        }
        DataList_Actor.DataSource = files;
        DataList_Actor.DataBind();
    }

    protected void DataList_Actor_ItemCommand(object source, DataListCommandEventArgs e)
    // This function is used when an image is click
    {
        if (e.CommandName == "Get_Url")
        {
            ImageButton btn = e.CommandSource as ImageButton;
            Global.GetName = btn.ImageUrl;
            Response.Redirect("Description_Actor.aspx");
            // when the image is click, I put in the public property Global.GetName the URL of the image
            //This will be used in the page Description_Actor.aspx
        }
    }
}