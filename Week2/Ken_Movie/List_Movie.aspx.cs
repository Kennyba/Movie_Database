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


    }

    private void Get_Poster_Movie()
    {
        int i;
        string CS = ConfigurationManager.ConnectionStrings["Movie_Database"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("SELECT Movie_Title FROM Movie", con);

            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                DataTable table = new DataTable();
                table.Columns.Add("1p");
                table.Columns.Add("2p");
                table.Columns.Add("3p");
                table.Columns.Add("4p");
                

                DataRow dataR = table.NewRow();
                Image img = new Image();
                HyperLink HL = new HyperLink();
                i = 1;

                while (rdr.Read())
                {

                    img.ImageUrl = "~/Images/Movie/" + rdr["Movie_Title"] + ".jpg";
                    HL.Text = (string)rdr["Movie_Title"];
                    dataR[i + "p"] = img + "<br/>" + HL;
                    i += 1;
                    if (i == 5)
                    {
                        table.Rows.Add(dataR);
                        i = 1;
                    }
                }
                con.Open();
                Movie_List.DataSource = table;
                Movie_List.DataBind();
            }


        }
    }

}


