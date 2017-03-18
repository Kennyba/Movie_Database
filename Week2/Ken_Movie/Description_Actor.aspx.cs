using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

public partial class Description_Actor : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Get_Actor_ID(); /*Get the id of the actor in the database*/
            Actor_Info(); /*using the actor id to get the information about the actor*/
            Liked_by(); /*give the percentage of the user that likes the actor*/
            List_of_Movies(); /*give the list in which the actor is in*/
        }

    }

    private void Get_Actor_ID()
    {
        string name_actor;
        name_actor = Path.GetFileNameWithoutExtension(Global.GetName); /*The name of the actor is in the title of the image*/
        string CS = ConfigurationManager.ConnectionStrings["Movie_Database"].ConnectionString; 

        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("spGet_Actor_ID", con); /*procedure that gives the id of the actor*/
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", name_actor);

            con.Open();
            object id_actor = cmd.ExecuteScalar();
            Global.GetID = Convert.ToInt32(id_actor); /*Getting the id and put it in the property Global.GetID*/
        }


    }

    private void Actor_Info()
    {
        string CS = ConfigurationManager.ConnectionStrings["Movie_Database"].ConnectionString;

        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("spPersonnal_info_Actor", con); /*procedure that gives the personnal info of the actor*/
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Actor_id", Global.GetID);

            con.Open();
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read()) /*the procedure will give a table with one row. This row have a column for the name, sex, date of birth and the country of birth*/
                {

                    Actor_Description.Items[0].Text = "Name: " + rdr["Name"];
                    Actor_Description.Items[1].Text = "Sex: " + rdr["Sex"];
                    Actor_Description.Items[2].Text = "Date of Birth: " + rdr["Date_Birth"];
                    Actor_Description.Items[3].Text = "Country: " + rdr["Country"];
                    Actor_Picture.ImageUrl = Global.GetName;

                }
            }
        }
    }

    private void Liked_by()
    {
        string CS = ConfigurationManager.ConnectionStrings["Movie_Database"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("spPercentage_Liked_Actor", con); /*procedure that give the % List_of_Movies user that like the actor*/
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Actor_id", Global.GetID);

            con.Open();
            object objpercentage = cmd.ExecuteScalar();
            string percentage_liked = Convert.ToString(objpercentage);

            Actor_Description.Items[4].Text = "Liked by " + percentage_liked + "% from our users";


        }

    }
    private void List_of_Movies()
    {
        Movie_in.Items.Clear();

        string CS = ConfigurationManager.ConnectionStrings["Movie_Database"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("spActor_list_of_Movie", con); /*procedure that give the list of movie that the actor was in*/
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Actor_ID", Global.GetID);

            con.Open();
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read()) /*each movie will be put in the bulleted list (ID="Movie_in")*/
                {
                    ListItem li = new ListItem();
                    li.Text = (string)rdr["Movie_Title"];
                    Movie_in.Items.Add(li);
                }
            }
        }
    }

}