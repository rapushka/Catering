namespace CateringCore.Model;

public class FoodInOrder : Table
{
	public Food   Food   { get; set; } = null!;
	public Order  Order  { get; set; } = null!;
	public Cook?  Cook   { get; set; }
	public int    Amount { get; set; }
	public string State  { get; set; } = null!;

	public decimal Cost => Food.Price * Amount;

	public override string ToString() => $"{Food} из {Order}";

	public static class StateName
	{
		public const string NotReady = "Не готов";
		public const string Ready = "Готов";

		public static string[] All => new[] { NotReady, Ready };
	}
}