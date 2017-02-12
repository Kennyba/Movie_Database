<%@ Page Language="C#" AutoEventWireup="true" CodeFile="User_main.aspx.cs" Inherits="User_main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <div id="option_user">
            <asp:DropDownList ID="DropDownList_User" runat="server">
                <asp:ListItem>Ken</asp:ListItem>
                <asp:ListItem>bob4eva</asp:ListItem>
                <asp:ListItem>MeltingCh33se</asp:ListItem>
                <asp:ListItem>Collier</asp:ListItem>
                <asp:ListItem>DaFighter</asp:ListItem>
            </asp:DropDownList>

            <asp:Button ID="User_change" runat="server" Text="Change User" OnClick="User_change_Click" />

        </div>

        <div id="menu">
            <ul>

                <li><a href="User_main.aspx">Profile</a></li>
                <li><a href="List_Movie.aspx">Movies</a></li>
                <li><a href="List_Actors.aspx">Actors</a></li>
                <li><a href="List_Directors.aspx">Directors</a></li>
                <li><a href="Info_KenMovie.aspx">Info KenMovie</a></li>

            </ul>
        </div>

        <div class="profile_info">
            
            <asp:Image runat="server"  ID="profile_pic"></asp:Image>

            <asp:BulletedList ID="Profile_Info" runat="server">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem></asp:ListItem>
                <asp:ListItem></asp:ListItem>
            </asp:BulletedList>
 
            
            <asp:Button ID="Button_Friend_List" runat="server" Text="List of Friends" />
        </div>


        <div class="Liked_element">
            <p>Genre Liked</p>
            <ul class="Liked_list" id="genre">

            </ul>
            <asp:Button ID="Button_Genre" runat="server" Text="Modify" />
        </div>
        
       <div class="Liked_element" >
            <p>Actor Liked</p>
            <ul class="Liked" id="actor">

            </ul>
            <asp:Button ID="Button_Actor" runat="server" Text="Modify" />
       </div>
        
       <div class="Liked_element">
            <p>Director Liked</p>
            <ul class="Liked" id="director">

            </ul>
           <asp:Button ID="Button_Director" runat="server" Text="Modify" />
       </div>

        <asp:GridView ID="GridView_Recommend_movie" runat="server"></asp:GridView>
        <asp:GridView ID="GridView_Movie_seen" runat="server"></asp:GridView>
        <asp:GridView ID="GridView_Comment" runat="server"></asp:GridView>
    
    </div>
    </form>
</body>
</html>
