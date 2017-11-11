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
    }
}