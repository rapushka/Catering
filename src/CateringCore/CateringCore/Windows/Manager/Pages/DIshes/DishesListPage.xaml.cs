using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using Catering.DbWorking;
using CateringCore.Model;
using OrganizerCore.DbWorking;
using OrganizerCore.Tools.Extensions;

namespace CateringCore.Windows.Pages;

public partial class DishesListPage
{
	public DishesListPage() => InitializeComponent();

	private void DishesTypesButton_OnClick(object sender, RoutedEventArgs e)
		=> NavigationService!.Navigate(new DishesTypesListPage());

	protected override Dish? Item
	{
		get => new()
		{
			Title = EditTitleTextBox.Text,
			Type = (DishType)EditTypeComboBox.SelectedItem,
			Price = decimal.Parse(EditPriceTextBox.Text),
		};
		set
		{
			EditTitleTextBox.Text = value?.Title ?? string.Empty;
			EditPriceTextBox.Text = value?.Price.ToString(CultureInfo.InvariantCulture);
			EditTypeComboBox.SelectedItem = value?.Type;

			base.Item = value;
		}
	}

	public override DataGrid DataGrid => DishesDataGrid;

	protected override string NameOfItemType => "посуду";

	protected override IEnumerable<UIElement> EditItemElements
		=> new UIElement[]
		{
			EditTypeComboBox,
			EditTitleTextBox,
			EditPriceTextBox,
		};

	private static IEnumerable<DishType> DishTypes => DbWorker.Context.DishTypes.Observe();

	protected override void Page_OnLoaded(object? sender = null, RoutedEventArgs? e = null)
	{
		base.Page_OnLoaded(sender, e);

		EditTypeComboBox.ItemsSource = DishTypes;
		// EditTypeComboBox.SelectedValuePath = nameof(DishType.Id);
		// EditTypeComboBox.DisplayMemberPath = nameof(DishType.Title);
	}

	protected override void SetupColumns()
	{
		DataGrid
			.ClearColumns()
			.AddTextColumn("Наименование", nameof(Dish.Title))
			.AddComboBoxColumn("Тип", nameof(Dish.Type), DishTypes, nameof(DishType.Title), nameof(DishType.Id))
			.AddTextColumn("Стоимость", nameof(Dish.Price))
			;
	}

	protected override bool Filter(Dish dish)
	{
		return true;
		return dish.Title.Contains(SearchTitleTextBox.Text)
		       && dish.Type == (DishType)SearchTypeComboBox.SelectedItem;
	}

	protected override void UpdateItem(ref Dish selected, Dish newItem)
	{
		selected.Title = newItem.Title;
		selected.Price = newItem.Price;
		selected.Type = newItem.Type;
	}

	private void SearchTypeComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e) => UpdateTableView();

	private void SearchTitleTextBox_OnTextChanged(object sender, TextChangedEventArgs e) => UpdateTableView();

	private void DishesDataGrid_OnSelectionChanged(object sender, SelectedCellsChangedEventArgs e)
	{
		
	}
}