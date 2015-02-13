using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomHandlersModules.CustomHandlers
{
    /// <summary>
    /// Summary description for HelloHandler
    /// </summary>
    public class HelloHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World from ashx!");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}