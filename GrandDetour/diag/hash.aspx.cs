using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Caching;
using GrandDetour.Core;

namespace GrandDetour.Diag
{
    public class Hash : EcoPage 
    {
        protected override bool HasAccess()
        {
            return GetQuery("debug") == "true";
        }

        protected override StringBuilder Respond()
        {
            var sb = new StringBuilder();
            sb.Append(GetQuery("hash").Hash(GetQuery("salt)")));
            return sb;
        }
    }
}