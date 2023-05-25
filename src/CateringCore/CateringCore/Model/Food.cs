using System.ComponentModel.DataAnnotations;

namespace CateringCore.Model;

public class Food
{
	[Key] public int          Id          { get; set; }
	public       FoodType     Type        { get; set; } = null!;
	public       FoodCategory Category    { get; set; } = null!;
	public       string       Title       { get; set; } = null!;
	public       string       Composition { get; set; } = null!;
	public       double       Weight      { get; set; }
	public       decimal      Price       { get; set; }
}