<%@ Page Language="C#" AutoEventWireup="true" CodeFile="List_Movie.aspx.cs" Inherits="List_Movie" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="menu">
            <ul>

                <li><a href="User_main.aspx">Profile</a></li>
                <li><a href="List_Movie.aspx">Movies</a></li>
                <li><a href="List_Actors.aspx">Actors</a></li>
                <li><a href="List_Directors.aspx">Directors</a></li>
                <li><a href="Info_KenMovie.aspx">Info KenMovie</a></li>

            </ul>
        </div>

        <div id="list_movie">
            
            <asp:GridView runat="server" ID="Movie_List">

            </asp:GridView>

            
        </div>

        


  
    </div>
    </form>
</body>
</html>
