using System;
using System.Linq;

namespace GrandDetour.Core
{
    public class UserPage : AccountPage
    {
        protected Account Account;

        protected override void OnPreInit(EventArgs e)
        {        
            var cookie = Request.Cookies["token"];
            var email = Request.Cookies["email"];

            if (cookie != null && email != null)
            {
                Account = Access.Accounts.SingleOrDefault(a => a.Email.ToUpperInvariant() == email.Value.ToUpperInvariant());

                if (Account != null && !Account.HasExpired)
                {
                    if (!DateTime.Now.HasHourlyTokens(cookie.Value, 25, Account.Number))
                    {
                        Response.Redirect("login.aspx", true);
                    }
                    else
                    {
                        Title = String.Format("in3myhome user panel - {0}", email.Value);
                    }
                }
                else
                {
                    Response.Redirect("login.aspx", true);    
                }
            }
            else
            {
                Response.Redirect("login.aspx", true); 
            }
        }
    }
}