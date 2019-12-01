namespace WebApplication1.Models
{
	using System;
	using System.Data.Entity;
	using System.Linq;

	public class FitnessContext : DbContext
	{ 
		public FitnessContext()
		//: base("Data Source=(LocalDB)\u005cMSSQLLocalDB;AttachDbFilename=C:\u005cUsers\u005cnayaa\u005csource\u005crepos\u005cWebApplication1\u005cWebApplication1\u005cApp_Data\u005cFitnessDB.mdf;Integrated Security=True")
		:base("Data Source=(LocalDb)\u005cMSSQLLocalDB;Initial Catalog=WebApplication1.Models.FitnessContext;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework")
		{
		}

		// public virtual DbSet<MyEntity> MyEntities { get; set; }

		public virtual DbSet<User> Users { get; set; }	
		public virtual DbSet<Workout> Workouts { get; set; }
	}

	//public class MyEntity
	//{
	//    public int Id { get; set; }
	//    public string Name { get; set; }
	//}
}