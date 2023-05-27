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
			Manager => "Менеджер",
			Courier => "Курьер",
			Cook    => "Повар",
			_       => throw new ArgumentException("Неизвестная должность")
		};

	public bool Authorize(string login, string password)
		=> Login == login && Password == password;
}