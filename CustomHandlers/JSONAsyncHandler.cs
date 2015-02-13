using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomHandlersModules.CustomHandlers
{
    public class JSONAsyncHandler : IHttpAsyncHandler
    {
        protected delegate void AsyncProcessorDelegate(HttpContext context);
        private AsyncProcessorDelegate _Delegate;

        public IAsyncResult BeginProcessRequest(HttpContext context, AsyncCallback cb, object extraData)
        {
            _Delegate = new AsyncProcessorDelegate(ProcessRequest);
            return _Delegate.BeginInvoke(context, cb, extraData);
        }

        public void EndProcessRequest(IAsyncResult result)
        {
            _Delegate.EndInvoke(result);
        }

        public bool IsReusable
        {
            get { return false; }
        }

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
    }
}