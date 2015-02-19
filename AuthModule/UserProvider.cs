using CustomHandlersModules.EFDataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace CustomHandlersModules.AuthModule
{
    public class UserProvider : IPrincipal
    {
        private UserIdentity userIdentity;

        public UserProvider(User user)
        {
            userIdentity = new UserIdentity();
            userIdentity.User = user;
        }

        public IIdentity Identity
        {
            get { return userIdentity; }
        }

        public bool IsInRole(string role)
        {
            if (userIdentity.User != null && role == "User")
                return true;
            else
                return false;
        }
    }
}