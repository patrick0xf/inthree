using System;
using System.Linq;
using System.Text;
using GrandDetour.Core;

namespace GrandDetour
{
    public class Time : EcoPage
    {
        protected override bool HasAccess()
        {
            return Access.Accounts.Any(a => a.Devices != null && a.Devices.Any(devices => devices.LastIP == Request.UserHostAddress) && !a.HasExpired);
        }

        protected override StringBuilder Respond()
        {
            var sb = new StringBuilder();
            sb.AppendLine("UNICN START");
            sb.AppendLineFormat("time={0}", DateTime.Now.ToUnixDateTimeString());
            sb.AppendLine("UNICN END");

            return sb;
        }
    }
}