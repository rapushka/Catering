namespace CateringCore.Model;

public class DishInOrder : Table
{
	public Dish  Dish     { get; set; } = null!;
	public Order Order    { get; set; } = null!;
	public int   Quantity { get; set; }

	public decimal Cost => Dish.Price * Quantity;

	public override string ToString() => $"{Dish} из {Order}";
}