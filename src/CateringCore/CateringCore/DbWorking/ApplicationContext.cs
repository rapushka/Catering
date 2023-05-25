using CateringCore.Model;
using Microsoft.EntityFrameworkCore;

namespace Catering.DbWorking
{
	public class ApplicationContext : DbContext
	{
		public DbSet<Car>          Cars           { get; set; } = null!;
		public DbSet<Cook>         Cooks          { get; set; } = null!;
		public DbSet<Courier>      Couriers       { get; set; } = null!;
		public DbSet<Dish>         Dishes         { get; set; } = null!;
		public DbSet<DishType>     DishTypes      { get; set; } = null!;
		public DbSet<DishInOrder>  DishesInOrders { get; set; } = null!;
		public DbSet<Food>         Foods          { get; set; } = null!;
		public DbSet<FoodCategory> FoodCategories { get; set; } = null!;
		public DbSet<FoodInOrder>  FoodsInOrders  { get; set; } = null!;
		public DbSet<FoodType>     FoodTypes      { get; set; } = null!;
		public DbSet<Manager>      Managers       { get; set; } = null!;
		public DbSet<Order>        Orders         { get; set; } = null!;

		public ApplicationContext()
		{
			Table<Car>.Value = Cars;
			Table<Cook>.Value = Cooks;
			Table<Courier>.Value = Couriers;
			Table<Dish>.Value = Dishes;
			Table<DishType>.Value = DishTypes;
			Table<DishInOrder>.Value = DishesInOrders;
			Table<Food>.Value = Foods;
			Table<FoodCategory>.Value = FoodCategories;
			Table<FoodInOrder>.Value = FoodsInOrders;
			Table<FoodType>.Value = FoodTypes;
			Table<Manager>.Value = Managers;
			Table<Order>.Value = Orders;
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