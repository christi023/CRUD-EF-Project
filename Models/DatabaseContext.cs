namespace Models
{
   
	public class DatabaseContext : System.Data.Entity.DbContext
	{
        
		static DatabaseContext()
        {
           
            System.Data.Entity.Database.SetInitializer(new DatabaseContextInitializer());
        }

       
		public DatabaseContext()
        {
        }

        





        public System.Data.Entity.DbSet<LapTopClass> LapTop { get; set; }
        public System.Data.Entity.DbSet<MobileClass> Mobile { get; set; }
    }
}
