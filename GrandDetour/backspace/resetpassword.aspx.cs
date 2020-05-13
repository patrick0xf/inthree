using System;
using GrandDetour.Core;

namespace GrandDetour.Backspace
{
    public partial class ResetPassword : AccountPage
    {
        protected Account Account;

        protected void Page_Load(object sender, EventArgs e)
        {
            Account = Access.GetAccount(Request.QueryString[QUERY_NUMBER]);

            if (Account != null) return;

            Response.Redirect(String.Format("message.aspx?{0}={1}", QUERY_MESSAGE, "Account Not Found"));
        }

        protected void BtnResetClick(object sender, EventArgs e)
        {
            Account.Password = txtPassword.Text.Hash(Account.Number);
            DoSave(Account, String.Format("editaccount.aspx?{0}={1}", QUERY_NUMBER, Account.Number));
        }

        protected void BtnDisableClick(object sender, EventArgs e)
        {
            Account.Password = "#";
            DoSave(Account, String.Format("editaccount.aspx?{0}={1}", QUERY_NUMBER, Account.Number));
        }
    }
}