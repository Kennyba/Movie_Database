<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Description_Movie.aspx.cs" Inherits="Description_Movie" MasterPageFile="~/Site.master" %>

<asp:Content ID="Description_Movie" ContentPlaceHolderID="Content_Body" runat="server">
    <div id="Poster">
        <asp:image id="Movie_Poster" runat="server" />
        <asp:label id="Movie_Title" runat="server" text="Label"></asp:label>
    </div>

    <div id="Information">
        <p>Actors</p>
        
        <asp:bulletedlist id="Actor_in_Movie" runat="server"></asp:bulletedlist>

        <asp:label id="Director_Movie" runat="server" text="Label"></asp:label>
        <br />
        <br />
        <asp:label id="Average_Rating" runat="server" text="Label"></asp:label>

        <p>Genre</p>
        <asp:bulletedlist id="Genre_Movie" runat="server"></asp:bulletedlist>

        <asp:label id="Number_of_views" runat="server" text="Label"></asp:label>

        <p>Description</p>

        <asp:label id="Label_Description_Movie" style="word-wrap: break-word;" width="500px" runat="server" text="Label"></asp:label>

    </div>
    <br />

    <div id="Rating distribution">
        <p>Distribution of the rating </p>
        <asp:gridview runat="server" id="GridView_Rating_distribution"></asp:gridview>
    </div>

    <div id="Comments">
        <asp:gridview runat="server" id="Comments_Movies"></asp:gridview>
    </div>
</asp:Content>
