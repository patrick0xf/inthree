using System;
using System.Web;

namespace GrandDetour.user
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Title = "login to in3myhome user panel";
            Response.Cookies.Add(new HttpCookie("token", String.Empty));
        }
    }
}