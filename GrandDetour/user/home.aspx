<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="GrandDetour.user.Home" MasterPageFile="~/user/User.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="cphMain">
<font color="white"></font>
<br/><br/><br/><br/><br/>
<h2><font color="black">main menu</font></h2>
<br/><br/>
<a href="myaccount.aspx">full account information</a>
<br/>
<a href="mydevices.aspx"><%=MyDevices %></a>
<br/>
<a href="mysettings.aspx">settings &amp; preferences</a>
</asp:Content>
