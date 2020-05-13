using System;

namespace GrandDetour.Core
{
    public class AdminPage : AccountPage
    {
        protected override void OnPreInit(EventArgs e)
        {
            var cookie = Request.Cookies["token"];
            if (cookie != null)
            {
                if (!DateTime.Now.HasHourlyTokens(cookie.Value, 25, "administrator"))
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