namespace Models
{
  
	public class DatabaseContextInitializer :
		System.Data.Entity.DropCreateDatabaseIfModelChanges<DatabaseContext>
	{
       
		public DatabaseContextInitializer()
		{
		}

      
		protected override void Seed(DatabaseContext context)
		{
			base.Seed(context);
		}
	}
}
