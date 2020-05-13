<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mydevices.aspx.cs" Inherits="GrandDetour.user.MyDevices" MasterPageFile="~/user/User.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="cphMain">
<a href="home.aspx"><font color="blue">main menu &crarr;</font></a>
<br/><br/><br/><br/><br/>
<h2><font color="black"><%=MyDevice %></font></h2>
<br/><br/>
    
    <asp:Repeater runat="server" ID="rptDevices">
        <HeaderTemplate>
            <table><tr><td align="center">device number</td><td align="center">|</td><td align="center">mac address</td><td align="center">|</td><td align="center">type</td><td align="center">|</td><td align="center">activity</td><td align="center">|</td><td align="center">last known ip</td></tr>
            <tr><td colspan="11"><hr/></td></tr>    
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
            <td align="center"><%# Container.ItemIndex + 1 %></td>
            <td align="center">&nbsp;</td>
            <td align="center"><code><%# DataBinder.Eval(Container.DataItem, "MACAddress") %></code></td>
            <td align="center">&nbsp;</td>
            <td align="center"><code><%# DataBinder.Eval(Container.DataItem, "Type") %><code></code></td>
            <td align="center">&nbsp;</td>
            <td align="center"><a href="deviceactivity.aspx?device=<%# Container.ItemIndex + 1 %>&filter=0">view log</a></td>
            <td align="center">&nbsp;</td>
            <td align="center"><code><%# DataBinder.Eval(Container.DataItem, "LastIP") %></code></td>
            <td align="center">&nbsp;</td>
            <td align="center"><a href="deviceipforward.aspx?device=<%# Container.ItemIndex + 1 %>&filter=0">advanced keypad forwarding</a></td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
