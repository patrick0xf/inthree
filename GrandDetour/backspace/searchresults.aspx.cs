using System;
using System.Linq;
using GrandDetour.Core;
using Type = GrandDetour.Core.Type;

namespace GrandDetour.Backspace
{
    public partial class Searchresults : AccountPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var searchTerm = Request.QueryString[QUERY_SEARCH];
            var searchMode = Request.QueryString[QUERY_MODE];

            var accounts = new Account[]{};

            switch (searchMode)
            {
                case SEARCH_NUMBER:
                    accounts = Access.Accounts.Where(account => account.Number.Contains(searchTerm.ToLowerInvariant())).ToArray();
                    break;
                case SEARCH_HOLDER:
                    accounts = Access.Accounts.Where(account => account.Holder.ToLowerInvariant().Contains(searchTerm.ToLowerInvariant())).ToArray();
                    break;
                case SEARCH_EMAIL:
                    accounts = Access.Accounts.Where(account => account.Email.ToLowerInvariant().Contains(searchTerm.ToLowerInvariant())).ToArray();
                    break;
                case SEARCH_DEVICES:
                    accounts = Access.Accounts.Where(account => account.Devices != null && account.Devices.Any(device => device.MACAddress.ToLowerInvariant().Contains(searchTerm.ToLowerInvariant()))).ToArray();
                    break;
                case SEARCH_TRIAL:
                    accounts = Access.Accounts.Where(account => account.Type == Type.Trial).ToArray();
                    break;
                case SEARCH_EXPIRED:
                    accounts = Access.Accounts.Where(account => account.HasExpired).ToArray();
                    break;
                case SEARCH_INACTIVE:
                    accounts = Access.Accounts.Where(account => !account.IsActive).ToArray();
                    break;
                case SEARCH_ACTIVE_TRIAL:
                    accounts = Access.Accounts.Where(account => account.Type == Type.Trial && account.IsActive).ToArray();
                    break;
                case SEARCH_EXPIRES_ONE_MONTH:
                    accounts = Access.Accounts.Where(account => account.Type == Type.Ongoing && !account.HasExpired && account.ExpiresUtc < DateTime.UtcNow.AddMonths(1)).ToArray();
                    break;
            }

            foreach(var account in accounts)
            {
                account.Tag = String.Format("editaccount.aspx?{0}={1}", QUERY_NUMBER, account.Number);
            }

            rptAccounts.DataSource = accounts;
            rptAccounts.DataBind();

            rptEmails.DataSource = accounts;
            rptEmails.DataBind();
        }
    }
}