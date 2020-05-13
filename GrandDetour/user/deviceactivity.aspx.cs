using System;
using System.Text.RegularExpressions;
using System.Web;
using GrandDetour.Core;

namespace GrandDetour.user
{
    public partial class DeviceActivity : UserPage
    {
        private const int COMMANDNAME = 0;
        private const int PARAMETERS = 1;

        private const int FILTER_ALL = 1;

        private Device _currentDevice;
        private int _deviceIndex;
        private int _filterIndex;

        protected string CommandToken;

        protected string DeviceInfo
        {
            get { return _currentDevice == null ? String.Empty : String.Format("{0} ({1})", _currentDevice.MACAddress, _currentDevice.Type); }
        }

        protected string DeviceLogUrl
        {
            get { return _deviceIndex == 0 ? String.Empty : String.Format("devicelog.aspx?{0}={1}&commandtoken={2}", QUERY_DEVICE, _deviceIndex, CommandToken); }
        }

        protected string FilterToggle
        {
            get { return String.Format("<a href='deviceactivity.aspx?{0}={2}&{1}={3}'>view {4}", QUERY_DEVICE, QUERY_FILTER, _deviceIndex, _filterIndex == 1 ? 0 : 1, _filterIndex == 1 ? "notification activity only" : "all activity"); }
        }

        protected string FilterTitle
        {
            get { return String.Format("viewing {0}", _filterIndex == 1 ? "all activity" : "notification activity"); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            Int32.TryParse(Request.QueryString[QUERY_DEVICE], out _deviceIndex);
            Int32.TryParse(Request.QueryString[QUERY_FILTER], out _filterIndex);

            if(_deviceIndex < 1 || _deviceIndex > Account.Devices.Length)
            {
                Response.Redirect("mydevices.aspx");
            }

            _currentDevice = Account.Devices[_deviceIndex-1];

            var grepCommand = String.Format("simplegrep").AsSetting();
            var sections = grepCommand.Split(',');

            CommandToken = Ps.GetPIDKey(Ps.RunAndRead(sections[COMMANDNAME], String.Format(sections[PARAMETERS], new Regex(@"%[a-f0-9]{2}").Replace(HttpUtility.UrlEncode(_currentDevice.MACAddress), m => m.Value.ToUpperInvariant())), _currentDevice.MACAddress, _filterIndex == FILTER_ALL ? null : "email.aspx"), _currentDevice.MACAddress);
        }
    }
}