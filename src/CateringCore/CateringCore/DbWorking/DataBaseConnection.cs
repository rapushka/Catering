using System;
using Microsoft.EntityFrameworkCore;

namespace Catering.DbWorking;

public class DataBaseConnection
{
	private static DataBaseConnection? _instance;
	private ApplicationContext? _currentContext;

	private DataBaseConnection() { }

	public static DataBaseConnection Instance => _instance ??= new DataBaseConnection();

	public ApplicationContext CurrentContext => _currentContext ?? throw new NullReferenceException();

	public void ResetAll() => OpenDataBase();

	public void OpenDataBase()
	{
		_currentContext = new ApplicationContext();
		_currentContext.Database.Migrate();
		_currentContext.Database.EnsureCreated();

		_currentContext.Cars.Load();
		_currentContext.Cooks.Load();
		_currentContext.Couriers.Load();
		_currentContext.Dishes.Load();
		_currentContext.DishTypes.Load();
		_currentContext.DishesInOrders.Load();
		_currentContext.Foods.Load();
		_currentContext.FoodCategories.Load();
		_currentContext.FoodsInOrders.Load();
		_currentContext.FoodTypes.Load();
		_currentContext.Managers.Load();
		_currentContext.Orders.Load();
	}
}