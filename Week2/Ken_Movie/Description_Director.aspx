<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Description_Director.aspx.cs" Inherits="Description_Director" %>

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

        <asp:Image ID="Director_Picture" runat="server" />
        <br />
        <p>Description</p>
        <asp:BulletedList ID="Director_Description" runat="server">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem></asp:ListItem>
            <asp:ListItem></asp:ListItem>
            <asp:ListItem></asp:ListItem>
        </asp:BulletedList>
        <br />
        <p>Directed Movie(s)</p>
        <asp:BulletedList ID="Directed_Movie" runat="server">
        </asp:BulletedList>
    
    </div>
    </form>
</body>
</html>
