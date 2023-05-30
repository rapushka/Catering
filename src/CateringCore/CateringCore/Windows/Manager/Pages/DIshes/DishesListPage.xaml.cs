using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using CateringCore.Model;
using CateringCore.Tools.Extension;
using OrganizerCore.Tools.Extensions;
using OrganizerCore.Windows.Pages.StudentsTab;

namespace CateringCore.Windows.Pages;

public partial class DishesListPage
{
	public DishesListPage() => InitializeComponent();

	protected override Dish ReadItemFromControls()
		=> new()
		{
			Title = EditTitleTextBox.Text,
			Type = (DishType)EditTypeComboBox.SelectedItem,
			Price = decimal.Parse(EditPriceTextBox.Text),
		};

	protected override void WriteItemToControls(Dish? item)
	{
		EditTitleTextBox.Text = item?.Title;
		EditPriceTextBox.Text = item?.Price.ToString(CultureInfo.InvariantCulture);
		EditTypeComboBox.SelectedItem = item?.Type;
	}

	protected override DataGrid DataGrid => DishesDataGrid;

	protected override string NameOfItemType => "посуду";

	protected override IEnumerable<UIElement> EditItemElements => ApplyItemButton.AsArray();

	protected override void Page_OnLoaded(object? sender = null, RoutedEventArgs? e = null)
	{
		base.Page_OnLoaded(sender, e);

		EditTypeComboBox.SetupEdit<DishType>();
		SearchTypeComboBox.SetupSearch<DishType>();
	}

	protected override void SetupColumns()
	{
		DataGrid
			.ClearColumns()
			.AddTextColumn("Наименование", nameof(Dish.Title))
			.AddTextColumn("Тип", nameof(Dish.Type))
			.AddTextColumn("Стоимость", nameof(Dish.Price))
			;
	}

	protected override bool Filter(Dish dish)
		=> dish.Title.Contains(SearchTitleTextBox.Text)
		   && SearchTypeComboBox.IsMatchSearch(dish.Type);

	protected override bool IsAllFieldsFilled
		=> EditPriceTextBox.IsNotEmpty()
		   && EditTypeComboBox.IsNotEmpty()
		   && EditTitleTextBox.IsNotEmpty();

	protected override void UpdateItem(ref Dish selected, Dish newItem)
	{
		selected.Title = newItem.Title;
		selected.Price = newItem.Price;
		selected.Type = newItem.Type;
	}

	private void DishesTypesButton_OnClick(object sender, RoutedEventArgs e) => NavigateTo<DishesTypesListPage>();
}