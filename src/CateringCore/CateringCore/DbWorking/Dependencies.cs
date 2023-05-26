using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using CateringCore.Model;

namespace Catering.DbWorking;

public static class Dependencies
{
	private static IEnumerable<Dish>        Dishes         => DbWorker.Context.Dishes.AsEnumerable();
	private static IEnumerable<DishInOrder> DishesInOrders => DbWorker.Context.DishesInOrders.AsEnumerable();

	public static List<string> For<T>(T table)
		where T : Table
		=> table.Visit
		(
			forDishesType: ForDishesType,
			forDish: (d) => DishesInOrders.Where((dio) => dio.Dish == d).Select(Format).ToList()
		);

	private static List<string> ForDishesType(DishType dishType)
	{
		var dishes = Dishes.Where((d) => d.Type == dishType).ToList();
		var dishesNames = dishes.Select(Format);
		var dishesInOrders = dishes.SelectMany(For);

		return dishesNames.Concat(dishesInOrders).ToList();
	}

	private static string Format(DishInOrder dishInOrder) => FromTable(dishInOrder.ToString(), "Посуда в заказе");

	private static string Format(Dish dish) => FromTable(dish.ToString(), "Посуда");

	private static string FromTable(string item, string tableName) => $"{item} из таблицы {tableName}";
}