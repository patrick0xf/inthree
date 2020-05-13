using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GrandDetour.Core
{
    public class LogLine
    {
        private const int LOG_FROM = 0;
        private const int LOG_UNK1 = 1;
        private const int LOG_UNK2 = 2;
        private const int LOG_DAT1 = 3;
        private const int LOG_DAT2 = 4;
        private const int LOG_COM1 = 5;
        private const int LOG_COM2 = 6;
        private const int LOG_COM3 = 7;
        private const int LOG_CODE = 8;
        private const int LOG_UNK9 = 9;
        private const int LOG_UNK0 = 10;
        private const int LOG_CLIE = 11;

        public bool IsValid { get; private set; }
        public string RawIP { get; private set; }
        public string RawDateTime { get; private set; }
        public string RawCommand { get; private set; }
        public string RawHttpCode { get; private set; }

        public LogLine(string rawLogLine)
        {
            var splitLine = rawLogLine.Split(' ');

            if (splitLine.Length != 12) return;
            
            IsValid = true;

            RawIP = splitLine[LOG_FROM];
            RawDateTime = splitLine[LOG_DAT1];
            RawCommand = splitLine[LOG_COM2];
            RawHttpCode = splitLine[LOG_CODE];
        }

        public DateTime? UtcDateTime
        {
            get
            {
                if(!IsValid)
                {
                    return null;
                }

                var formattedDateTime = RawDateTime.TrimStart('[').TrimEnd(']');
                var badColumnIndex = formattedDateTime.IndexOf(":", StringComparison.Ordinal);
                formattedDateTime = formattedDateTime.Remove(badColumnIndex, 1).Insert(badColumnIndex, " ");

                return DateTime.Parse(formattedDateTime);
            }
        }

        public string Page
        {
            get
            {
                var command = RawCommand;

                return command == null ? null : command.Split('?')[0].TrimStart('/');
            }
        }

        public string GetParameter(string parameterName)
        {
            return RawCommand == null ? null : HttpUtility.ParseQueryString(RawCommand.Split('?')[1])[parameterName];
        }

        public string FriendlyMessage
        {
            get
            {
                switch(Page)
                {
                    case "default.aspx":
                        var messageType = GetParameter("msgtype");
                        
                        switch(messageType)
                        {
                            case "E":
                                var panel = GetParameter("panel");
                                return String.Format("Panel Functions: {0}", panel);
                            case "C":
                                var readOut = GetParameter("1.display");
                                return String.Format("Panel Display: {0}", readOut);
                            default:
                                return "Panel Unknown";
                        }
                    case "time.aspx":
                        return "Time Synchronization";

                    case "email.aspx":
                        var subject = GetParameter("subject");
                        var message = GetParameter("message");
                        return String.Format("Notification: {0} ({1})", subject, message);
                    default:
                        return "Unknown";
                }
            }
        }

        public string StatusCode
        {
            get { return RawHttpCode == "200" ? "OK" : String.IsNullOrEmpty(RawHttpCode) ? "UNK" : RawHttpCode; }
        }
    }
}