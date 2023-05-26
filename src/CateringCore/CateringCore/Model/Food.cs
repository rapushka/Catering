namespace CateringCore.Model;

public class Food : Table
{
	public       FoodType     Type        { get; set; } = null!;
	public       FoodCategory Category    { get; set; } = null!;
	public       string       Title       { get; set; } = null!;
	public       string       Composition { get; set; } = null!;
	public       double       Weight      { get; set; }
	public       decimal      Price       { get; set; }

	public override string ToString() => Title;
}