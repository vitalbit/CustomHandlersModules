using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomHandlersModules.CustomHandlers
{
    public class HelloHandler2 : IHttpHandler
    {
        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello world from class!");
        }
    }
}