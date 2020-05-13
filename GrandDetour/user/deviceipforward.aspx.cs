using System;
using System.Linq;
using System.Web;
using GrandDetour.Core;

namespace GrandDetour.user
{
    public partial class DeviceIPForward : UserPage
    {
        private Device _currentDevice;
        private int _deviceIndex;

        protected string DeviceDisplay
        {
            get { return String.Format("{0} ({1})", _currentDevice.MACAddress, _currentDevice.Type); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Int32.TryParse(Request.QueryString[QUERY_DEVICE], out _deviceIndex);

            if(_deviceIndex < 1 || _deviceIndex > Account.Devices.Length)
            {
                Response.Redirect("mydevices.aspx");
            }

            _currentDevice = Account.Devices[_deviceIndex - 1];

            if (IsPostBack) return;


            txtExternalFowardPattern.Text = _currentDevice.ExternalForwardPattern;
            txtInternalFowardPattern.Text = _currentDevice.InternalForwardPattern;
            txtKey.Text = _currentDevice.IPForwardKey;      

            var staticUrl = "disabled";

            if(!String.IsNullOrEmpty(_currentDevice.IPForwardKey))
            {
                staticUrl = String.Format("staticforward".AsSetting(), Account.Number, HttpUtility.UrlEncode(_currentDevice.IPForwardKey));
            }

            lblStaticUrl.Text = staticUrl;
            lblExternalForwardUrl.Text = _currentDevice.GetExternallyForwardsTo();
            lblInternalForwardUrl.Text = _currentDevice.GetInternallyForwardsTo();
            chkTestMode.Checked = _currentDevice.TestMode == "True";
            chkIos.Checked = _currentDevice.IosViewPort;
        }

        protected void BtnCancelClick(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void BtnSaveClick(object sender, EventArgs e)
        {
            var key = txtKey.Text.Trim();
            var externalForwardPattern = txtExternalFowardPattern.Text.Trim();
            var internalForwardPattern = txtInternalFowardPattern.Text.Trim();

            _currentDevice.IPForwardKey = key.Substring(0, Math.Min(key.Length, 15));
            _currentDevice.ExternalForwardPattern = externalForwardPattern.Substring(0, Math.Min(externalForwardPattern.Length, 255));
            _currentDevice.InternalForwardPattern = internalForwardPattern.Substring(0, Math.Min(internalForwardPattern.Length, 255));
            _currentDevice.TestMode = chkTestMode.Checked ? "True" : "False";
            _currentDevice.IosViewPort = chkIos.Checked;

            DoSave(Account, String.Format("deviceipforward.aspx?{0}={1}", QUERY_DEVICE, _deviceIndex));

            Response.Redirect(Request.RawUrl);
        }
    }
}