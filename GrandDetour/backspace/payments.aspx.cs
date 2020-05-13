using System;
using GrandDetour.Core;

namespace GrandDetour.Backspace
{
    public partial class Payments : AccountPage
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
            if (Account.Payments != null)
            {
                rptPayments.DataSource = Account.Payments;
                rptPayments.DataBind();
            }
            calDate.SelectedDate = DateTime.Now;
            lblNewExpiration.Text = "autorenewson".AsSetting();
        }

        protected void RptDevicesItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
        {
            if (e.CommandName != "Delete") return;
            Account.RemovePayment(Int32.Parse(e.CommandArgument.ToString()));
            DoSave(Account, String.Format("payments.aspx?{0}={1}", QUERY_NUMBER, Account.Number));
        }

        protected void BtnAddClick(object sender, EventArgs e)
        {
            int cents;
            if(!Int32.TryParse(txtCents.Text, out cents))
            {
                Response.Redirect(String.Format("message.aspx?{0}={1}", QUERY_MESSAGE, "Amount not a number"));
            }

            Account.AddPayment(calDate.SelectedDate, txtNote.Text.Trim(), cents);
            DoSave(Account, String.Format("payments.aspx?{0}={1}", QUERY_NUMBER, Account.Number));
        }

        protected void BtnAddRenewClick(object sender, EventArgs e)
        {
            int cents;
            if (!Int32.TryParse(txtCents.Text, out cents))
            {
                Response.Redirect(String.Format("message.aspx?{0}={1}", QUERY_MESSAGE, "Amount not a number"));
            }

            Account.AddPayment(calDate.SelectedDate, txtNote.Text.Trim(), cents);
            Account.SetNewTerm(Core.Type.Ongoing, DateTime.Parse("autorenewson".AsSetting()));
            DoSave(Account, String.Format("autothankyou.aspx?{0}={1}", QUERY_NUMBER, Account.Number));
        }
    }
}