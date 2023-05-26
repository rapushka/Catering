using System.ComponentModel.DataAnnotations;

namespace CateringCore.Model;

public class FoodType : Table
{
	public       string Title { get; set; } = null!;
}