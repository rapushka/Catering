using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using CateringCore.Model;
using OrganizerCore.Tools.Extensions;

namespace CateringCore.Windows.Pages.Foods;

public partial class FoodsListPage
{
	public FoodsListPage() => InitializeComponent();

	public override DataGrid DataGrid => FoodDataGrid;

	protected override string NameOfItemType => "Блюдо";

	protected override IEnumerable<UIElement> EditItemElements => new UIElement[] { ApplyButton };

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