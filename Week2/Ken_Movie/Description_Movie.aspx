<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Description_Movie.aspx.cs" Inherits="Description_Movie"  MasterPageFile="~/Site.master"%>

<asp:Content ID="Description_Movie" ContentPlaceHolderID="Content_Body" runat="server">
        <div id="Poster">
            <asp:Image ID="Movie_Poster" runat="server" />
            <asp:Label ID="Movie_Title" runat="server" Text="Label"></asp:Label>
        </div>

        <div id="Information">
            <p>Actors</p>
            <asp:BulletedList ID="Actor_in_Movie" runat="server"></asp:BulletedList>

            <asp:Label ID="Director_Movie" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Average_Rating" runat="server" Text="Label"></asp:Label>

            <p>Genre</p>
            <asp:BulletedList ID="Genre_Movie" runat="server"></asp:BulletedList>

            <asp:Label ID="Number_of_views" runat="server" Text="Label"></asp:Label>

            <p>Description</p>
            

        </div>

        <div id="Rating distribution">
            <asp:GridView runat="server" ID="Rating_distribution"></asp:GridView>
        </div>

        <div id="Comments">
            <asp:GridView runat="server" ID="Comments_Movies"></asp:GridView>
        </div>
</asp:Content>
