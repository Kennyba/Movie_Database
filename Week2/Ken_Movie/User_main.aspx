<%@ Page Language="C#" AutoEventWireup="true" CodeFile="User_main.aspx.cs" Inherits="User_main" %>

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

                <li><a>Profile</a></li>
                <li><a>Movies</a></li>
                <li><a>Actors</a></li>
                <li><a>Directors</a></li>
                <li><a>About KenMovie</a></li>

            </ul>
        </div>

        <div class="profile_info">
            
            <asp:Image runat="server" ImageUrl="~/Images/Movie/No_Image_Profile.jpg" ID="profile_pic"></asp:Image>
            
            <ul id="user_info">

                <li id="Name"></li>
                <li id="Sex"></li>
                <li id="Date_of_birth"></li>

            </ul>
            
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
