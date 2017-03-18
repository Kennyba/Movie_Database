<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Description_Actor.aspx.cs" Inherits="Description_Actor" MasterPageFile="~/Site.master" %>

  <asp:Content ID="Description_Actor" ContentPlaceHolderID="Content_Body" runat="server">
    <div>
        <asp:Image ID="Actor_Picture" runat="server" />
        <br />
        <p>Description</p>
        <%--This is a list that gives a description of the actor (name, sex, date of birth, % of the user that like him, country of birth)--%>
        <asp:BulletedList ID="Actor_Description" runat="server">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem></asp:ListItem>
            <asp:ListItem></asp:ListItem>
            <asp:ListItem></asp:ListItem>
            <asp:ListItem></asp:ListItem>
        </asp:BulletedList>
        <br />
        <p>Movie in:</p>
        <%--Gives a list of the movie that the actor is in --%>
        <asp:BulletedList ID="Movie_in" runat="server">
        </asp:BulletedList>
    
    </div>
</asp:Content>