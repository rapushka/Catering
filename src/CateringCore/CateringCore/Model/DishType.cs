namespace CateringCore.Model;

public class DishType : Table
{
	public string Title { get; set; } = null!;

	public override string ToString() => Title;
}