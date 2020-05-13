using System;
using System.IO;
using System.Net;

namespace GrandDetour.Core
{
    public static class FirmwareGrant
    {
        public static string GetFirmwareGrantAllowedIP()
        {
            string ipToGrant;
            
            try
            {
                using (var streamReader = new StreamReader("grantfilepath".AsSetting()))
                {
                    ipToGrant = streamReader.ReadToEnd().Trim();
                }
            }
            catch (Exception)
            {
                return null;
            }

            IPAddress tryParseTest;
            
            return IPAddress.TryParse(ipToGrant, out tryParseTest) ? tryParseTest.ToString() : null;
        }

        public static void ClearFirmwareGrant()
        {
            try
            {
                File.Delete("grantfilepath".AsSetting());
            }
            catch
            {
            }

        }
    }
}