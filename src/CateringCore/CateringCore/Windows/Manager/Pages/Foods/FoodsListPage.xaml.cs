using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using Catering.DbWorking;
using CateringCore.Model;
using CateringCore.Tools.Extension;
using OrganizerCore.DbWorking;
using OrganizerCore.Tools.Extensions;
using OrganizerCore.Windows.Pages.StudentsTab;

namespace CateringCore.Windows.Pages.Foods;

public partial class FoodsListPage
{
	public FoodsListPage() => InitializeComponent();

	protected override DataGrid DataGrid => FoodDataGrid;

	private static IEnumerable<FoodType>     FoodTypes      => DbWorker.Context.FoodTypes.Observe();
	private static IEnumerable<FoodCategory> FoodCategories => DbWorker.Context.FoodCategories.Observe();

	protected override string NameOfItemType => "Блюдо";

	protected override IEnumerable<UIElement> EditItemElements => ApplyButton.AsArray();

	protected override void Page_OnLoaded(object? sender = null, RoutedEventArgs? e = null)
	{
		base.Page_OnLoaded(sender, e);

		EditCategoryComboBox.ItemsSource = FoodCategories;
		EditTypeComboBox.ItemsSource = FoodTypes;

		EditCategoryComboBox.SetupSearch(FoodCategories);
		EditTypeComboBox.SetupSearch(FoodTypes);
	}

	protected override void WriteItemToControls(Food? item)
	{
		EditTitleTextBox.Text = item?.Title;
		EditCategoryComboBox.SelectedItem = item?.Category;
		EditTypeComboBox.SelectedItem = item?.Type;
		EditCompositionTextBox.Text = item?.Composition;
		EditWeightTextBox.Text = item?.Weight.ToString(CultureInfo.InvariantCulture);
		EditPriceTextBox.Text = item?.Price.ToString(CultureInfo.InvariantCulture);
	}

	protected override Food ReadItemFromControls()
		=> new()
		{
			Title = EditTitleTextBox.Text,
			Category = (FoodCategory)EditCategoryComboBox.SelectedItem,
			Type = (FoodType)EditTypeComboBox.SelectedItem,
			Composition = EditCompositionTextBox.Text,
			Weight = double.Parse(EditWeightTextBox.Text),
			Price = decimal.Parse(EditPriceTextBox.Text),
		};

	protected override void SetupColumns()
	{
		DataGrid
			.ClearColumns()
			.AddTextColumn("Тип", nameof(Food.Type))
			.AddTextColumn("Категория", nameof(Food.Category))
			.AddTextColumn("Наименование", nameof(Food.Title))
			.AddTextColumn("Состав", nameof(Food.Composition))
			.AddTextColumn("Вес", nameof(Food.Weight))
			.AddTextColumn("Цена", nameof(Food.Price))
			;
	}

	protected override bool Filter(Food item) => true;

	protected override void UpdateItem(ref Food selected, Food newItem)
	{
		selected.Type = newItem.Type;
		selected.Category = newItem.Category;
		selected.Title = newItem.Title;
		selected.Composition = newItem.Composition;
		selected.Weight = newItem.Weight;
		selected.Price = newItem.Price;
	}

	private void OpenCategories(object sender, RoutedEventArgs e) => NavigateTo<FoodCategoriesListPage>();

	private void OpenTypes(object sender, RoutedEventArgs e) => NavigateTo<FoodTypesListPage>();

	private void NavigateTo<T>() where T : Page, new() => NavigationService!.Navigate(new T());
}