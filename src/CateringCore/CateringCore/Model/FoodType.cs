using System.ComponentModel.DataAnnotations;

namespace CateringCore.Model;

public class FoodType
{
	[Key] public int    Id    { get; set; }
	public       string Title { get; set; } = null!;
}