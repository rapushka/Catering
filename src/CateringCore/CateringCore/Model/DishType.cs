namespace CateringCore.Model;

public class DishType : Table, ITitledTable
{
	public string Title { get; set; } = null!;

	public override string ToString() => Title;
}