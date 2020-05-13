using System;
using System.Linq;
using GrandDetour.Core;
using Type = GrandDetour.Core.Type;

namespace GrandDetour.Backspace
{
    public partial class Home : AdminPage
    {
        protected string SystemMessage
        {
            get
            {
                var trial = Access.Accounts.Where(accounts => accounts.Type == Type.Trial).Sum(account => account.Devices.SafeCount());
                var pay = Access.Accounts.Where(accounts => accounts.Type == Type.Ongoing).Sum(account => account.Devices.SafeCount());
                return String.Format("Currently serving {0} devices in trial, {1} for pay.", trial, pay);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}