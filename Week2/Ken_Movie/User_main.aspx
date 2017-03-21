<%@ Page Language="C#" AutoEventWireup="true" CodeFile="User_main.aspx.cs" Inherits="User_main" MasterPageFile="~/Site.master" %>

<asp:Content ID="User_Profile" ContentPlaceHolderID="Content_Body" runat="server">
    <div class="profile_info">

        <asp:Image runat="server" ID="profile_pic"></asp:Image><%--Profile picture of the user--%>

        <asp:BulletedList ID="Profile_Info" runat="server">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem></asp:ListItem>
            <asp:ListItem></asp:ListItem>
        </asp:BulletedList>


        <asp:Button ID="Button_Friend_List" runat="server" Text="List of Friends" /> <%--Button that will show the list of friends of the user (doesn't work for now)--%>
    </div>


    <div class="Liked_element"> <%--Genres liked by the user, he can modify this list by clicking on the button (doesn't work for now)--%>
        <p>Genre Liked</p>

        <asp:BulletedList ID="BulletedList_GenreLiked" runat="server">
        </asp:BulletedList>

        <asp:Button ID="Button_Genre" runat="server" Text="Modify" />
    </div>

    <div class="Liked_element"> <%--Actor liked by the user, he can modify this list by clicking on the button (doesn't work for now)--%>
        <p>Actor Liked</p>

        <asp:BulletedList ID="BulletedList_ActorLiked" runat="server">
        </asp:BulletedList>

        <asp:Button ID="Button_Actor" runat="server" Text="Modify" />
    </div>

    <div class="Liked_element"><%--Director liked by the user, he can modify this list by clicking on the button (doesn't work for now)--%>
        <p>Director Liked</p>

        <asp:BulletedList ID="BulletedList_DirectorLiked" runat="server">
        </asp:BulletedList>

        <asp:Button ID="Button_Director" runat="server" Text="Modify" />
    </div>

    <br />

    <asp:GridView ID="GridView_Recommend_movie" runat="server"></asp:GridView> <%--List of movie recommended by another user--%>
    <br />
    <asp:GridView ID="GridView_Movie_seen" runat="server"></asp:GridView> <%--List of movie that the user has seen--%>
    <br />
    <asp:GridView ID="GridView_Comment" runat="server"></asp:GridView> <%--List of comments that he has gives--%>

</asp:Content>
