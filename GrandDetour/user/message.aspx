<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="message.aspx.cs" Inherits="GrandDetour.user.Message" MasterPageFile="~/user/User.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="cphMain">
<a href="home.aspx"><font color="blue">main menu &crarr;</font></a>
<br/><br/><br/><br/><br/>
<h2><font color="black">error</font></h2>
<br/><br/>
<br/><br/>
    <center>
        <asp:Label runat="server" ID="lblMessage"/>
        <br/><br/>
        <a href="home.aspx">Home</a>
    </center>
</asp:Content>
