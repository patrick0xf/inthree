using System;

namespace GrandDetour.user
{
    public partial class User : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblLogout.Visible = !Request.FilePath.Contains("log");
            lblWelcome.Visible = lblLogout.Visible;
            if(Page.Title.Contains("-")) lblWelcome.Text = String.Format("welcome {0}", Page.Title.Split('-')[1]);
        }
    }
}