<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="GrandDetour.Backspace.Login" EnableSessionState="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <center>
           <table>
               <tr>
                   <td>
                       Login
                   </td>
                   <td>
                       <asp:TextBox runat="server" ID="txtLogin"/>
                   </td>
               </tr>
               <tr>
                   <td>
                       Password
                   </td>
                   <td>
                       <asp:TextBox runat="server" ID="txtPassword"  TextMode="Password" />
                   </td>
               </tr>
               <tr>
                   <td/>
                   <td>
                       <asp:Button runat="server" ID="btnLogin" Text="Login" onclick="BtnLoginClick"/>
                   </td>
               </tr>
           </table>     
        </center>
    </div>
    </form>
</body>
</html>
