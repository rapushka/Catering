using Microsoft.EntityFrameworkCore;

namespace Catering.DbWorking
{
	public class ApplicationContext : DbContext
	{
		// public DbSet<Student> Students { get; set; } = null!;

		public ApplicationContext()
		{
			// Table<Student>.Value = Students;
		}

		public DbSet<T> GetTable<T>()
			where T : class
			=> Table<T>.Value;

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
			=> optionsBuilder.UseSqlite("Data Source = Organizer.db");

		private static class Table<T>
			where T : class
		{
			public static DbSet<T> Value = null!;
		}
	}
}