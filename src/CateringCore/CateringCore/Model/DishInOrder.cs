using System.ComponentModel.DataAnnotations;

namespace CateringCore.Model;

public class DishInOrder : Table
{
	[Key] public int     Id       { get; set; }
	public       Dish    Dish     { get; set; } = null!;
	public       Order   Order    { get; set; } = null!;
	public       int     Quantity { get; set; }
	public       decimal Cost     { get; set; }
}