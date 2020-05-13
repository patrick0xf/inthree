using System.Linq;
using System.Web;
using GrandDetour.Core;

namespace GrandDetour
{
    public class FirmwareUpgrade : IHttpHandler
    {
        #region IHttpHandler Members

        public bool IsReusable
        {
            // Return false in case your Managed Handler cannot be reused for another request.
            // Usually this would be false in case you have some state information preserved per request.
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            if(context.Request.UserHostAddress != FirmwareGrant.GetFirmwareGrantAllowedIP())
            {
                context.Response.Redirect("/404");
                return;
            }

            

            var fileName = context.Request.Url.ToString().Split('/').Last();

            switch(fileName)
            {
                case "devices.tar.gz":
                case "style.tar.gz":
                    context.Response.ContentType = "application/x-tar";
                    context.Response.WriteFile("firmwarefiles".AsSetting() + fileName);
                    break;
                case "version.htm":
                    context.Response.ContentType = "text/html";
                    context.Response.WriteFile("firmwarefiles".AsSetting() + fileName);
                    break;
                case "image": //symbolic link
                case "image.bin":
                    //TODO filter by user agent   netflash/100  only in image.bin
                    context.Response.ContentType = "application/octet-stream";
                    context.Response.WriteFile("firmwarefiles".AsSetting() + "image.bin");
                    FirmwareGrant.ClearFirmwareGrant();
                    break;
                default:
                    context.Response.Redirect("/404");
                    break;
            }
        }

        #endregion
    }
}
