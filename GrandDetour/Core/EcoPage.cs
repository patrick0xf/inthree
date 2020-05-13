using System;
using System.Text;

namespace GrandDetour.Core
{
    public abstract class EcoPage : AccountPage
    {
        protected const string QUERY_MAC = "mac";

        protected override void OnInit(EventArgs e)
        {
            Response.Clear();
            Response.StatusCode = 200;
            Response.Write(Respond().ToString());
            Response.End();
        }

        protected override void OnPreInit(EventArgs e)
        {
            if (!HasAccess())
            {
                Response.Clear();
                Response.Redirect(String.Format("/404?mac={0}", Request.QueryString[QUERY_MAC]), true);
                Response.End();
            }

            base.OnPreInit(e);
        }

        protected string GetQuery(string key)
        {
            return Request.QueryString[key];
        }

        protected abstract StringBuilder Respond();
        protected abstract bool HasAccess();

    }
}