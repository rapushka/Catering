using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using CateringCore.Model;
using OrganizerCore.Tools.Extensions;

namespace CateringCore.Windows.Pages;

public partial class DishesTypesListPage
{
	public DishesTypesListPage() => InitializeComponent();

	public override DataGrid DataGrid => DishesTypesDataGrid;

	protected override string NameOfItemType => "Виды посуды";

	protected override IEnumerable<UIElement> EditItemElements
		=> new[]
		{
			EditTitleTextBox,
		};

	protected override DishType? Item
	{
		get => new() { Title = EditTitleTextBox.Text };
		set
		{
			EditTitleTextBox.Text = value?.Title ?? string.Empty;

			base.Item = value;
		}
	}

	protected override void SetupTable()
	{
		DishesTypesDataGrid
			.ClearColumns()
			.AddTextColumn("Наименование", nameof(DishType.Title))
			;
	}

	protected override bool Filter(DishType item) => item.Title.Contains(SearchTitleTextBox.Text);

	protected override void UpdateItem(ref DishType selected)
	{
		var newItem = Item!;
		selected.Title = newItem.Title;
	}

	private void OnSearchChange(object sender, TextChangedEventArgs e) => UpdateTableView();
}