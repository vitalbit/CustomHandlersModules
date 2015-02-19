using CustomHandlersModules.EFDataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace CustomHandlersModules.AuthModule
{
    public class UserIdentity : IIdentity
    {
        public User User { get; set; }

        public string AuthenticationType
        {
            get { return typeof(User).ToString(); }
        }

        public bool IsAuthenticated
        {
            get { return User != null; }
        }

        public string Name
        {
            get {
                if (User != null)
                    return User.Login;
                else
                    return "Anonym";
            }
        }
    }
}