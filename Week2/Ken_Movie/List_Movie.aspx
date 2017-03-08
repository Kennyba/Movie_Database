<%@ Page Language="C#" AutoEventWireup="true" CodeFile="List_Movie.aspx.cs" Inherits="List_Movie"  MasterPageFile="~/Site.master" %>

<asp:Content ID="Description_Movie" ContentPlaceHolderID="Content_Body" runat="server">
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
</asp:Content>

