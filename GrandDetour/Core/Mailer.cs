using System;
using System.Net;
using System.Net.Mail;

namespace GrandDetour.Core
{
    public static class Mailer
    {
        private static SmtpClient _smtpClient;
        private static SmtpClient _smtpClientSupport;
        private static readonly MailAddress EcoConcierge = new MailAddress("emailfromemail".AsSetting(), "emailfromname".AsSetting());
        private static readonly MailAddress SupportPerson = new MailAddress("supportemailfromemail".AsSetting(), "supportemailfromname".AsSetting());

        public static string SendNotificationMail(string recipient, string subject, string body)
        {
            string error = null;

            try
            {
                NotificationSmtpClient.Send(new MailMessage(EcoConcierge, new MailAddress(recipient)) { Subject = subject, Body = body });
            }
            catch(Exception ex)
            {
                error = ex.InnerExceptionMessage();
            }

            return error;
        }

        public static string SendSupportMail(string recipient, string subject, string body)
        {
            string error = null;

            try
            {
                SupportSmtpClient.Send(new MailMessage(EcoConcierge, new MailAddress(recipient)) { Subject = subject, Body = body });
            }
            catch (Exception ex)
            {
                error = ex.InnerExceptionMessage();
            }

            return error;
        }

        private static SmtpClient NotificationSmtpClient
        {
            get
            {
                if (_smtpClient == null)
                {
                    _smtpClient = new SmtpClient("mailserver".AsSetting(), "mailport".AsSetting().ToSafeInt(25));

                    if (_smtpClient.Port == 587)
                    {
                        _smtpClient.EnableSsl = true;
                        ServicePointManager.ServerCertificateValidationCallback = (s, certificate, chain, sslPolicyErrors) => true;
                    }

                    var emailLogin = "emaillogin".AsSetting();
                    var emailPassword = "emailpassword".AsSetting();

                    if (!String.IsNullOrEmpty(emailLogin) || !String.IsNullOrEmpty(emailPassword))
                    {
                        _smtpClient.UseDefaultCredentials = false;
                        _smtpClient.Credentials = new NetworkCredential(emailLogin, emailPassword);
                    }
                }

                return _smtpClient;
            }
        }

        private static SmtpClient SupportSmtpClient
        {
            get
            {
                if (_smtpClientSupport == null)
                {
                    //Not implemented
                    _smtpClientSupport = null;
                }
                return _smtpClientSupport;
            }
        }
    }
}