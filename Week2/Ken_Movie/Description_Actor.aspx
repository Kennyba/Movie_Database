<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Description_Actor.aspx.cs" Inherits="Description_Actor" MasterPageFile="~/Site.master" %>

  <asp:Content ID="List_Actor" ContentPlaceHolderID="Content_Body" runat="server">
    <div>
        <asp:Image ID="Actor_Picture" runat="server" />
        <br />
        <p>Description</p>
        <asp:BulletedList ID="Actor_Description" runat="server">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem></asp:ListItem>
            <asp:ListItem></asp:ListItem>
            <asp:ListItem></asp:ListItem>
            <asp:ListItem></asp:ListItem>
        </asp:BulletedList>
        <br />
        <p>Movie in:</p>
        <asp:BulletedList ID="Movie_in" runat="server">
        </asp:BulletedList>
    
    </div>
</asp:Content>