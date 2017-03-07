<%@ Page Language="C#" AutoEventWireup="true" CodeFile="List_Actors.aspx.cs" Inherits="List_Actors" MasterPageFile="~/Site.master" %>

    <asp:Content ID="myContent" ContentPlaceHolderID="Content_Body" runat="server">
    
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

        <div id="list_actor">
            <!-- Following code was taken from this site 
           http://www.aspsnippets.com/Articles/Bind-Display-images-in-DataList-from-folder-in-ASPNet-using-C-and-VBNet.aspx -->
            <asp:DataList ID="DataList_Actor" runat="server" RepeatColumns="4" CellPadding="5" OnItemCommand="DataList_Actor_ItemCommand">
                <ItemTemplate>
                    <table>
                        <tr>
                            <td>
                                <asp:ImageButton ID="Image_Actor" ImageUrl='<%# Eval("Value") %>' runat="server" Height="100" CommandName="Get_Url"
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

</asp:Content>

