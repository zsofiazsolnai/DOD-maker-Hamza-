using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DOD_Maker_Hamza.Models
{
    public class DODdbContext : DbContext
    {
        public DbSet<DODTemplates> DODTemplate { get; set; }
        public DbSet<DOD_Option> DOD_Option { get; set; }
        public DbSet<DOD_Type> DOD_Type { get; set; }
        public DbSet<DOD_Template_Type> DOD_Template_Type { get; set; }
        public DbSet<MyDODs> MyDODs { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<AvailableProjects> AvailableProjects { get; set; }
    }
}