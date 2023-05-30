using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CateringCore.Model;
using OrganizerCore.Tools;
using OrganizerCore.Tools.Extensions;
using static Catering.DbWorking.DbWorker;

namespace CateringCore.Windows.Pages.Orders;

public partial class EditOrderSecondPage
{
	private readonly Order _order;

	public EditOrderSecondPage(Order order)
	{
		_order = order;
		InitializeComponent();
	}

	private void Page_Load(object sender, RoutedEventArgs e) => UpdateTableView();

#region Filters

	private bool Filter(Dish dish) => dish.Title.Contains(SearchDishTitleTextBox.Text);

	private bool Filter(Food food) => food.Title.Contains(SearchFoodTitleTextBox.Text);

	private bool Filter(FoodInOrder foodInOrder) => foodInOrder.Order == _order;

	private bool Filter(DishInOrder dishInOrder) => dishInOrder.Order == _order;

#endregion

#region Save/Load

	private void SaveButton_OnClick(object sender, RoutedEventArgs e)
	{
		try
		{
			_order.State = Order.StateName.Processed;
			SaveAll();
			GoBackToList();
		}
		catch (Exception ex)
		{
			MessageBoxUtils.ShowOnSaveException(ex);
		}
	}

	private void CancelButton_OnClick(object sender, RoutedEventArgs e)
	{
		ResetAll();
		GoBackToList();
	}

	private void UpdateTableView()
	{
		AllFoodsDataGrid.SetupWithColumns<Food>(Filter);
		PickedFoodsDataGrid.SetupWithColumns<FoodInOrder>(Filter);
		AllDishesDataGrid.SetupWithColumns<Dish>(Filter);
		PickedDishesDataGrid.SetupWithColumns<DishInOrder>(Filter);
	}

#endregion

	private void GoBackToList() => NavigationService!.Navigate(new OrdersListPage());

	private void BackButton_OnClick(object sender, RoutedEventArgs e)
		=> NavigationService!.Navigate(new EditOrderFirstPage(_order));

#region +- Foods and Dishes to Order

	private void AddFood(object sender, MouseButtonEventArgs e)
	{
		if (AllFoodsDataGrid.EnsureSelected<Food>("блюдо", out var selectedFood) == false)
		{
			return;
		}

		var desired = Context.FoodsInOrders.SingleOrDefault(AlreadyAdded);

		if (desired is not null)
		{
			desired.Amount++;
		}
		else
		{
			var @new = new FoodInOrder
			{
				Order = _order,
				Food = selectedFood,
				Amount = 1,
				State = FoodInOrder.StateName.All.First(),
			};

			Context.FoodsInOrders.Add(@new);
		}

		SaveAll();
		UpdateTableView();

		bool AlreadyAdded(FoodInOrder fio) => fio.Order == _order && fio.Food == selectedFood;
	}

	private void RemoveFood(object sender, MouseButtonEventArgs e)
	{
		if (PickedFoodsDataGrid.EnsureSelected<FoodInOrder>("блюдо в заказе", out var selectedFoodInOrder))
		{
			selectedFoodInOrder.Amount--;

			if (selectedFoodInOrder.Amount == 0)
			{
				Context.FoodsInOrders.Remove(selectedFoodInOrder);
			}
		}

		UpdateTableView();
	}

	private void AddDish(object sender, MouseButtonEventArgs e)
	{
		if (AllDishesDataGrid.EnsureSelected<Dish>("посуду", out var selectedDish) == false)
		{
			return;
		}

		var desired = Context.DishesInOrders.SingleOrDefault(AlreadyAdded);

		if (desired is not null)
		{
			desired.Quantity++;
		}
		else
		{
			var @new = new DishInOrder
			{
				Order = _order,
				Dish = selectedDish,
				Quantity = 1,
			};

			Context.DishesInOrders.Add(@new);
		}

		SaveAll();
		UpdateTableView();

		bool AlreadyAdded(DishInOrder dio) => dio.Order == _order && dio.Dish == selectedDish;
	}

	private void RemoveDish(object sender, MouseButtonEventArgs e)
	{
		if (PickedDishesDataGrid.EnsureSelected<DishInOrder>("посуду в заказе", out var selectedDishInOrder))
		{
			selectedDishInOrder.Quantity--;

			if (selectedDishInOrder.Quantity == 0)
			{
				Context.DishesInOrders.Remove(selectedDishInOrder);
			}
		}

		UpdateTableView();
	}

#endregion

	public void UpdateSums()
	{
		
	}

	private void UpdateSearch(object sender, TextChangedEventArgs e) => UpdateTableView();
}