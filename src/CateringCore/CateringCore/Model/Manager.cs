using System.ComponentModel.DataAnnotations;

namespace CateringCore.Model;

public class Manager : Table
{
	[Key] public int    Id          { get; set; }
	public       string FirstName   { get; set; } = null!;
	public       string LastName    { get; set; } = null!;
	public       string MiddleName  { get; set; } = null!;
	public       string Login       { get; set; } = null!;
	public       string Password    { get; set; } = null!;
	public       string PhoneNumber { get; set; } = null!;
}