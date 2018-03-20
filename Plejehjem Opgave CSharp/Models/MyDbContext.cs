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
        public DbSet<FullCitizensInfo> FullCitizensInfos { get; set; }

        public DbSet<Schedule> Schedules { get; set; }

        public DbSet<CitizensContacts> CitizensContacts { get; set; }
    }
}