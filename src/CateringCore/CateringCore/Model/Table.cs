using System;
using System.ComponentModel.DataAnnotations;

namespace CateringCore.Model;

public class Table
{
	[Key] public int Id { get; set; }

	public T Visit<T>
	(
		Func<DishType, T> forDishesType,
		Func<Dish, T> forDish,
		Func<Food, T> forFood,
		Func<FoodCategory, T> forFoodCategory,
		Func<FoodType, T> forFoodType,
		Func<Manager, T> forManager,
		Func<Courier, T> forCourier,
		Func<Cook, T> forCook,
		Func<Order, T> forOrder,
		Func<Car, T> forCar
	)
		=> this switch
		{
			DishType dishType => forDishesType(dishType),
			Dish dish => forDish(dish),
			Food food => forFood(food),
			FoodCategory foodCategory => forFoodCategory(foodCategory),
			FoodType foodType => forFoodType(foodType),
			Manager manager => forManager(manager),
			Courier courier => forCourier(courier),
			Cook cook => forCook(cook),
			Order order => forOrder(order),
			Car car => forCar(car),
			_ => throw new InvalidOperationException($"Не найдена реализация для таблицы {GetType().Name}"),
		};
}