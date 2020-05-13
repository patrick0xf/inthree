using System.Linq;
using System.Text;
using GrandDetour.Core;

namespace GrandDetour.Diag
{
    public class Access : EcoPage 
    {
        protected override bool HasAccess()
        {
            return GetQuery("debug") == "true";
        }

        protected override StringBuilder Respond()
        {
            var sb = new StringBuilder();

            var account = Access.Accounts.SingleOrDefault(a => a.Devices.Any(devices => devices.MACAddress == Request.QueryString[QUERY_MAC]));

            if (LastLoadAccessException != null)
            {
                sb.AppendLine(LastLoadAccessException.InnerExceptionMessage());
            }
            else
            {
                if (account != null)
                {
                    sb.AppendLineFormat("Name: {0}", account.Holder);
                    sb.AppendLineFormat("Number: {0}", account.Number);
                    sb.AppendLineFormat("Type: {0}", account.Type);
                    sb.AppendLine();

                    foreach (var device in account.Devices)
                    {
                        sb.AppendLineFormat("Device: {0} ({1})", device.MACAddress, device.Type);
                    }
                }
                else
                {
                    sb.AppendLine("Unknown account"); 
                }
            }

            return sb;
        }
    }
}