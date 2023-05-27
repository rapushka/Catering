using System.Collections.Generic;
using System.Linq;
using CateringCore.Model;

namespace Catering.DbWorking;

public static class Dependencies
{
	private static IEnumerable<Dish>        Dishes         => DbWorker.Context.Dishes.AsEnumerable();
	private static IEnumerable<DishInOrder> DishesInOrders => DbWorker.Context.DishesInOrders.AsEnumerable();
	private static IEnumerable<Food>        Foods          => DbWorker.Context.Foods.AsEnumerable();
	private static IEnumerable<FoodInOrder> FoodsInOrders  => DbWorker.Context.FoodsInOrders.AsEnumerable();

	public static List<string> For<T>(T table)
		where T : Table
		=> table.Visit
		(
			forDishesType: ForDishesType,
			forDish: ForDish,
			forFood: ForFood,
			forFoodCategory: ForFoodCategory,
			forFoodType: ForFoodType,
			forManager: ForManager,
			forCourier: ForCourier,
			forCook: ForCook,
			forOrder: ForOrder,
			forCar: ForCar
		);

	private static List<string> ForCar(Car car) => new();

	private static List<string> ForOrder(Order order)
	{
		var foodInOrders = FoodsInOrders.Where((f) => f.Order == order).ToList();
		var dishInOrders = DishesInOrders.Where((d) => d.Order == order).ToList();
		var foodNames = foodInOrders.Select(Format);
		var dishNames = dishInOrders.Select(Format);

		return foodNames.Concat(dishNames).ToList();
	}

	private static List<string> ForManager(Manager manager)
	{
		var orders = Table<Order>().Where((o) => o.Manager == manager);
		var dishesInOrdersNames = orders.Select(Format);

		return dishesInOrdersNames.ToList();
	}

	private static List<string> ForCourier(Courier courier) => new();

	private static List<string> ForCook(Cook cook) => new();

	private static List<string> ForDishesType(DishType dishType)
	{
		var dishes = Dishes.Where((d) => d.Type == dishType).ToList();
		var dishesNames = dishes.Select(Format);
		var dishesInOrdersNames = dishes.SelectMany(For);

		return dishesNames.Concat(dishesInOrdersNames).ToList();
	}

	private static List<string> ForDish(Dish dish)
	{
		var dishesInOrders = DishesInOrders.Where((dio) => dio.Dish == dish);
		var dishesInOrdersNames = dishesInOrders.Select(Format);

		return dishesInOrdersNames.ToList();
	}

	private static List<string> ForFood(Food food)
	{
		var foodsInOrders = FoodsInOrders.Where((fio) => fio.Food == food);
		var foodsInOrdersNames = foodsInOrders.Select(Format);

		return foodsInOrdersNames.ToList();
	}

	private static List<string> ForFoodCategory(FoodCategory foodCategory)
	{
		var foods = Foods.Where((f) => f.Category == foodCategory).ToList();
		var foodsNames = foods.Select(Format);
		var foodsInOrdersNames = foods.SelectMany(For);

		return foodsNames.Concat(foodsInOrdersNames).ToList();
	}

	private static List<string> ForFoodType(FoodType foodType)
	{
		var foods = Foods.Where((f) => f.Type == foodType).ToList();
		var foodsNames = foods.Select(Format);
		var foodsInOrdersNames = foods.SelectMany(For);

		return foodsNames.Concat(foodsInOrdersNames).ToList();
	}

	private static string Format(DishInOrder dishInOrder) => FromTable(dishInOrder.ToString(), "Посуда в заказе");

	private static string Format(Dish dish) => FromTable(dish.ToString(), "Посуда");

	private static string Format(FoodInOrder foodInOrder) => FromTable(foodInOrder.ToString(), "Блюда в заказе");

	private static string Format(Food food) => FromTable(food.ToString(), "Блюда");

	private static string Format(Order order) => FromTable(order.ToString(), "Заказ");

	private static string FromTable(string item, string tableName) => $"{item} из таблицы {tableName}";

	private static IEnumerable<T> Table<T>() where T : class => DbWorker.Context.GetTable<T>().AsEnumerable();
}