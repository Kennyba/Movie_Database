<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Description_Movie.aspx.cs" Inherits="Description_Movie" MasterPageFile="~/Site.master" %>

<asp:Content ID="Description_Movie" ContentPlaceHolderID="Content_Body" runat="server">
    <div id="Poster"> <%--getting the poster and the title of the movie--%>
        <asp:image id="Movie_Poster" runat="server" />
        <asp:label id="Movie_Title" runat="server" text="Label"></asp:label>
    </div>

    <div id="Information">
        <p>Actors</p> <%--getting the actors that are in the movie--%>
        <asp:bulletedlist id="Actor_in_Movie" runat="server"></asp:bulletedlist>

        <asp:label id="Director_Movie" runat="server" text="Label"></asp:label> <%--getting the director of the movie--%>
        <br />
        <br />
        <asp:label id="Average_Rating" runat="server" text="Label"></asp:label> <%--getting the average rating that the user have put--%>

        <p>Genre</p> <%--genre of the movie--%>
        <asp:bulletedlist id="Genre_Movie" runat="server"></asp:bulletedlist>

        <asp:label id="Number_of_views" runat="server" text="Label"></asp:label> <%--number of time that the movie have been seen--%>

        <p>Description of the movie</p> <%--summary of the movie--%>
        <asp:label id="Label_Description_Movie" style="word-wrap: break-word;" width="500px" runat="server" text="Label"></asp:label>

    </div>
    <br />

    <div id="Rating distribution"> 
        <p>Distribution of the rating </p> <%--distribution of the rating--%>
        <asp:gridview runat="server" id="GridView_Rating_distribution"></asp:gridview>
    </div>
    <br />

    <div id="Comments">
        <p>Comment Section</p> <%--comment that user have put for the movie--%>
        <asp:label id="No_Comments" runat="server" text=""></asp:label>
        <asp:gridview runat="server" id="Comments_Movies"></asp:gridview>
    </div>
</asp:Content>
