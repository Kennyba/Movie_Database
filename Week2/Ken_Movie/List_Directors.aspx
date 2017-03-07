<%@ Page Language="C#" AutoEventWireup="true" CodeFile="List_Directors.aspx.cs" Inherits="List_Directors" MasterPageFile="~/Site.master" %>


<asp:Content ID="Description_Director" ContentPlaceHolderID="Content_Body" runat="server">

    <div id="list_director">
        <!-- Following code was taken from this site 
           http://www.aspsnippets.com/Articles/Bind-Display-images-in-DataList-from-folder-in-ASPNet-using-C-and-VBNet.aspx -->
        <asp:DataList ID="DataList_Director" runat="server" RepeatColumns="4" CellPadding="5" OnItemCommand="Director_Image_ItemCommand">
            <ItemTemplate>
                <table>
                    <tr>
                        <td>
                            <asp:ImageButton ID="Image_Director" ImageUrl='<%# Eval("Value")%>' runat="server" Height="100" Width="100" CommandName="Get_Url" />
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
