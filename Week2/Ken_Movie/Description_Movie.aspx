﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Description_Movie.aspx.cs" Inherits="Description_Movie" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="Poster">
            <asp:Image ID="Movie_Poster" runat="server" />
            <asp:Label ID="Movie_Title" runat="server" Text="Label"></asp:Label>
        </div>

        <div id="Information">
            <p>Actors</p>
            <asp:BulletedList ID="Actor_in_Movie" runat="server"></asp:BulletedList>

            <asp:Label ID="Director_Movie" runat="server" Text="Label"></asp:Label>

            <asp:Label ID="Average_Rating" runat="server" Text="Label"></asp:Label>

            <p>Genre</p>
            <asp:BulletedList ID="BulletedList1" runat="server"></asp:BulletedList>

            <asp:Label ID="Number_of_views" runat="server" Text="Label"></asp:Label>

            <p>Description</p>
            <asp:TextBox ID="Description_movie" runat="server"></asp:TextBox>

        </div>

        <div id="Rating distribution">
            <asp:GridView runat="server" ID="Rating_distribution"></asp:GridView>
        </div>

        <div id="Comments">
            <asp:GridView runat="server" ID="Comments_Movies"></asp:GridView>
        </div>


    
    </div>
    </form>
</body>
</html>
