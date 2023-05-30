using System;

namespace CateringCore.Model;

public class User : Table
{
	public string FirstName   { get; set; } = null!;
	public string LastName    { get; set; } = null!;
	public string MiddleName  { get; set; } = null!;
	public string Login       { get; set; } = null!;
	public string Password    { get; set; } = null!;
	public string PhoneNumber { get; set; } = null!;

	public string Fullname => $"{FirstName} {LastName} {MiddleName}";

	public string Position
		=> this switch
		{
			Manager => PositionName.Manager,
			Courier => PositionName.Courier,
			Cook    => PositionName.Cook,
			_       => throw new ArgumentException("Неизвестная должность")
		};

	public bool Authorize(string login, string password)
		=> Login == login && Password == password;

	public override string ToString() => $"{Position} {Fullname}";

	public static class PositionName
	{
		public const string Manager = "Менеджер";
		public const string Courier = "Курьер";
		public const string Cook = "Повар";

		public static string[] All => new[] { Manager, Courier, Cook };
	}
}