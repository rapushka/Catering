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
		get => base.Item;
		set
		{
			base.Item = value;
			EditTitleTextBox.Text = value?.Title ?? string.Empty;
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

	private void OnSearchChange(object sender, TextChangedEventArgs e) => UpdateTableView();
}