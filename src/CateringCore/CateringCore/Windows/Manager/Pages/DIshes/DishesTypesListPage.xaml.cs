using System.Windows;
using Catering.DbWorking;
using OrganizerCore.DbWorking;

namespace CateringCore.Windows.Pages;

public partial class DishesTypesListPage
{
	public DishesTypesListPage()
	{
		InitializeComponent();
	}

	private void DishesTypesListPage_OnLoaded(object sender, RoutedEventArgs e)
	{
		DishesTypesDataGrid.ItemsSource = DbWorker.Context.DishTypes.Observe();
	}
}