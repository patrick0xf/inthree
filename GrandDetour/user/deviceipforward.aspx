<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="deviceipforward.aspx.cs" Inherits="GrandDetour.user.DeviceIPForward" MasterPageFile="~/user/User.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="cphHead">
    <script language=javascript>
     var int = self.setInterval("clock()", 1000);
     function clock() {
         var frame = document.getElementById("frame");
         if (frame.title == "Compiling") frame.location.reload();       
     }
</script>   
    <style type="text/css">
        .style1 {
            text-decoration: underline;
        }
    </style>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="cphMain">
    <a href="home.aspx"><font color="blue">main menu &crarr;</font></a>
<br/><br/><br/><br/><br/>
<h2><font color="black">Advanced Keypad Forwarding for <code><%=DeviceDisplay %></code></font></h2>
<br/><br/>
<table>
    <tr>
        <td>
            forward key
        </td>
        <td>
            <asp:TextBox runat="server" ID="txtKey" MaxLength="15"/>*
        </td>
    </tr>
    <tr>
        <td>
            external forward pattern
        </td>
        <td>
            <asp:TextBox runat="server" ID="txtExternalFowardPattern" MaxLength="255"/>**
        </td>
    </tr>
    <tr>
        <td>
            internal forward pattern
        </td>
        <td>
            <asp:TextBox runat="server" ID="txtInternalFowardPattern" MaxLength="255"/>***
        </td>
    </tr>
    <tr>
        <td>
            test mode
        </td>
        <td>
            <asp:CheckBox runat="server" ID="chkTestMode"/>****
        </td>
    </tr>
    <tr>
        <td>
            ios view port
        </td>
        <td>
            <asp:CheckBox runat="server" ID="chkIos"/>*****
        </td>
    </tr>
    <tr>
        <td>
            <asp:Button runat="server" Text="Cancel" ID="btnCancel" onclick="BtnCancelClick"/>
        </td>
        <td align="right">
            <asp:Button runat="server" Text="Save" ID="btnSave" onclick="BtnSaveClick"/>
        </td>
    </tr>
    <tr>
        <td>
            <br/><br/>
        </td>
    </tr>
    <tr>
        <td>
            your generated static url
        </td>
        <td>
            <code><asp:Label runat="server" ID="lblStaticUrl" 
                style="background-color: #99FF33"/></code>
        </td>
    </tr>
    <tr>
        <td>
            externally forwards to
        </td>
        <td>
            <code><asp:Label runat="server" ID="lblExternalForwardUrl"/></code>
        </td>
    </tr>
    <tr>
        <td>
            internally forwards to
        </td>
        <td>
            <code><asp:Label runat="server" ID="lblInternalForwardUrl"/></code>
        </td>
    </tr>
</table>
<hr/>
<H1>CLICK <a href="http://www.in3myhome.com/advanced-keypad-forwarding">HERE</a> FOR FULL HELP</H1>
<hr/>
    <span class="style1">Quick Setup Guide:
</span>
    <br />
<br/>
* turns IP forward on by adding your own forward key (15 chars limit)
<br/>
turns IP forward off by clearing out the key field
<hr/>
** external forward pattern must be fully qualified url, where $ is the format item where you IP is inserted
<br/>
<code>http://$:88/pda</code>
<br/>
*** internal forward pattern is your device's internal network url
<br/>
<code>http://honeywell/pda</code>
<hr/>
**** When test mode is "on", static link stops short of forwarding when in test mode. Use test mode to set bookmarks 
<br/>
<hr/>
***** ios view port requires pda page <a href="http://www.in3myhome.com/advanced-keypad-forwarding-3">mod</a> installed BEFORE bookmarks are set
<br/>
</asp:Content>
