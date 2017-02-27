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
            <!-- Following code was taken from this site 
           http://www.aspsnippets.com/Articles/Bind-Display-images-in-DataList-from-folder-in-ASPNet-using-C-and-VBNet.aspx -->

            <asp:DataList ID="DataList_Movie" runat="server" RepeatColumns="4" CellPadding="5" OnItemCommand="DataList_Movie_ItemCommand">
                <ItemTemplate>
                    <table>
                        <tr>
                            <td>
                                <asp:ImageButton ID="Poster_Movie" ImageUrl='<%# Eval("Value") %>' runat="server" Height="100" CommandName="Get_Url"
                                    Width="100" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%# Eval("Text") %>
                            </td>
                        </tr>

                    </table>
                </ItemTemplate>

            </asp:DataList>

            
        </div>

        


  
    </div>
    </form>
</body>
</html>
