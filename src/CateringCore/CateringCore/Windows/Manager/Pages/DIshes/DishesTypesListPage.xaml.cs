using System.Windows;
using System.Windows.Controls;
using CateringCore.Model;
using OrganizerCore.Tools.Extensions;

namespace CateringCore.Windows.Pages;

public partial class DishesTypesListPage
{
	public DishesTypesListPage() => InitializeComponent();

	private void DishesTypesListPage_OnLoaded(object sender, RoutedEventArgs e)
	{
		UpdateTableView();
		SetupDishesTypes();
	}

	private void UpdateTableView() => DishesTypesDataGrid.Setup<DishType>(Filter);

	private void SetupDishesTypes()
	{
		DishesTypesDataGrid
			.ClearColumns()
			.AddTextColumn("Наименование", nameof(DishType.Title))
			;
	}

	private bool Filter(DishType dishType) => dishType.Title.Contains(SearchTitleTextBox.Text);

	private void SearchTitleTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
		=> UpdateTableView();
}