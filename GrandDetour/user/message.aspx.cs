using System;
using GrandDetour.Core;

namespace GrandDetour.user
{
    public partial class Message : AccountPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = Request.QueryString[QUERY_MESSAGE];
        }
    }
}