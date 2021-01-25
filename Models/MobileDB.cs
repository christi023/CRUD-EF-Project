using System;
using System.Data.Entity;
using System.Linq;

namespace Models
{
    public class MobileDB : DbContext
    {
     
        public MobileDB()
            : base("name=DatabaseContext")
        {
        }

        public virtual System.Data.Entity.DbSet<MobileClass> Mobile{ get; set; }
    }

  
}