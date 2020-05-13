using System.Web;

namespace GrandDetour
{
    /// <summary>
    /// Summary description for in3
    /// </summary>
    public class in3 : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            //TODO process email= parameter
            context.Response.ContentType = "image/png";
            context.Response.WriteFile("in3small.png");
        }

        public bool IsReusable
        {
            get
            {
                return true;
            }
        }
    }
}