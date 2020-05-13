using System;
using System.Web;
using GrandDetour.Core;

namespace GrandDetour.Backspace
{
    public partial class Search : AccountPage
    {
        protected void BtnNumberClick(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("searchresults.aspx?{0}={1}&{2}={3}", QUERY_SEARCH, HttpUtility.UrlEncode(txtNumber.Text), QUERY_MODE, SEARCH_NUMBER));
        }

        protected void BtnHolderClick(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("searchresults.aspx?{0}={1}&{2}={3}", QUERY_SEARCH, HttpUtility.UrlEncode(txtHolder.Text), QUERY_MODE, SEARCH_HOLDER));
        }

        protected void BtnEmailClick(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("searchresults.aspx?{0}={1}&{2}={3}", QUERY_SEARCH, HttpUtility.UrlEncode(txtEmail.Text), QUERY_MODE, SEARCH_EMAIL));
        }

        protected void BtnDevicesClick(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("searchresults.aspx?{0}={1}&{2}={3}", QUERY_SEARCH, HttpUtility.UrlEncode(txtDevices.Text), QUERY_MODE, SEARCH_DEVICES));
        }

        protected void BtnExpiredClick(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("searchresults.aspx?{0}={1}&{2}={3}", QUERY_SEARCH, String.Empty, QUERY_MODE, SEARCH_EXPIRED));
        }

        protected void BtnTrialClick(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("searchresults.aspx?{0}={1}&{2}={3}", QUERY_SEARCH, String.Empty, QUERY_MODE, SEARCH_TRIAL));
        }

        protected void BtnInactive(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("searchresults.aspx?{0}={1}&{2}={3}", QUERY_SEARCH, String.Empty, QUERY_MODE, SEARCH_INACTIVE));
        }

        protected void BtnActiveTrial(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("searchresults.aspx?{0}={1}&{2}={3}", QUERY_SEARCH, String.Empty, QUERY_MODE, SEARCH_ACTIVE_TRIAL));
        }

        protected void BtnExpiresInAMonth(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("searchresults.aspx?{0}={1}&{2}={3}", QUERY_SEARCH, String.Empty, QUERY_MODE, SEARCH_EXPIRES_ONE_MONTH));

        }
    }
}