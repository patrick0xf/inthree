<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="resetpassword.aspx.cs" Inherits="GrandDetour.Backspace.ResetPassword" %>

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
                        <a href="home.aspx">&lt;- Home</a>
                    </td>
                    <td/>
                </tr>                
                <tr>
                    <td>
                        Account Number:
                    </td>
                    <td>
                        <%=Account.Number %>
                    </td>
                </tr>
                <tr>
                    <td>
                        Account Type:
                    </td>
                    <td>
                        <%=Account.Type %>
                    </td>
                </tr>
                <tr>
                    <td>
                        New Password:
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtPassword"/>
                    </td>
                </tr>
                <tr>
                    <td/>
                    <td>
                        <asp:Button ID="btnReset" runat="server" Text="Reset" onclick="BtnResetClick"/>

                    </td>
                </tr>
                <tr>
                    <td/>
                    <td>
                        <asp:Button runat="server" Text="Disable" ID="btnDisable" 
                            onclick="BtnDisableClick"/>
                    </td>
                </tr>
            </table>
        </center>
    </div>
    </form>
</body>
</html>
