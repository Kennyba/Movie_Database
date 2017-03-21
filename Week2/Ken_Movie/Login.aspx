<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<%--This is the login page. I used an ASP controller--%>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%--I needed the jquery script to make work the login page--%>
    <script src="Script/jquery-3.1.1.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Login ID="Login_Movie" runat="server" DestinationPageUrl="~/User_main.aspx" OnAuthenticate="Login_Movie_Authenticate"></asp:Login>
    </div>
    </form>
</body>
</html>
