using System;
using System.ComponentModel.DataAnnotations;

namespace CateringCore.Model;

public class Table
{
	[Key] public int Id { get; set; }

	public T Visit<T>
	(
		Func<DishType, T> forDishesType,
		Func<Dish, T> forDish
	)
		=> this switch
		{
			DishType dishType => forDishesType(dishType),
			Dish dish => forDish(dish),
			_ => throw new InvalidOperationException($"Unknown {nameof(Table)} type. Is {GetType().Name}"),
		};
}