using System;
using System.Linq;
using System.Web;
using GrandDetour.Core;

namespace GrandDetour.user
{
    public partial class Login : AccountPage
    {
        public string ErrorMessage { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "login to in3myhome user panel";
            var email = Request.Cookies["email"];
            if (!IsPostBack && email != null)
            {
                txtLogin.Text = email.Value;
                txtPassword.Focus();
            }
            Response.Cookies.Clear();
        }

        protected void BtnLoginClick(object sender, EventArgs e)
        {
            ErrorMessage = "invalid user name or password";

            if (!IsIPLocked(SiteName.User, Request.UserHostAddress))
            {
                var account = Access.Accounts.SingleOrDefault(a => a.Email.ToUpperInvariant() == txtLogin.Text.ToUpperInvariant());

                if (account != null)
                {
                    if (txtPassword.Text.Hash(account.Number) == account.Password)
                    {
                        if (!account.HasExpired)
                        {
                            Response.Cookies.Add(GetAccountLoginCookie(Request.Cookies["token"] ?? new HttpCookie("token"),  account.Number));
                            Response.Cookies.Add(new HttpCookie("email", account.Email));
                            Response.Redirect("home.aspx");
                            return;
                        }

                        ErrorMessage = "your account has expired";
                    }
                }
            }
     
            txtPassword.Text = String.Empty;
            txtPassword.Focus();
           
        }

        private static HttpCookie GetAccountLoginCookie(HttpCookie cookie, string accountNumber)
        {
            cookie.Value = DateTime.Now.HourlyToken(accountNumber);
            cookie.Expires = DateTime.Now.AddDays(1);
            return cookie;
        }
    }
}