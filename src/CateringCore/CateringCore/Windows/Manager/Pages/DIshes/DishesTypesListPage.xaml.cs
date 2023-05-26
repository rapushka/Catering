using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
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

	private void UpdateTableView()
	{
		DishesTypesDataGrid.Setup<DishType>((dt) => dt.Title.Contains(SearchTitleTextBox.Text));
	}

	private void Filter(object sender, FilterEventArgs e)
	{
		var dishType = (DishType)e.Item;
		var title = SearchTitleTextBox.Text;

		var firsByTitle = dishType.Title == title;

		e.Accepted = firsByTitle;
	}

	private void SetupDishesTypes()
	{
		DishesTypesDataGrid.Columns.Clear();

		DishesTypesDataGrid
			.AddTextColumn("Наименование", nameof(DishType.Title))
			;
	}

	private void SearchTitleTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
		=> UpdateTableView();
}