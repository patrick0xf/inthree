using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using System.Linq;

namespace GrandDetour.Core
{
    [SerializableAttribute]
    [XmlRootAttribute("access", Namespace = "", IsNullable = false)]
    public class Access
    {
        [XmlElementAttribute("account", typeof(Account))]
        public Account[] Accounts { get; set; }

        private static object _writerLock = 0;

        public Access()
        {
            Accounts = new Account[0];
        }

        public string AddAccount()
        {
            var newAccountNumber = String.Empty;

            while (newAccountNumber == String.Empty || Accounts.Any(account => account.Number == newAccountNumber)) newAccountNumber = Guid.NewGuid().ToString().Split('-')[0].ToLowerInvariant();

            var expires = DateTime.Now.AddMonths(1);

            var newAccount = new Account { Number = Guid.NewGuid().ToString().Split('-')[0].ToLowerInvariant(), Holder = "New account", Email = "unset@example.com" };

            newAccount.SetNewTerm(Type.Trial, new DateTime(expires.Year, expires.Month, DateTime.DaysInMonth(expires.Year, expires.Month), 0, 0, 0, DateTimeKind.Utc).AddDays(1).AddSeconds(-1));

            var copyArray = new Account[Accounts.Length + 1];

            Array.Copy(Accounts, copyArray, Accounts.Length);

            copyArray[Accounts.Length] = newAccount;
            Accounts = copyArray;

            return newAccount.Number;
        }

        public bool UpdateAccount(Account account)
        {
            var accountIndex = Array.FindIndex(Accounts, a => a.Number == account.Number);

            if (accountIndex > -1)
            {
                Accounts[accountIndex] = account;
                return true;
            }
            return false;
        }

        public bool DeleteAccount(Account account)
        {
            var accountIndex = Array.FindIndex(Accounts, a => a.Number == account.Number);

            if (accountIndex > -1)
            {
                var copyArray = new Account[Accounts.Length -1];

                for (var i = 0; i < Accounts.Length - 1; i++)
                {
                    copyArray[i] = Accounts[i + (accountIndex <= i ? 1 : 0)];
                }

                Accounts = copyArray;

                return true;
            }
            return false;
        }

        public Exception Save(string fileName)
        {
            lock (_writerLock)
            {
                try
                {
                    using (TextWriter textWriter = new StreamWriter(fileName))
                    {
                        new XmlSerializer(typeof (Access)).Serialize(textWriter, this);
                        textWriter.Close();
                    }
                }
                catch (Exception exception)
                {
                    return exception;
                }
            }

            return null;
        }

        public Account GetAccount(string number)
        {
            return Accounts.FirstOrDefault(account => account.Number == number);
        }

        public static Access Load(string fileName, out Exception returnException)
        {
            Access access = null;
            returnException = null;

            if(string.IsNullOrEmpty(fileName))
            {
                returnException = new ArgumentNullException("fileName");
                return null;
            }

            lock (_writerLock)
            {
                try
                {
                    using (var streamReader = new StreamReader(fileName))
                    {
                        access = (Access) new XmlSerializer(typeof (Access)).Deserialize(streamReader);
                        streamReader.Close();
                    }
                }
                catch (Exception exception)
                {
                    returnException = exception;
                }
            }

            return access;            
        }
    }

    [SerializableAttribute]
    public class Account
    {
        [XmlElementAttribute("holder")]
        public string Holder { get; set; }

        [XmlElementAttribute("email")]
        public string Email { get; set; }

        [XmlElementAttribute("password")]
        public string Password { get; set; }

        [XmlArrayAttribute("devices")]
        [XmlArrayItemAttribute("device", typeof (Device))]
        public Device[] Devices { get; set; }

        [XmlArrayAttribute("payments")]
        [XmlArrayItemAttribute("payment", typeof(Payment))]
        public Payment[] Payments { get; set; }

        [XmlAttributeAttribute("number")]
        public string Number { get; set; }

        [XmlAttributeAttribute("type")]
        public string IntType { get; set; }

        [XmlAttributeAttribute("expires")]
        public DateTime IntExpiresUtc { get; set; }

        [XmlAttributeAttribute("timezoneid")]
        public string TimeZoneId { get; set; }

        [XmlIgnore]
        public Type Type
        {
            get { return IntType == "trial" ? Type.Trial : Type.Ongoing; }
        }

