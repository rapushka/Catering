namespace CateringCore.Model;

public class DishInOrder : Table
{
	public       Dish    Dish     { get; set; } = null!;
	public       Order   Order    { get; set; } = null!;
	public       int     Quantity { get; set; }
	public       decimal Cost     { get; set; }

	public override string ToString() => $"{Dish} в заказе {Order}";
}