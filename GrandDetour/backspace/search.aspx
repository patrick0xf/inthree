<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="search.aspx.cs" Inherits="GrandDetour.Backspace.Search" %>

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
                            Search Account Number:
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtNumber" Width="300"/>
                            <asp:Button runat="server" ID="btnNumber" Text="Search" 
                                onclick="BtnNumberClick"/>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Search Holder:
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtHolder" Width="300"/>
                            <asp:Button runat="server" ID="btnHolder" Text="Search" 
                                onclick="BtnHolderClick"/>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Search Email:
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtEmail" Width="300"/>
                            <asp:Button runat="server" ID="btnEmail" Text="Search" 
                                onclick="BtnEmailClick"/>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Search Devices:
                        </td>
                        <td>
                           <asp:TextBox runat="server" ID="txtDevices" Width="300"/>
                            <asp:Button runat="server" ID="btnDevices" Text="Search" 
                                onclick="BtnDevicesClick"/>
                        </td>
                    </tr>
                    <tr>
                        <td/>
                        <td align="right">
                            <asp:Button runat="server" ID="btnExpired" Text="Expired" 
                                onclick="BtnExpiredClick"/>
                        </td>
                    </tr>
                     <tr>
                        <td/>
                        <td align="right">
                            <asp:Button runat="server" ID="btnTrial" Text="Trial" onclick="BtnTrialClick"/>
                        </td>
                    </tr>
                    <tr>
                        <td/>
                        <td align="right">
                            <asp:Button runat="server" ID="btnInactive" Text="Inactive" 
                                onclick="BtnInactive"/>
                        </td>
                    </tr>
                    <tr>
                        <td/>
                        <td align="right">
                            <asp:Button runat="server" ID="btnActiveTrial" Text="Active Trial" 
                                onclick="BtnActiveTrial"/>
                        </td>
                    </tr>
                    <tr>
                        <td/>
                        <td align="right">
                            <asp:Button runat="server" ID="btnExpiresInAMonth" Text="Expires in a month" 
                                onclick="BtnExpiresInAMonth"/>
                        </td>
                    </tr>
            </table>
        </center>    
    </div>
    </form>
</body>
</html>
