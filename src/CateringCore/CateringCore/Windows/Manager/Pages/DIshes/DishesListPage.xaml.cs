using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Catering.DbWorking;
using CateringCore.Model;
using CateringCore.Windows.Pages.Common;
using OrganizerCore.DbWorking;

namespace CateringCore.Windows.Pages;

public partial class DishesListPage : EditableListPage<Dish>
{
	public DishesListPage() => InitializeComponent();

	private void DishesListPage_OnLoaded(object sender, RoutedEventArgs e)
	{
		DishesDataGrid.ItemsSource = DbWorker.Context.Dishes.Observe();
	}

	private void DishesTypesButton_OnClick(object sender, RoutedEventArgs e)
	{
		NavigationService!.Navigate(new DishesTypesListPage());
	}

	public override    DataGrid               DataGrid         => DishesDataGrid;
	protected override string                 NameOfItemType   => "посуду";
	protected override IEnumerable<UIElement> EditItemElements { get; }
	protected override void                   SetupTable()     { }

	protected override bool Filter(Dish dish)
		=> dish.Title.Contains(SearchTitleTextBox.Text)
		   && dish.Type == (DishType)SearchTypeComboBox.SelectedItem;

	protected override void UpdateItem(ref Dish selected) { }
}