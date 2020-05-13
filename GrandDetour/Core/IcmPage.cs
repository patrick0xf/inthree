using System;
using System.Linq;
using System.Web;

namespace GrandDetour.Core
{
    public abstract class IcmPage : EcoPage
    {
        protected Account Account { get; private set; }

        protected override bool HasAccess()
        {
            var userHostAddress = HttpContext.Current.Request.UserHostAddress;
            var currentDay = DateTime.UtcNow.Date;

            Account = Access.Accounts.SingleOrDefault(account => account.Devices != null && account.Devices.Any(device => device.MACAddress == Request.QueryString[QUERY_MAC] && device.LastIP == userHostAddress && device.LastDate == currentDay));

            if (Account != null)
            {
                //known MAC and ip
                return !Account.HasExpired;
            }

            Account = Access.Accounts.SingleOrDefault(account => account.Devices != null && account.Devices.Any(device => device.MACAddress == Request.QueryString[QUERY_MAC]));

            if(Account != null)
            {
                //known MAC only. Accept request, save IP.

                var device = Account.Devices.First(d => d.MACAddress == Request.QueryString[QUERY_MAC]);
                device.LastIP = userHostAddress;
                device.LastDate = currentDay;

                Access.UpdateAccount(Account);
                Access.Save("accessfilepath".AsSetting());
                ClearCache();

                return !Account.HasExpired;
            }

            return false;
        }
    }
}