using System;
using System.Web;
using GrandDetour.Core;

namespace GrandDetour.Backspace
{
    public partial class Login : AccountPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Request.Cookies.Clear();
        }

        protected void BtnLoginClick(object sender, EventArgs e)
        {
            if (IsIPLocked(SiteName.Backspace, Request.UserHostAddress))
            {
                txtPassword.Text = String.Empty;
                txtPassword.Focus();
            }

            //TODO this needs to be re-wired somewhere
            if(txtLogin.Text.Hash() == "admin" &&
                txtPassword.Text.Hash() == "admin")
            {
                Response.Cookies.Add(GetAdminLoginCookie(Request.Cookies["token"] ?? new HttpCookie("token")));
                Response.Redirect("home.aspx");
            }
            else
            {
                txtPassword.Text = String.Empty;
                txtPassword.Focus();
            }
        }

        private static HttpCookie GetAdminLoginCookie(HttpCookie cookie)
        {
            cookie.Value = DateTime.Now.HourlyToken("administrator");
            cookie.Expires = DateTime.Now.AddDays(1);
            return cookie;
        }
    }
}