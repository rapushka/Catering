using System.ComponentModel.DataAnnotations;

namespace CateringCore.Model;

public class DishType : Table
{
	public       string Title { get; set; } = null!;
}