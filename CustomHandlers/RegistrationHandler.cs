using CustomHandlersModules.EFDataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomHandlersModules.CustomHandlers
{
    public class RegistrationHandler : IHttpHandler
    {
        UsersContext users;

        public RegistrationHandler()
        {
            users = new UsersContext();
        }

        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            string login = context.Request.Params["rlogin"];
            string password = context.Request.Params["rpassword"];
            if (login != null && password != null)
            {
                if (users.Set<User>().Any(user => user.Login == login))
                {
                    context.Response.Write("User already exists!");
                    User us = users.Set<User>().FirstOrDefault(user => user.Login == login);
                    context.Response.Write("<div>User name: " + us.Login + "<br />User password: " + us.Password + "</div>");
                    context.Response.End();
                }
                else
                {
                    users.Set<User>().Add(new User() { Login = login, Password = password });
                    users.SaveChanges();
                    context.Response.Write("User created!");
                    context.Response.End();
                }
            }
        }
    }
}