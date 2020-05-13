using System;
using GrandDetour.Core;

namespace GrandDetour.Backspace
{
    public partial class Create : AccountPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("editaccount.aspx?{0}={1}", QUERY_NUMBER, Access.AddAccount()));
        }
    }
}