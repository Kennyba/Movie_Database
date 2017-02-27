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
        if (!IsPostBack)
        { 
            Get_Poster_Movie();
        }
    }
    
    private void Get_Poster_Movie()
    {
        /* I will put in fileName the name of the file
         * The name of the file contains the name of the file and the director of the movie
         * After, I will do a split to put the title of the movie in movie_title
         * and the name of the director in director_of_movie
         * The split will be in the string array mov_dir
         */
       
        string[] mov_dir;
        string movie_title;
        string director_of_movie;
        string image_title;

        string[] filePaths = Directory.GetFiles(Server.MapPath("~/Images/Movie/"));
        List<ListItem> files = new List<ListItem>();
        foreach (string filePath in filePaths)
        {
            string fileName = Path.GetFileNameWithoutExtension(filePath);//taking name of the file
            mov_dir = fileName.Split('_');//split to put in array mov_dir
            movie_title = mov_dir[0];//Take the movie title
            director_of_movie = mov_dir[1];//Take director name
            image_title = movie_title+" (" +mov_dir[1]+")";//Text under each image

            files.Add(new ListItem(image_title, "~/Images/Movie/" + fileName + ".jpg"));
        }
        DataList_Movie.DataSource = files;
        DataList_Movie.DataBind();
    }


    protected void DataList_Movie_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName=="Get_Url")
        {
            ImageButton btn= e.CommandSource as ImageButton;
            Global.GetName = btn.ImageUrl;
            Response.Redirect("Description_Movie.aspx");
        }
    }
}


