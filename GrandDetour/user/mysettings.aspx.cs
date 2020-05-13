using System;
using System.Linq;
using GrandDetour.Core;

namespace GrandDetour.user
{
    public partial class MySettings : UserPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            var timeZoneIDs = TimeZoneInfo.GetSystemTimeZones().Select(tz => tz.Id).Reverse().ToList();
            timeZoneIDs.Insert(0, "device");
            ddlTimeZone.DataSource = timeZoneIDs;
            ddlTimeZone.SelectedValue = Account.GetSelectedTimeZone();
            ddlTimeZone.DataBind();
        }

        protected void BtnSaveClick(object sender, EventArgs e)
        {
            var passwordChanging = false;

            Account.TimeZoneId = ddlTimeZone.SelectedValue;

            if(!String.IsNullOrEmpty(txtPassword.Text))
            {
                var password = txtPassword.Text;

                if(password.Contains(" "))
                {
                    Response.Redirect(String.Format("message.aspx?{0}={1}", QUERY_MESSAGE, "Password should not contain spaces"));
                }

                if (password.Length < 6)
                {
                    Response.Redirect(String.Format("message.aspx?{0}={1}", QUERY_MESSAGE, "Password should be 6 characters or more"));
                }

                if(txtPasswordMatch.Text == password)
                {
                    Account.Password = password.Hash(Account.Number);
                    passwordChanging = true;
                }
                else
                {
                    Response.Redirect(String.Format("message.aspx?{0}={1}", QUERY_MESSAGE, "Passwords do not match"));
                }
            }

            DoSave(Account, String.Format(passwordChanging ? "logout.aspx" : "mysettings.aspx?{0}={1}", QUERY_NUMBER, Account.Number));
            
        }

        protected void BtnCancelClick(object sender, EventArgs e)
        {
            Response.Redirect("home.aspx");
        }               


    }
}