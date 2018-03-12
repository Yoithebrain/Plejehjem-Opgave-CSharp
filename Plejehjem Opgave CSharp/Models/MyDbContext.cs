using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Plejehjem_Opgave_CSharp.Models
{
    public class MyDbContext : DbContext
    {
        public DbSet<UserAccount> Useraccount { get; set; }
    }
}