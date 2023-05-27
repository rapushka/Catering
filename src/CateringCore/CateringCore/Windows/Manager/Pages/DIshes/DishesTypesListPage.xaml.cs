using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using CateringCore.Model;
using CateringCore.Tools.Extension;
using OrganizerCore.Tools.Extensions;

namespace CateringCore.Windows.Pages;

public partial class DishesTypesListPage
{
	public DishesTypesListPage() => InitializeComponent();

	protected override DataGrid DataGrid => DishesTypesDataGrid;

	protected override DishType ReadItemFromControls()              => new() { Title = EditTitleTextBox.Text };
	protected override void     WriteItemToControls(DishType? item) => EditTitleTextBox.Text = item?.Title;

	protected override string NameOfItemType => "Виды посуды";

	protected override IEnumerable<UIElement> EditItemElements => ApplyItemButton.AsArray();

	protected override void SetupColumns()
	{
		DishesTypesDataGrid
			.ClearColumns()
			.AddTextColumn("Наименование", nameof(DishType.Title))
			;
	}

	protected override bool Filter(DishType item) => item.Title.Contains(SearchTitleTextBox.Text);

	protected override void UpdateItem(ref DishType selected, DishType newItem) => selected.Title = newItem.Title;

	private void OnSearchChange(object sender, TextChangedEventArgs e) => UpdateTableView();
}