using System.Text;
using GrandDetour.Core;

namespace GrandDetour.Diag
{
    public class SendNotificationMail : EcoPage
    {
        protected override bool HasAccess()
        {
            return Recipient.Contains("@") && GetQuery("debug") == "true";
        }

        protected string Recipient
        {
            get
            {
                return GetQuery("securerecip").NullAsEmpty().Replace("_", "@");
            }
        }

        protected override StringBuilder Respond()
        {
            var sb = new StringBuilder();
            sb.AppendLineFormat("Sendmail Result: {0}", Mailer.SendNotificationMail(Recipient, "Test Subject", "Test body"));
            sb.AppendLine("Done");
            return sb;
        }
    }
}