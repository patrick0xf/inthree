using System;
using System.Text;
using GrandDetour.Core;

namespace GrandDetour
{
    public class Default : IcmPage
    {
        protected override StringBuilder Respond()
        {
            var now = DateTime.Now;
            var random = new Random();
            var sb = new StringBuilder();

            sb.AppendLine("UNICN START");
            sb.AppendLineFormat("Script Start Time: {0}", now);
            sb.AppendLineFormat("Script End Time: {0}", now.AddSeconds(random.Next(2)));
            sb.AppendLineFormat("Script Runtime (mSec): {0}", random.Next(14) + 1);
            sb.AppendLineFormat("SQL Runtime (mSec): {0}", random.Next(22) + 1);

            if(!String.IsNullOrEmpty(GetQuery("time")) && GetQuery("msgtype") != "E")
            {
                sb.AppendLine("[cmd]");
                sb.AppendLine("1=(0.1.1)_GetInterface");
            }

            sb.AppendLine("[~node]");
            sb.AppendLine("serverTime=360");

            if(GetQuery("msgtype") != "E")
            {
                sb.AppendLine("groupID=0");
                sb.AppendLine("emailURL=http://in2myhome.com/email.aspx");
            }

            sb.AppendLine("serverURL=http://in2myhome.com/default.aspx");
            sb.AppendLine("backupURL=http://in2myhome.com/default.aspx");

            sb.AppendLine("UNICN END");

            return sb;
        }
    }
}