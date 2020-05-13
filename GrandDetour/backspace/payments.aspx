<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="payments.aspx.cs" Inherits="GrandDetour.Backspace.Payments" %>

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
                <asp:Repeater runat="server" ID="rptPayments" 
                    onitemcommand="RptDevicesItemCommand">
                <ItemTemplate>
                <tr>
                    <td>
                        Payment  
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "Date") %>
                        &nbsp;&nbsp;|&nbsp;                        
                        <%# DataBinder.Eval(Container.DataItem, "Note") %>
                        &nbsp;&nbsp;|&nbsp;
                        <%# DataBinder.Eval(Container.DataItem, "AmountInCents") %>
                        &nbsp;&nbsp;&nbsp;|&nbsp;
                        <asp:Button ID="Button1" runat="server" Text="x" CommandName="Delete" CommandArgument='<%#DataBinder.Eval(Container, "ItemIndex", String.Empty)%>'/>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        &nbsp;
                    </td>
                </tr>
                </ItemTemplate>
                </asp:Repeater>
                <tr>
                    <td colspan="2">
                        <hr/>
                        New Payment
                        <hr/>
                    </td>
                </tr>
                <tr>
                    <td>
                        Date
                    </td>
                    <td>
                        <asp:Calendar runat="server" ID="calDate"/> 
                    </td>
                </tr>
                <tr>
                    <td>
                        Note
                    </td> 
                    <td>
                        <asp:TextBox runat="server" ID="txtNote"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        &cent;
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtCents"/>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td align="left">
                        <asp:Button runat="server" ID="btnAdd" Text="Add Payment Record" onclick="BtnAddClick"/>
                    </td>
                </tr>
                                <tr>
                    <td></td>
                    <td align="left">
                        <asp:Button runat="server" ID="btnAddAndRenew" Text="Add & Renew + 1 year" onclick="BtnAddRenewClick"/>
                        <br />
                        <asp:Label ID="lblNewExpiration" runat="server" />
                    </td>
                </tr>
            </table>
        </center>    
    </div>
    </form>
</body>
</html>
