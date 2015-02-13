using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomHandlersModules.CustomHandlers
{
    /// <summary>
    /// Summary description for HelloHandler
    /// </summary>
    public class JSONHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string file = context.Request.Params["file"];
            if (file == null)
                file = "~/contact.json";
            else
                file = "~/" + file;
            try
            {
                context.Response.ContentType = "application/json";
                context.Response.WriteFile(file);
            }
            catch
            {
                context.Response.ContentType = "text/plain";
                context.Response.Write("No such file!");
            }
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