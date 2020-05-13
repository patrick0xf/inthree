<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editaccount.aspx.cs" Inherits="GrandDetour.Backspace.Editaccount" %>
<%@ Import Namespace="GrandDetour.Core" %>

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
                            Trial <asp:CheckBox runat="server" ID="ckbTrial"/>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Holder:
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtHolder" Width="300"/>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Email:
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtEmail" Width="300"/>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Expires:
                        </td>
                        <td>
                            <asp:Calendar runat="server" ID="calExpires"/> 
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Has Active Device:
                        </td>
                        <td>
                            <asp:Label runat="server" ID="lblActive"/>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Time zone:
                        </td>
                        <td>
                            <asp:DropDownList runat="server" ID="ddlTimeZone"/>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Devices:
                        </td>
                        <td>
                            <%=Account.Devices.SafeCount() %>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Payment Notes:
                        </td>
                        <td>
                            <%=Account.Payments.SafeCount() %>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Password:
                        </td>
                        <td>
                            <%=Account.Password == "#" ? "Disabled" : "Hashed" %>
                        </td>
                    </tr>
                    <tr>
                        <td/>
                        <td>
                            <asp:Button runat="server" ID="btnSave" Text="Save" onclick="BtnSaveClick"/>
                        </td>
                    </tr>
                    <tr>
                        <td/>
                        <td>
                            <asp:Button runat="server" ID="btnDelete" Text="Delete" onclick="BtnDeleteClick"/>
                        </td>
                    </tr>
                    <tr>
                        <td/>
                        <td>
                                <hr/>   
                        </td>                    
                    </tr>
                    <tr>
                        <td/>
                        <td>
                                More account settings
                        </td>                    
                    </tr>
                    <tr>
                        <td/>
                        <td>
                                <hr/>   
                        </td>                    
                    </tr>
                    <tr>
                        <td/>
                        <td>
                            <asp:HyperLink runat="server" ID="btnPayments" Text="Manage Payments"/>
                        </td>
                    </tr>
                    <tr>
                        <td/>
                        <td>
                            <asp:HyperLink runat="server" ID="btnDevices" Text="Manage Devices"/>
                        </td>
                    </tr>
                    <tr>
                        <td/>
                        <td>
                            <asp:HyperLink runat="server" ID="btnPassword" Text="Reset Password"/>
                        </td>
                    </tr>

                </table>
            </center>
    </div>
    </form>
</body>
</html>

