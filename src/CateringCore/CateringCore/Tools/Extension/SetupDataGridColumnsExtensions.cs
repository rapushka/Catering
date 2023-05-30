using System;
using System.Windows.Controls;
using CateringCore.Model;
using OrganizerCore.Tools.Extensions;

namespace CateringCore.Windows.Pages;

public static class SetupDataGridColumnsExtensions
{
	public static DataGrid SetupWithColumns<T>(this DataGrid @this, Func<T, bool> filter)
		where T : class
		=> @this.Setup(filter).WithColumns<T>();

	public static DataGrid WithColumns<T>(this DataGrid @this)
	{
		var t = typeof(T);

		if (t.Is<Order>())
		{
			@this.ForOrder();
		}
		else if (t.Is<FoodInOrder>())
		{
			@this.ForFoodInOrder();
		}
		else if (t.Is<DishInOrder>())
		{
			@this.ForDishInOrder();
		}
		else if (t.Is<Food>())
		{
			@this.ForFood();
		}
		else if (t.Is<Dish>())
		{
			@this.ForDishes();
		}
		else
		{
			throw new Exception($"Не найдет коструктор столбцовв для типа {t.Name}");
		}

		return @this;
	}

	private static void ForOrder(this DataGrid @this)
	{
		@this
			.ClearColumns()
			.AddTextColumn("Номер", nameof(Order.Id))
			.AddTextColumn("ФИО заказчика", nameof(Order.Fullname))
			.AddTextColumn("Номер телефона", nameof(Order.PhoneNumber))
			.AddTextColumn("Адрес", nameof(Order.Address))
			.AddTextColumn("Дата", nameof(Order.FulfillmentDate))
			.AddTextColumn("Email", nameof(Order.Email))
			.AddTextColumn("Количество человек", nameof(Order.NumberOfPeople))
			.AddTextColumn("Сумма аванса", nameof(Order.AdvanceAmount))
			.AddTextColumn("Стоимость", nameof(Order.Cost))
			.AddTextColumn("Курьер", nameof(Order.Courier))
			.AddTextColumn("Авто", nameof(Order.Car))
			.AddTextColumn("Состояние", nameof(Order.State))
			.AddTextColumn("Дата оформления", nameof(Order.OrderDate))
			;
	}

	private static void ForFoodInOrder(this DataGrid @this)
	{
		@this
			.ClearColumns()
			.AddTextColumn("Блюдо", nameof(FoodInOrder.Food))
			.AddTextColumn("Количество", nameof(FoodInOrder.Amount))
			.AddTextColumn("Стоимость", nameof(FoodInOrder.Cost))
			;
	}

	private static void ForDishInOrder(this DataGrid @this)
	{
		@this
			.ClearColumns()
			.AddTextColumn("Посуда", nameof(DishInOrder.Dish))
			.AddTextColumn("Количество", nameof(DishInOrder.Quantity))
			.AddTextColumn("Стоимость", nameof(DishInOrder.Cost))
			;
	}

	private static void ForFood(this DataGrid @this)
	{
		@this
			.ClearColumns()
			.AddTextColumn("Наименование", nameof(Food.Title))
			.AddTextColumn("Состав", nameof(Food.Composition))
			.AddTextColumn("Вес", nameof(Food.Weight))
			.AddTextColumn("Цена", nameof(Food.Price))
			;
	}

	private static void ForDishes(this DataGrid @this)
	{
		@this
			.ClearColumns()
			.AddTextColumn("Наименование", nameof(Dish.Title))
			.AddTextColumn("Цена", nameof(Dish.Price))
			;
	}
}