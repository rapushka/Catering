namespace CateringCore.Model;

public class FoodCategory : Table, ITitledTable
{
	public string Title { get; set; } = null!;

	public override string ToString() => Title;
}