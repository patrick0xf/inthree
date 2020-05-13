using System;
using System.Text;
using GrandDetour.Core;

namespace GrandDetour
{
    public class Email : IcmPage
    {
        protected override StringBuilder Respond()
        {
            var sb = new StringBuilder();

            var addresses = GetQuery("address");
            var subject = GetQuery("subject");
            var message = GetQuery("message");
            var time = GetQuery("time");

            sb.AppendLine("UNICN START");
            sb.AppendLine("[~node]");

            var success = false;

            if (!String.IsNullOrEmpty(addresses))
            {
               var body = String.Format("\r\n{0}\r\n----------\r\n{1}", Account.GetDisplayDateTime(time), message);

                foreach (var address in addresses.Split(','))
                {
                    success = Mailer.SendNotificationMail(address, subject, body) == null;
                }
            }

            sb.AppendLineFormat("emailResult={0}", success ? "success" : "failure");
            sb.AppendLine("UNICN END");

            return sb;
        }
    }
}