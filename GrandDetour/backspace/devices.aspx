<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="devices.aspx.cs" Inherits="GrandDetour.Backspace.Devices" %>

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
                <asp:Repeater runat="server" ID="rptDevices" 
                    onitemcommand="RptDevicesItemCommand">
                <ItemTemplate>
                <tr>
                    <td>
                        Device  
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "MACAddress") %>
                        &nbsp;&nbsp;|&nbsp;
                        <%# DataBinder.Eval(Container.DataItem, "Type") %>
                        &nbsp;&nbsp;&nbsp;|&nbsp;
                        <asp:Button ID="Button1" runat="server" Text="x" CommandName="Delete" CommandArgument='<%#DataBinder.Eval(Container, "ItemIndex", String.Empty)%>'/>
                    </td>
                </tr>
                </ItemTemplate>
                </asp:Repeater>
                <tr>
                    <td>
                        New Device:
                    </td>
                    <td>
                        00:0e:70:00:<asp:TextBox runat="server" ID="txtMACAddress" Width="35"/>
                        &nbsp;|&nbsp;
                        <asp:TextBox runat="server" ID="txtType" Text="icm" Width="35"/>
                        &nbsp;|&nbsp;
                        <asp:Button runat="server" ID="btnAdd" Text="+" onclick="BtnAddClick"/>
                    </td>
                </tr>
            </table>
        </center>    
    </div>
    </form>
</body>
</html>
