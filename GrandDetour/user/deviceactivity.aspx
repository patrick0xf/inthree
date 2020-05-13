<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="deviceactivity.aspx.cs" Inherits="GrandDetour.user.DeviceActivity" MasterPageFile="~/user/User.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="cphHead">
 <script language=javascript>
     var int = self.setInterval("clock()", 1000);
     function clock() {
         var frame = document.getElementById("frame");
         if (frame.title == "Compiling") frame.location.reload();       
     }
</script>   
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="cphMain">
<a href="home.aspx"><font color="blue">main menu &crarr;</font></a>
<br/><br/><br/><br/><br/>
<h2><font color="black"><code><%=DeviceInfo %></code></font></h2>
<br/><br/>
<br/><br/>
<%=FilterTitle %><br/>
<a href="<%=DeviceLogUrl%>&download=true">&dArr; as file</a>
<br/>
<iframe id="frame"  width="500" height="200" src="<%=DeviceLogUrl%>"></iframe>
<br/>
<%=FilterToggle %>
</asp:Content>
