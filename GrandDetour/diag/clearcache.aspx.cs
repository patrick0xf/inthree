using System.Text;
using GrandDetour.Core;

namespace GrandDetour.Diag
{
    public class ClearCache : EcoPage 
    {
        protected override bool HasAccess()
        {
            return GetQuery("debug") == "true";
        }

        protected override StringBuilder Respond()
        {
            ClearCache();
            var sb = new StringBuilder();
            sb.AppendLine("Done");
            return sb;
        }
    }
}