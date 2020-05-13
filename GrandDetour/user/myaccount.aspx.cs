using System;
using GrandDetour.Core;

namespace GrandDetour.user
{
    public partial class MyAccount : UserPage
    {
        protected string Holder
        {
            get { return Account.Holder; }
        }

        protected string Email
        {
            get { return Account.Email; }
        }

        protected string Type
        {
            get { return Account.Type == Core.Type.Trial ? "trial" : "ongoing support. thank you!"; }
        }

        protected string ExpiresUtc
        {
            get { return Account.ExpiresUtc.ToShortDateString().ToLowerInvariant(); }
        }

        protected string Devices
        {
            get { return String.Format("{0} device{1}", Account.Devices.Length, Account.Devices.Length == 1 ? String.Empty : "s"); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}