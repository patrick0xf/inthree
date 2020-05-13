using System;
using System.Web.Caching;
using System.Web.UI;

namespace GrandDetour.Core
{
    public class AccountPage : Page
    {
        protected const string ACCESS_CACHE = "ac";
        protected const string IPLOCK_CACHE = "site{0}ip{1}";
        protected const string QUERY_NUMBER = "number";
        protected const string QUERY_MESSAGE = "message";
        protected const string QUERY_SEARCH = "search";
        protected const string QUERY_MODE = "mode";
        protected const string QUERY_DEVICE = "device";
        protected const string QUERY_FILTER = "filter";
        protected const string QUERY_ACCOUNT = "account";
        protected const string QUERY_KEY = "key";
        protected const string SEARCH_NUMBER = "1";
        protected const string SEARCH_HOLDER = "2";
        protected const string SEARCH_EMAIL = "3";
        protected const string SEARCH_DEVICES = "4";
        protected const string SEARCH_EXPIRED = "5";
        protected const string SEARCH_TRIAL = "6";
        protected const string SEARCH_INACTIVE = "7";
        protected const string SEARCH_ACTIVE_TRIAL = "8";
        protected const string SEARCH_EXPIRES_ONE_MONTH = "9";

        protected Exception LastLoadAccessException;
        protected Exception LastSaveAccessException;

        protected enum SiteName { Backspace, User }

        protected void ClearCache()
        {
            Cache.Remove(ACCESS_CACHE);
        }

        protected Access Access
        {
            get
            {
                if (Cache[ACCESS_CACHE] == null)
                {
                    Cache.Insert(ACCESS_CACHE,
                              Access.Load("accessfilepath".AsSetting(), out LastLoadAccessException) ?? new Access(),
                              null,
                              DateTime.UtcNow.AddMinutes("accessfilecache".AsSetting().ToSafeInt(5)),
                              Cache.NoSlidingExpiration,
                              CacheItemPriority.Default, null);
                }

                return (Cache[ACCESS_CACHE] as Access);
            }
        }

        protected bool IsIPLocked(SiteName siteName, string ip)
        {
            //var ipLock = String.Format(IPLOCK_CACHE, siteName, ip);

            //if (Cache[ipLock] != null)
            //{
            //    return true;
            //}
            
            //Cache.Insert(ipLock, true, null, Cache.NoAbsoluteExpiration, new TimeSpan(0, 0, 2),
            //             CacheItemPriority.Default, null);

            return false;
        }

        private bool Save()
        {
             if(Access.Accounts.SafeCount() > 0)
             {
                 LastSaveAccessException = Access.Save("accessfilepath".AsSetting());
                 return LastSaveAccessException == null;
             }

            return false;
        }

        protected void DoSave(Account account, string goodRedir)
        {
            if (!Access.UpdateAccount(account))
            {
                Response.Redirect(String.Format("message.aspx?{0}={1}", QUERY_MESSAGE, "Couldn't Update Account"));
                return;
            }

            if (!Save())
            {
                Response.Redirect(String.Format("message.aspx?{0}={1}", QUERY_MESSAGE, "Couldn't Save to File"));
                return;
            }

            ClearCache();
            Response.Redirect(goodRedir);
        }

        protected void DoDelete(Account account, string goodRedir)
        {
            if (!Access.DeleteAccount(account))
            {
                Response.Redirect(String.Format("message.aspx?{0}={1}", QUERY_MESSAGE, "Couldn't Delete Account"));
                return;
            }

            if (!Save())
            {
                Response.Redirect(String.Format("message.aspx?{0}={1}", QUERY_MESSAGE, "Couldn't Save to File"));
                return;
            }

            ClearCache();
            Response.Redirect(goodRedir);          
        }
    }
}