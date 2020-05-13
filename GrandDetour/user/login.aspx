<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="GrandDetour.user.Login" MasterPageFile="~/user/User.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="cphMain">
    <table>
         <tr>
            <td colspan="2" align="left">
                <font color="red"><%=ErrorMessage %></font>
            </td>
        </tr>
        <tr>
            <td>
                email
            </td>
            <td>
                <asp:TextBox ID="txtLogin" runat="server"/>
            </td>
        </tr>
        <tr>
            <td>
                password
            </td>
            <td>
                <asp:TextBox ID="txtPassword" TextMode="Password" runat="server"/>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="right">
                <asp:Button runat="server" Text="enter" 
                    style="font-family: Aharoni,Arial Bold;" ID="btnLogin" 
                    onclick="BtnLoginClick"/>
            </td>
        </tr>
        <tr>
             <td colspan="2" align="right">
                 <br/><br/><br/>
                 <font size="1">
                 <a href="mailto:support@in3myhome.com?subject=Password Reset Request">Forgot Password?</a>
                 </font>
             </td>
        </tr>
    </table>
</asp:Content>
