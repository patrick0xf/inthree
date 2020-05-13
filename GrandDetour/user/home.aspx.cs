using System;
using GrandDetour.Core;

namespace GrandDetour.user
{
    public partial class Home : UserPage
    {
        protected string MyDevices
        {
            get { return String.Format("view my device{0}", Account.Devices.Length == 1 ? String.Empty : "s"); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}