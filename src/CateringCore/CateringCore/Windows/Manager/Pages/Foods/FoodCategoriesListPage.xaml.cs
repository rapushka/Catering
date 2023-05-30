using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using CateringCore.Model;
using CateringCore.Tools.Extension;
using OrganizerCore.Tools.Extensions;

namespace CateringCore.Windows.Pages.Foods;

public partial class FoodCategoriesListPage
{
	public FoodCategoriesListPage() => InitializeComponent();

	protected override DataGrid DataGrid => FoodCategoriesDataGrid;

	protected override string NameOfItemType => "Категорию блюда";

	protected override FoodCategory ReadItemFromControls()                  => new() { Title = EditTitleTextBox.Text };
	protected override void         WriteItemToControls(FoodCategory? item) => EditTitleTextBox.Text = item?.Title;

	protected override IEnumerable<UIElement> EditItemElements => ApplyButton.AsArray();

	protected override void SetupColumns()
	{
		FoodCategoriesDataGrid
			.ClearColumns()
			.AddTextColumn("Наименование", nameof(FoodCategory.Title))
			;
	}

	protected override bool Filter(FoodCategory item) => item.Title.Contains(SearchTitleTextBox.Text);

	protected override bool IsAllFieldsFilled => EditTitleTextBox.IsNotEmpty();

	protected override void UpdateItem(ref FoodCategory selected, FoodCategory newItem)
		=> selected.Title = newItem.Title;

	private void OnSearchChange(object sender, TextChangedEventArgs e) => UpdateTableView();
}