using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using CateringCore.Model;
using OrganizerCore.Tools.Extensions;

namespace CateringCore.Windows.Pages.Foods;

public partial class FoodCategoriesListPage
{
	public FoodCategoriesListPage() => InitializeComponent();

	public override DataGrid DataGrid => FoodCategoriesDataGrid;

	protected override string NameOfItemType => "Категорию блюда";

	protected override IEnumerable<UIElement> EditItemElements => new[] { ApplyButton };

	protected override void SetupColumns()
	{
		DataGrid
			.ClearColumns()
			.AddTextColumn("Наименование", nameof(FoodCategory.Title))
			;
	}

	protected override bool Filter(FoodCategory item) => true;

	protected override void UpdateItem(ref FoodCategory selected, FoodCategory newItem)
		=> selected.Title = newItem.Title;
}