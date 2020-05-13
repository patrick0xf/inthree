<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="searchresults.aspx.cs" Inherits="GrandDetour.Backspace.Searchresults" %>

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
                <asp:Repeater runat="server" ID="rptAccounts">
                <ItemTemplate>
                    <tr>
                        <td>
                            <a href="<%# DataBinder.Eval(Container.DataItem, "Tag") %>"><%# DataBinder.Eval(Container.DataItem, "Number") %> </a>
                        </td>
                        <td>
                            <%# DataBinder.Eval(Container.DataItem, "Holder") %> (<%# DataBinder.Eval(Container.DataItem, "Email") %>)
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <font color="<%# DataBinder.Eval(Container.DataItem, "Type").ToString() == "Trial" ? "blue" : "black"%>">
                                <%# DataBinder.Eval(Container.DataItem, "Type").ToString() %>
                            </font>
                        </td>
                        <td>
                            <font color="<%# DataBinder.Eval(Container.DataItem, "HasExpired").ToString() == "True" ? "red" : "green"%>">
                                <%# DataBinder.Eval(Container.DataItem, "ExpiresUtc").ToString() %>  
                            </font>&nbsp;
                           (<font color="<%# DataBinder.Eval(Container.DataItem, "IsActive").ToString() == "True" ? "green" : "red"%>">
                                <%# DataBinder.Eval(Container.DataItem, "IsActive").ToString() == "True" ? "Active" : "Inactive"%>
                            </font>)
                        </td>
                    </tr>    
                    <tr>
                        <td/>
                        <td>
                           <%# DataBinder.Eval(Container.DataItem, "DevicesAsString").ToString().Replace(" ", "&nbsp;").Replace(Environment.NewLine, "</br>") %>  
                        </td>
                    </tr>
                   
                </ItemTemplate>
                <SeparatorTemplate>
                    <tr>
                        <td>&nbsp;</td><td>-</td>
                    </tr>
                </SeparatorTemplate>
                </asp:Repeater>
            </table>
            <hr/>
        </center>
        <code>
        <asp:Repeater runat="server" ID="rptEmails">
            <ItemTemplate>
                <%# DataBinder.Eval(Container.DataItem, "Email") %>,&nbsp;
                <br/>
            </ItemTemplate>   
        </asp:Repeater>
        </code>
    </div>
    </form>
</body>
</html>
