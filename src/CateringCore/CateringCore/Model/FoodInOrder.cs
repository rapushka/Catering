using System.ComponentModel.DataAnnotations;

namespace CateringCore.Model;

public class FoodInOrder : Table
{
	public       Food    Food   { get; set; } = null!;
	public       Order   Order  { get; set; } = null!;
	public       Cook?   Cook   { get; set; }
	public       int     Amount { get; set; }
	public       decimal Cost   { get; set; }
	public       string  State  { get; set; } = null!;
}