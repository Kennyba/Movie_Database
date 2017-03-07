<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Description_Director.aspx.cs" Inherits="Description_Director" MasterPageFile="~/Site.master" %>

<asp:Content ID="Description_Director" ContentPlaceHolderID="Content_Body" runat="server">
    <div>

        <asp:Image ID="Director_Picture" runat="server" />
        <br />
        <p>Description</p>
        <asp:BulletedList ID="Director_Description" runat="server">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem></asp:ListItem>
            <asp:ListItem></asp:ListItem>
            <asp:ListItem></asp:ListItem>
            <asp:ListItem></asp:ListItem>
        </asp:BulletedList>
        <br />
        <p>Directed Movie(s)</p>
        <asp:BulletedList ID="Directed_Movie" runat="server">
        </asp:BulletedList>
    
    </div>
</asp:Content>