        [XmlIgnore]
        public DateTime ExpiresUtc
        {
            get { return IntExpiresUtc == DateTime.MinValue ? new DateTime(2013, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(-1) : IntExpiresUtc; }
        }

        [XmlIgnore]
        public bool HasExpired
        {
            get { return DateTime.UtcNow > ExpiresUtc.AddDays(75); }
        }

        public string GetDisplayDateTime(string rawDateTime)
        {
            var availableTimeZones = TimeZoneInfo.GetSystemTimeZones();
            if(availableTimeZones.Any(tz => tz.Id == TimeZoneId))
            {
                var timeZone = availableTimeZones.First(tz => tz.Id == TimeZoneId);
                var convertedTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone);
                return convertedTime.ToString(@"MM-dd-yyyy*hh:mm:ss tt").Replace("*", "\r\n") + " " + (timeZone.IsDaylightSavingTime(convertedTime) ? timeZone.DaylightName : timeZone.StandardName);
            }

            return rawDateTime + "\r\nLocal Time";
        }

        public string GetSelectedTimeZone()
        {
            return TimeZoneInfo.GetSystemTimeZones().Any(tz => tz.Id == TimeZoneId) ? TimeZoneId : "device";
        }

        public void SetNewTerm(Type type, DateTime expirationUtc)
        {
            IntType = type.ToString().ToLowerInvariant();
            IntExpiresUtc = expirationUtc;
        }

        public void RemoveDevice(int index)
        {
            if(Devices.Length > index)
            {
                Devices[index] = null;
            }

            Devices = Devices.Where(device => device != null).ToArray();
        }

        public void RemovePayment(int index)
        {
            if (Payments.Length > index)
            {
                Payments[index] = null;
            }
 
            Payments = Payments.Where(payment => payment != null).ToArray();
        }

        public void AddDevice(string macAddress, string type)
        {
            Devices = Devices == null ? new List<Device> { new Device { MACAddress = macAddress, Type = type } }.ToArray() : new List<Device>(Devices) { new Device { MACAddress = macAddress, Type = type } }.ToArray();
        }

        public void AddPayment(DateTime date, string note, int amountInCents)
        {
            Payments = Payments == null ? new List<Payment> { new Payment { Date = date, AmountInCents = amountInCents, Note = note } }.ToArray() : new List<Payment>(Payments) { new Payment { Date = date, AmountInCents = amountInCents, Note = note } }.ToArray();
        }

        [XmlIgnore]
        public string Tag { get; set; }

        [XmlIgnore]
        public string DevicesAsString
        {
            get
            {
                if (Devices == null || Devices.Length == 0) return "None";

                var sb = new StringBuilder();

                foreach(var device in Devices)
                {
                    sb.AppendLineFormat("{0}({1})", device.MACAddress, device.Type);
                    sb.AppendLineFormat("  {0} @ {1}",device.LastIP, device.GetFormattedLastDate());
                }

                return sb.ToString().Trim();
            }
        }

        [XmlIgnore]
        public bool IsActive
        {
            get
            {
                if (Devices == null || Devices.Length == 0) return false;
                return (Devices.Any(device => device.LastDate > DateTime.UtcNow.AddDays(0 - "isactivedays".AsSetting().ToSafeInt(30))));
            }
        }
    }

    [SerializableAttribute]
    public class Payment
    {
        [XmlAttributeAttribute("date")]
        public DateTime Date { get; set; }

        [XmlAttributeAttribute("note")]
        public string Note { get; set; }

        [XmlAttributeAttribute("amountInCents")]
        public int AmountInCents { get; set; }

    }

    [SerializableAttribute]
    public class Device
    {
        [XmlAttributeAttribute("type")]
        public string Type { get; set; }

        [XmlAttributeAttribute("lastip")]
        public string LastIP { get; set; }

        [XmlAttributeAttribute("lastdate")]
        public DateTime LastDate { get; set; }

        [XmlAttributeAttribute("ipforwardkey")]
        public string IPForwardKey { get; set; }

        [XmlAttributeAttribute("externetforwardpattern")]
        public string ExternalForwardPattern { get; set; }

        [XmlAttributeAttribute("internalforwardpattern")]
        public string InternalForwardPattern { get; set; }

        [XmlAttributeAttribute("testmode")]
        public string TestMode { get; set; }

        [XmlAttributeAttribute("iosviewport")]
        public bool IosViewPort { get; set; }

        [XmlTextAttribute]
        public string MACAddress { get; set; }

        public string GetFormattedLastDate()
        {
            var formattedLastDate = String.Format("{0}", LastDate);
            return formattedLastDate == "1/1/0001 12:00:00 AM" ? "Never" : formattedLastDate;
        }

        public string GetExternallyForwardsTo()
        {
            return String.IsNullOrEmpty(IPForwardKey)
                       ? null
                       : (ExternalForwardPattern == null || ExternalForwardPattern.ToCharArray().Count(c => c == '$') != 1
                              ? null
                              : ExternalForwardPattern.Replace("$", LastIP));
        }

        public string GetInternallyForwardsTo()
        {
            return String.IsNullOrEmpty(IPForwardKey)
                       ? null
                       : (InternalForwardPattern == null
                               ? null
                              : InternalForwardPattern.Replace("$", LastIP));
        }
    }

    public enum Type
    {
        Trial, Ongoing
    }
}
