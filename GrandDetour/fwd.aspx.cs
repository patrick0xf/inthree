using System;
using System.Linq;
using GrandDetour.Core;

namespace GrandDetour
{
    public partial class Fwd : AccountPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var accountNumber = Request.QueryString[QUERY_ACCOUNT];
            var key = Request.QueryString[QUERY_KEY];

            if(String.IsNullOrEmpty(key) || String.IsNullOrEmpty(accountNumber))
            {
                Response.Redirect("/404");
            }
            else
            {
                var account = Access.GetAccount(accountNumber);

                if (account == null)
                {
                    Response.Redirect("/404");
                }
                else
                {
                    var device = account.Devices.FirstOrDefault(d => d.IPForwardKey == key);

                    if(device != null && !String.IsNullOrEmpty(device.LastIP))
                    {
                        var isInternal = device.LastIP == Request.UserHostAddress;

                        var forwardUrl = isInternal ? device.GetInternallyForwardsTo() : device.GetExternallyForwardsTo();

                        if (device.TestMode == "True")
                        {
                            Title = "in3MyHome";
                            lblMac.Text = device.MACAddress;
                            lblInternal.Text = isInternal ? "Yes" : "No";
                            lblRedirect.Text = forwardUrl ?? "No known LastIP, or bad forward pattern";
                            lblViewPort.Text = device.IosViewPort ? @"<meta name=""apple-mobile-web-app-capable"" content=""yes"" /><meta name=""viewport"" content=""width=device-width,user-scalable=no""/>" : "";
                        }
                        else
                        {
                            if(String.IsNullOrEmpty(forwardUrl))
                            {
                               Response.Redirect("/404"); 
                            }
                            else
                            {
                                Response.Write(String.Format(@"<html><head><title>in3MyHome</title><link rel=""apple-touch-icon"" href=""apple-touch-icon.png"" /><link rel=""shortcut icon"" href=""favicon.ico"" />{1}</head><body onload=""if({2})alert('Thank you for using in3myhome. Please consider a donation. Press OK to continue');if({3}){{alert('Your account has expired.'); return;}}window.location.href='{0}';"" style=""font-family: Aharoni,Arial Bold;"" vlink=""blue"" link=""blue"" alink=""blue""><center><table><tr><td colspan=""2"">", forwardUrl, device.IosViewPort ? @"<meta name=""apple-mobile-web-app-capable"" content=""yes"" /><meta name=""viewport"" content=""width=device-width,user-scalable=no""/>" : "", (account.Type == Core.Type.Trial).ToString().ToLowerInvariant(), account.HasExpired.ToString().ToLowerInvariant()));
                                Response.WriteFile("user/logo.inc", true);
                                Response.Write("</td></tr><tr><td align='center'><font face='Courier'>Contacting ICM</td><td><marquee>&nbsp;&nbsp;&nbsp;*</marquee></font></td></tr></table></center></body></html>");
                                Response.End();
                            }
                        }
                    }
                }
            }
        }
    }
}