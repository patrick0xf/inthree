using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web;
using System.Web.Caching;
using GrandDetour.Core;

namespace GrandDetour
{
    public class Global : HttpApplication
    {
        public static void ProcessOnOutputDataReceived(object sender, DataReceivedEventArgs dataReceivedEventArgs, string salt, string filter)
        {
            var data = dataReceivedEventArgs.Data;

            if (data == null) return;

            var cacheKey = Ps.GetPIDKey(((Process)sender).Id, salt);

            var existingData = HttpRuntime.Cache[cacheKey] as List<string> ?? new List<string>();

            if (filter == null || data.Contains(filter))
            {
                existingData.Add(dataReceivedEventArgs.Data);
            }

            HttpRuntime.Cache.Insert(cacheKey,
              existingData,
              null,
              DateTime.UtcNow.AddSeconds("maxpsresults".AsSetting().ToSafeInt(70)),
              Cache.NoSlidingExpiration,
              CacheItemPriority.Default,
              null);
        }
    }
}