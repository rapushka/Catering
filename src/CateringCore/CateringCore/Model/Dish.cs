using System.ComponentModel.DataAnnotations;

namespace CateringCore.Model;

public class Dish
{
	[Key] public int     Id    { get; set; }
	public       string  Title { get; set; } = null!;
	public       string  Type  { get; set; } = null!;
	public       decimal Price { get; set; }
}