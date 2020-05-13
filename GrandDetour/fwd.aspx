<%@ Page Language="C#" CodeBehind="fwd.aspx.cs" Inherits="GrandDetour.Fwd" AutoEventWireup="True" EnableViewState="False" %>
<html>
    <head runat="server">
        <title></title><link rel="apple-touch-icon" href="apple-touch-icon.png" /><link rel="shortcut icon" href="favicon.ico" /><asp:Literal runat="server" ID="lblViewPort"/>
    </head>
    <body style="font-family: Aharoni,Arial Bold;" vlink="blue" link="blue" alink="blue">
        <form id="form1" runat="server">
            <center>
                <table>
                    <tr>
                        <td colspan="2" align="center"><!--#include file="user/logo.inc"--></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <br/><br/><br/><br/>
                        </td>
                    </tr>
                    <tr>
                        <td>IP forward for</td><td><asp:Label runat="server" ID="lblMac"/>
                    </tr>
                    <tr>
                        <td>Is Internal</td><td><asp:Label runat="server" ID="lblInternal"/></td>
                    </tr>
                    <tr>
                        <td>Test Mode</td><td>On</td>
                    </tr>
                    <tr>
                        <td>Redirects to</td><td><asp:Label runat="server" ID="lblRedirect"/></td>
                    </tr>
                </table>
            </center>
        </form>
    </body>
</html>