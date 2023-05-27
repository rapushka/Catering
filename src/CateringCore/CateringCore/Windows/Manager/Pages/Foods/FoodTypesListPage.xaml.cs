using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using CateringCore.Model;
using OrganizerCore.Tools.Extensions;

namespace CateringCore.Windows.Pages.Foods;

public partial class FoodTypesListPage
{
	public FoodTypesListPage() => InitializeComponent();

	public override DataGrid DataGrid => FoodCategoriesDataGrid;

	protected override string NameOfItemType => "вид блюда";

	protected override FoodType ReadItemFromControls()              => new() { Title = EditTitleTextBox.Text };
	protected override void     WriteItemToControls(FoodType? item) => EditTitleTextBox.Text = item?.Title;

	protected override IEnumerable<UIElement> EditItemElements => new[] { ApplyButton };

	protected override void SetupColumns()
	{
		FoodCategoriesDataGrid
			.ClearColumns()
			.AddTextColumn("Наименование", nameof(FoodType.Title))
			;
	}

	protected override bool Filter(FoodType item) => item.Title.Contains(SearchTitleTextBox.Text);

	protected override void UpdateItem(ref FoodType selected, FoodType newItem)
		=> selected.Title = newItem.Title;

	private void OnSearchChange(object sender, TextChangedEventArgs e) => UpdateTableView();
}