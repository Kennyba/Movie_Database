<%@ Page Language="C#" AutoEventWireup="true" CodeFile="List_Actors.aspx.cs" Inherits="List_Actors" MasterPageFile="~/Site.master" %>

    <asp:Content ID="List_Actor" ContentPlaceHolderID="Content_Body" runat="server">
<%--        This Datalist will give a list of image separated on 4 columns.
        Each item of the datalist is table of 2 rows.
        The first row is the image of the actor.
        The second row the name of the actor.
        --%>
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

</asp:Content>

