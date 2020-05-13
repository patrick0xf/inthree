using System;
using GrandDetour.Core;

namespace GrandDetour.Backspace
{
    public partial class Devices : AccountPage
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
            rptDevices.DataSource = Account.Devices;
            rptDevices.DataBind();
        }

        protected void RptDevicesItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
        {
            if (e.CommandName != "Delete") return;
            Account.RemoveDevice(Int32.Parse(e.CommandArgument.ToString()));
            DoSave(Account, String.Format("devices.aspx?{0}={1}", QUERY_NUMBER, Account.Number));
        }

        protected void BtnAddClick(object sender, EventArgs e)
        {
            Account.AddDevice("00:0e:70:00:" + txtMACAddress.Text.ToLowerInvariant(), txtType.Text);
            DoSave(Account, String.Format("devices.aspx?{0}={1}", QUERY_NUMBER, Account.Number));
        }
    }
}