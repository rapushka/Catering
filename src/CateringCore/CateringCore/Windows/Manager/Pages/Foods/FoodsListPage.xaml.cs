using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using CateringCore.Model;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
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
			.AddTextColumn("Наименование", nameof(Food.Title))
			// TODO: add other
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

	private void OpenTypes(object sender, RoutedEventArgs e) => throw new NotImplementedException();

	private void NavigateTo<T>() where T : Page, new() => NavigationService!.Navigate(new T());
}