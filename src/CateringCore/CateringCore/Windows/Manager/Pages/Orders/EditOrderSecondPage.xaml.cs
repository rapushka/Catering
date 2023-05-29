using System;
using System.Windows;
using Catering.DbWorking;
using CateringCore.Model;
using OrganizerCore.Tools;
using OrganizerCore.Tools.Extensions;

namespace CateringCore.Windows.Pages.Orders;

public partial class EditOrderSecondPage
{
	private readonly Order _order;

	public EditOrderSecondPage(Order order)
	{
		_order = order;
		InitializeComponent();
	}

	private void Page_Load(object sender, RoutedEventArgs e) => Load();

	private bool Filter(Dish dish) => dish.Title.Contains(SearchDishTitleTextBox.Text);

	private bool Filter(Food food) => food.Title.Contains(SearchFoodTitleTextBox.Text);

	private bool Filter(FoodInOrder foodInOrder) => foodInOrder.Order == _order;

	private bool Filter(DishInOrder dishInOrder) => dishInOrder.Order == _order;

	private void SaveButton_OnClick(object sender, RoutedEventArgs e)
	{
		try
		{
			_order.State = Order.StateName.Processed;
			DbWorker.SaveAll();
			GoBackToList();
		}
		catch (Exception ex)
		{
			MessageBoxUtils.ShowOnSaveException(ex);
		}
	}

	private void CancelButton_OnClick(object sender, RoutedEventArgs e)
	{
		DbWorker.ResetAll();
		GoBackToList();
	}

	private void Load()
	{
		AllFoodsDataGrid.Setup<Food>(Filter);
		PickedFoodsDataGrid.Setup<FoodInOrder>(Filter);
		AllFoodsDataGrid.Setup<Dish>(Filter);
		PickedDishesDataGrid.Setup<DishInOrder>(Filter);
	}

	private void GoBackToList() => NavigationService!.Navigate(new OrdersListPage());
}