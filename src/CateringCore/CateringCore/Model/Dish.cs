using System.ComponentModel.DataAnnotations;

namespace CateringCore.Model;

public class Dish : Table
{
	[Key] public int      Id    { get; set; }
	public       string   Title { get; set; } = null!;
	public       DishType Type  { get; set; } = null!;
	public       decimal  Price { get; set; }

	public override string ToString() => Title;
}