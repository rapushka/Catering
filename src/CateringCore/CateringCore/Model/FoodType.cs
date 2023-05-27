namespace CateringCore.Model;

public class FoodType : Table, ITitledTable
{
	public string Title { get; set; } = null!;

	public override string ToString() => Title;
}