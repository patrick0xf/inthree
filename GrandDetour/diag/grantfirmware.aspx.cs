using System.Text;
using GrandDetour.Core;

namespace GrandDetour.Diag
{
    public class GrantFirmware : EcoPage 
    {
        protected override bool HasAccess()
        {
            return GetQuery("debug") == "true";
        }

        protected override StringBuilder Respond()
        {
            var sb = new StringBuilder();

            sb.AppendLineFormat("Allowed IP in {0}: {1}", "grantfilepath".AsSetting(), FirmwareGrant.GetFirmwareGrantAllowedIP());
            return sb;
        }
    }
}