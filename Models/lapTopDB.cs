using System;
using System.Data.Entity;
using System.Linq;

namespace Models
{
    public class lapTopDB : DbContext
    {
       
        public lapTopDB()
            : base("name=DatabaseContext")
        {
        }

        public virtual System.Data.Entity.DbSet<LapTopClass> LapTops { get; set; }
    }

  
}