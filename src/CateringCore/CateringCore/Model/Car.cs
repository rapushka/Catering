using System.ComponentModel.DataAnnotations;

namespace CateringCore.Model;

public class Car : Table
{
	[Key] public int    Id     { get; set; }
	public       string Mark   { get; set; } = null!;
	public       string Type   { get; set; } = null!;
	public       string Number { get; set; } = null!;
}