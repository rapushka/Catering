namespace CateringCore.Model;

public class Car : Table
{
	public       string Mark   { get; set; } = null!;
	public       string Type   { get; set; } = null!;
	public       string Number { get; set; } = null!;
	
	public static class TypeName
	{
		public const string Passenger = "Легковой";
		public const string Truck = "Грузовой";

		public static string[] All => new[] { Passenger, Truck };
	}

}