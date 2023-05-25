using CateringCore.Model;
using Microsoft.EntityFrameworkCore;

namespace Catering.DbWorking
{
	public class ApplicationContext : DbContext
	{
		public DbSet<Manager> Managers { get; set; } = null!;
		public DbSet<Courier> Couriers { get; set; } = null!;
		public DbSet<Car>     Cars     { get; set; } = null!;

		public ApplicationContext()
		{
			Table<Manager>.Value = Managers;
			Table<Courier>.Value = Couriers;
			Table<Car>.Value = Cars;
		}

		public DbSet<T> GetTable<T>()
			where T : class
			=> Table<T>.Value;

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
			=> optionsBuilder.UseSqlite("Data Source = Catering.db");

		private static class Table<T>
			where T : class
		{
			public static DbSet<T> Value = null!;
		}
	}
}