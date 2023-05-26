using System.Windows;
using Catering.DbWorking;
using OrganizerCore.DbWorking;

namespace CateringCore.Windows.Pages;

public partial class DishesListPage
{
	public DishesListPage()
	{
		InitializeComponent();
	}

	private void DishesListPage_OnLoaded(object sender, RoutedEventArgs e)
	{
		DishesDataGrid.ItemsSource = DbWorker.Context.Dishes.Observe();
	}

	private void DishesTypesButton_OnClick(object sender, RoutedEventArgs e)
	{
		NavigationService!.Navigate(new DishesTypesListPage());
	}
}