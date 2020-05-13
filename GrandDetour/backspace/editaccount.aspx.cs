using System;
using System.Globalization;
using GrandDetour.Core;
using System.Linq;
using Type = GrandDetour.Core.Type;

namespace GrandDetour.Backspace
{
    public partial class Editaccount : AccountPage
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

            txtHolder.Text = Account.Holder;
            txtEmail.Text = Account.Email;
            ckbTrial.Checked = Account.Type == Type.Trial;
            calExpires.SelectedDate = Account.ExpiresUtc;
            calExpires.VisibleDate = Account.ExpiresUtc;

            lblActive.Text = Account.IsActive.ToString(CultureInfo.InvariantCulture);

            btnDevices.NavigateUrl = String.Format("devices.aspx?{0}={1}", QUERY_NUMBER, Account.Number);
            btnPassword.NavigateUrl = String.Format("resetpassword.aspx?{0}={1}", QUERY_NUMBER, Account.Number);
            btnPayments.NavigateUrl = String.Format("payments.aspx?{0}={1}", QUERY_NUMBER, Account.Number);

            var timeZoneIDs = TimeZoneInfo.GetSystemTimeZones().Select(tz => tz.Id).Reverse().ToList();
            timeZoneIDs.Insert(0, "device");
            ddlTimeZone.DataSource = timeZoneIDs;
            ddlTimeZone.SelectedValue = Account.GetSelectedTimeZone();
            ddlTimeZone.DataBind();
        }

        protected void BtnSaveClick(object sender, EventArgs e)
        {
            Account.Holder = txtHolder.Text;
            Account.Email = txtEmail.Text;
            Account.TimeZoneId = ddlTimeZone.SelectedValue;
            var expires = calExpires.SelectedDate;
            Account.SetNewTerm(ckbTrial.Checked ? Type.Trial : Type.Ongoing, new DateTime(expires.Year, expires.Month, DateTime.DaysInMonth(expires.Year, expires.Month), 0, 0, 0, DateTimeKind.Utc).AddDays(1).AddSeconds(-1));

            DoSave(Account, String.Format("editaccount.aspx?{0}={1}", QUERY_NUMBER, Account.Number));
        }

        protected void BtnDeleteClick(object sender, EventArgs e)
        {
            DoDelete(Account, String.Format("editaccount.aspx?{0}={1}", QUERY_NUMBER, Account.Number));
        }
    }
}