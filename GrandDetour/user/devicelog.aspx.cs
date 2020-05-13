using System;
using System.Collections.Generic;
using GrandDetour.Core;

namespace GrandDetour.user
{
    public partial class DeviceLog : UserPage
    {
        private int _deviceIndex;

        protected void Page_Load(object sender, EventArgs e)
        {
            Int32.TryParse(Request.QueryString[QUERY_DEVICE], out _deviceIndex);

            if(_deviceIndex < 1 || _deviceIndex > Account.Devices.Length)
            {
                Response.Redirect("mydevices.aspx");
            }

            var commandToken = Request.QueryString["commandtoken"];
            var downloadRequest = Request.QueryString["download"];

            var result = Cache[commandToken] as List<string>;

            if (result != null)
            {
                Response.Clear();
                Response.AddHeader("content-disposition", String.Format("{0};filename=devicelog.txt", downloadRequest == "true" ? "attachment" : "inline"));
                Response.ContentType = "text/plain";
                Response.StatusCode = 200;
                Response.Write(result.Count == 0 ? "no activity in the last 24 hours" : result.ToArray().ToFriendlyLog());
                Response.End();
            }
        }
    }
}