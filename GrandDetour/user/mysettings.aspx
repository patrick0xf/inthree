<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mysettings.aspx.cs" Inherits="GrandDetour.user.MySettings" MasterPageFile="~/user/User.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="cphMain">
<a href="home.aspx"><font color="blue">main menu &crarr;</font></a>
<br/><br/><br/><br/><br/>
<h2><font color="black">my settings</font></h2>
<br/><br/>
<table>
        <tr>
            <td>
                Notification time stamp's zone*:
            </td>
            <td>
                <asp:DropDownList runat="server" ID="ddlTimeZone"/>
            </td>
        </tr>
        <tr>
            <td>
                Reset password (or leave blank**)
            </td>
            <td>
                <asp:TextBox TextMode="Password" runat="server" ID="txtPassword"/>
            </td>
        </tr>
        <tr>
            <td>
                Retype password
            </td>
            <td>
                <asp:TextBox TextMode="Password" runat="server" ID="txtPasswordMatch"/>
            </td>
        </tr>
        <tr>
            <td>
                <br/>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button runat="server" Text="Cancel" ID="btnCancel" 
                    onclick="BtnCancelClick"/>
            </td>
            <td align="right">
                <asp:Button runat="server" Text="Save" ID="btnSave" onclick="BtnSaveClick"/>
            </td>
        </tr>
</table>
<hr/>
* Select <i>device</i> to have your notifications time stamped by your device
<br/>
&nbsp;&nbsp;<u>or</u>
<br/>
&nbsp;&nbsp;&nbsp;Select a timezone to have your notifications time stamped by the datacenter upon dispatching
<hr/>
** Leave blank to keep your existing password. You will be logged out automatically upon changing your password.
</asp:Content>
