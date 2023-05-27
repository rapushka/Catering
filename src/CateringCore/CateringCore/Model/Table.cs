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
		Func<FoodType, T> forFoodType
	)
		=> this switch
		{
			DishType dishType => forDishesType(dishType),
			Dish dish => forDish(dish),
			Food food => forFood(food),
			FoodCategory foodCategory => forFoodCategory(foodCategory),
			FoodType foodType => forFoodType(foodType),
			_ => throw new InvalidOperationException($"Не найдена реализация для таблицы {GetType().Name}"),
		};
}