<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="myaccount.aspx.cs" Inherits="GrandDetour.user.MyAccount" MasterPageFile="~/user/User.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="cphMain">
<a href="home.aspx"><font color="blue">main menu &crarr;</font></a>
<br/><br/><br/><br/><br/>
<h2><font color="black">my account</font></h2>
<br/><br/>
<br/><br/>
<table>
    <tr>
        <td align="right">
            name
        </td>
        <td>
            &harr;
        </td>
        <td>
            <%=Holder %>
        </td>
    </tr>
    <tr>
        <td align="right">
            email
        </td>
        <td>
            &harr;
        </td>
        <td>
            <%=Email %>
        </td>
    </tr>
    <tr>
        <td align="right">
            account type
        </td>
        <td>
            &harr;
        </td>
        <td>
            <%=Type %>
        </td>
    </tr>
    <tr>
        <td align="right">
            service until
        </td>
        <td>
            &harr;
        </td>
        <td>
            <%=ExpiresUtc %> (utc)
        </td>
    </tr>
    <tr>
        <td align="right">
            devices
        </td>
        <td>
            &harr;
        </td>
        <td>
            <%=Devices %> (<a href="mydevices.aspx">details</a>)
        </td>
    </tr>
</table>
</asp:Content>
