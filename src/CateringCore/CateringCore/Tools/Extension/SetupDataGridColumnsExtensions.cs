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
		if (typeof(T) == typeof(Order))
		{
			@this.WithColumnsForOrder();
		}
		else if (typeof(T) == typeof(FoodInOrder))
		{
			@this.WithColumnsForFoodInOrder();
		}
		else if (typeof(T) == typeof(DishInOrder))
		{
			@this.WithColumnsForDishInOrder();
		}

		return @this;
	}

	private static void WithColumnsForOrder(this DataGrid @this)
	{
		@this
			.ClearColumns()
			.AddTextColumn("Номер", nameof(Order.Id))
			.AddTextColumn("ФИО заказчика", nameof(Order.Fullname))
			.AddTextColumn("Номер телефона", nameof(Order.PhoneNumber))
			.AddTextColumn("Адрес", nameof(Order.Address))
			.AddTextColumn("Дата", nameof(Order.Date))
			.AddTextColumn("Email", nameof(Order.Email))
			.AddTextColumn("Количество человек", nameof(Order.NumberOfPeople))
			.AddTextColumn("Сумма аванса", nameof(Order.AdvanceAmount))
			// TODO: Cost
			.AddTextColumn("Курьер", nameof(Order.Courier))
			.AddTextColumn("Авто", nameof(Order.Car))
			.AddTextColumn("Состояние", nameof(Order.State))
			// TODO: Order date (Дата оформления)
			;
	}

	private static void WithColumnsForFoodInOrder(this DataGrid @this)
	{
		@this
			.ClearColumns()
			.AddTextColumn("Блюдо", nameof(FoodInOrder.Food))
			.AddTextColumn("Заказ", nameof(FoodInOrder.Order))
			.AddTextColumn("Повар", nameof(FoodInOrder.Cook))
			.AddTextColumn("Количество", nameof(FoodInOrder.Amount))
			.AddTextColumn("Стоимость", nameof(FoodInOrder.Cost))
			.AddTextColumn("Состояние заказа", nameof(FoodInOrder.State))
			;
	}

	private static void WithColumnsForDishInOrder(this DataGrid @this)
	{
		@this
			.ClearColumns()
			.AddTextColumn("Посуда", nameof(DishInOrder.Dish))
			.AddTextColumn("Заказ", nameof(DishInOrder.Order))
			.AddTextColumn("Количество", nameof(DishInOrder.Quantity))
			.AddTextColumn("Стоимость", nameof(DishInOrder.Cost))
			;
	}
}