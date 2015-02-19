using CustomHandlersModules.EFDataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;

namespace CustomHandlersModules.AuthModule
{
    public class CustomAuthenticationModule : IHttpModule
    {
        UsersContext users = new UsersContext();

        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.AuthenticateRequest += context_AuthenticateRequest;
        }

        void context_AuthenticateRequest(object sender, EventArgs e)
        {
            HttpApplication app = (HttpApplication)sender;
            HttpContext context = app.Context;

            HttpCookie cookie = context.Request.Cookies.Get("__AUTH_COOKIE_");
            if (cookie != null && !string.IsNullOrEmpty(cookie.Value))
            {
                var ticket = FormsAuthentication.Decrypt(cookie.Value);
                if (users.Set<User>().Any(user => user.Login == ticket.Name))
                {
                    cookie.Expires.Add(FormsAuthentication.Timeout);
                    context.Response.Cookies.Set(cookie);
                    context.Response.StatusCode = 200;
                }
                else
                {
                    context.Response.StatusCode = 401;
                }
            }

            return;
        }
    }
}