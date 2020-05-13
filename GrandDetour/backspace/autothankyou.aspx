<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="autothankyou.aspx.cs" Inherits="GrandDetour.Backspace.AutoThankYou" %>

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
                    <td>Subject</td>
                    <td align="left"><asp:TextBox ID="txtSubject" runat="server"/></td>
                </tr>
                <tr>
                    <td>Message</td>
                    <td><asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine" Width="400" Height="200"/></td>
                </tr>
                <tr>
                    <td />
                    <td align="left"><asp:Button Text="Send" runat="server" OnClick="Send_Click" /></td>
                </tr>
            </table>
        </center>    
    </div>
    </form>
</body>
</html>
