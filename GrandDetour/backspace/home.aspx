<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="GrandDetour.Backspace.Home" EnableSessionState="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <center>
        <%=SystemMessage %>
        <br/><br/>
        <a href="create.aspx">Add and edit</a>
        <br/>
        <a href="search.aspx">Search</a>
        </center>
    </div>
    </form>
</body>
</html>
