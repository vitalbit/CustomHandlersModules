using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CustomHandlersModules.EFDataContext
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }

    public class UsersContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}