using System;
using GrandDetour.Core;

namespace GrandDetour.Backspace
{
    public partial class AutoThankYou : AccountPage
    {
        protected Account Account;

        protected void Page_Load(object sender, EventArgs e)
        {
            Account = Access.GetAccount(Request.QueryString[QUERY_NUMBER]);

            if (Account == null)
            {
                Response.Redirect(String.Format("message.aspx?{0}={1}", QUERY_MESSAGE, "Account Not Found"));
                return;
            }

            if (IsPostBack) return;

            var firstName = Account.Holder.Contains(" ") ? Account.Holder.Split(' ')[0] : Account.Holder;

            txtSubject.Text = "autothankyousubject".AsSetting();
            var a = String.Format("autothankyoubody".AsSetting(), firstName);
            txtMessage.Text = String.Format("autothankyoubody".AsSetting(), firstName).Replace("*", Environment.NewLine);
        }

        protected void Send_Click(object sender, EventArgs e)
        {
            Mailer.SendSupportMail(Account.Email, txtSubject.Text, txtMessage.Text);
            Response.Redirect("home.aspx");
        }
    }
}