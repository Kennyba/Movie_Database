<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Description_Director.aspx.cs" Inherits="Description_Director" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Image ID="Director_Picture" runat="server" />
        <br />
        <p>Description</p>
        <asp:BulletedList ID="BulletedList1" runat="server">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem></asp:ListItem>
            <asp:ListItem></asp:ListItem>
            <asp:ListItem></asp:ListItem>
        </asp:BulletedList>
        <br />
        <p>Directed Movie(s)</p>
        <asp:BulletedList ID="Directed Movie" runat="server">

        </asp:BulletedList>
    
    </div>
    </form>
</body>
</html>
