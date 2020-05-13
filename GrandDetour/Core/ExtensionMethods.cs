using System;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web.Security;

namespace GrandDetour.Core
{
    public static class ExtensionMethods
    {
        public static int ToSafeInt(this string s, int defaultValue = 0)
        {
            int returnValue;
            return Int32.TryParse(s, out returnValue) ? returnValue : defaultValue;
        }

        public static string NullAsEmpty(this string s)
        {
            return s ?? String.Empty;
        }

        public static string AsSetting(this string s)
        {
            return ConfigurationManager.AppSettings[s];
        }

        public static string ToFriendlyLog(this string[] ars)
        {
            var sb = new StringBuilder();
            Array.Reverse(ars);
            foreach (var logLine in ars.Select(s => new LogLine(s)))
            {
                if (logLine.IsValid)
                {
                    sb.AppendFormat("{0}UTC ({1}[{2}]) {3}", logLine.UtcDateTime, logLine.RawIP, logLine.StatusCode, logLine.FriendlyMessage);
                    sb.AppendLine("\r\n"); //force windows line break
                }
                else
                {
                    sb.AppendFormat("(unformatted line)");
                    //sb.AppendLine("\r\n"); //force windows line break  
                }
            }

            return sb.ToString();
        }

        public static string ToUnixDateTimeString(this DateTime d)
        {
            return ((int)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds).ToString(CultureInfo.InvariantCulture);
        }

        public static void AppendLineFormat(this StringBuilder sb, string format, params object[] args)
        {
            sb.AppendFormat(format, args);
            sb.AppendLine();
        }

        public static string InnerExceptionMessage(this Exception exception)
        {
            var sb = new StringBuilder();

            var innerException = exception;

            while(innerException != null)
            {
                sb.AppendLineFormat("{0}. ", innerException.Message);
                innerException = innerException.InnerException;
            }

            return sb.ToString().Trim();
        }

        public static string Hash(this string s, string salt=null)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(String.Format("{0}{1}",s, salt), "SHA1");
        }

        public static string HourlyToken(this DateTime dateTime, string salt = null)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, 0, 0).ToLongDateString().Hash(salt);
        }

        public static bool HasHourlyTokens(this DateTime dateTime, string token, int hoursToGoBack, string salt=null)
        {
            for (var i = 0; i <= hoursToGoBack; i++)
            {
                var computeDateTime = dateTime.AddHours(-i);
                if (token == new DateTime(computeDateTime.Year, computeDateTime.Month, computeDateTime.Day, computeDateTime.Hour, 0, 0).ToLongDateString().Hash(salt))
                {
                    return true;
                }
            }

            return false;
        }

        public static long SafeCount(this Device[] o)
        {
            return o == null ? 0 : o.LongLength;
        }
        public static long SafeCount(this Account[] o)
        {
            return o == null ? 0 : o.LongLength;
        }
        public static long SafeCount(this Payment[] o)
        {
            return o == null ? 0 : o.LongLength;
        }
    }
}