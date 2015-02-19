using CustomHandlersModules.EFDataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace CustomHandlersModules.CustomHandlers
{
    public class AuthorizationHandler : IHttpHandler
    {
        UsersContext users = new UsersContext();

        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            string login = context.Request.Params["login"];
            string pass = context.Request.Params["password"];
            if (login == "" || pass == "")
            {
                context.Response.Write("<a href=\"#\" id=\"enter\" onclick=\"show_login(); return false;\">Войти</a>");
                context.Response.End();
            }
            User fuser = users.Set<User>().FirstOrDefault(user => user.Login == login);
            if (fuser != null && pass == fuser.Password)
            {
                var ticket = new FormsAuthenticationTicket(1, fuser.Login, DateTime.Now, DateTime.Now.Add(FormsAuthentication.Timeout), true, string.Empty);
                var encTicket = FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie("__AUTH_COOKIE_");
                cookie.Value = encTicket;
                cookie.Expires = DateTime.Now.Add(FormsAuthentication.Timeout);
                context.Response.Cookies.Add(cookie);
                context.Response.Write("<a href=\"#\" id=\"exit\" onclick=\"logout();\">Выйти</a>");
                context.Response.End();
            }
            else
            {
                context.Response.Write("<a href=\"#\" id=\"enter\" onclick=\"show_login(); return false;\">Войти</a>");
                context.Response.End();
            }
        }
    }
}