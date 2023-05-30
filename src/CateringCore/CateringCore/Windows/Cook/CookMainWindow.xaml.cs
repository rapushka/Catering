using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Catering.DbWorking;
using CateringCore.Model;
using CateringCore.Windows.Pages;
using OrganizerCore.Tools.Extensions;

namespace CateringCore.Windows.Cook;

public partial class CookMainWindow
{
	private const string CookSuffix = ", Повар";

	private readonly Model.Cook _cook;

	private Order? SelectedOrder => OrdersDataGrid.SelectedItem as Order;

	public CookMainWindow(Model.Cook cook)
	{
		_cook = cook;
		InitializeComponent();
	}

	private void Page_Load(object sender, RoutedEventArgs e)
	{
		EmployeeFullnameTextBlock.Text = _cook.Fullname + CookSuffix;

		UpdateView();
	}

	private void UpdateFilters(object sender, TextChangedEventArgs e) => UpdateView();

	private void OnOrderReselected(object sender, SelectedCellsChangedEventArgs e)
	{
		FoodsInOrderDataGrid.Setup<FoodInOrder>(Filter);
	}

	private void MarkAsCooked(object sender, RoutedEventArgs e)
	{
		if (FoodsInOrderDataGrid.EnsureSelected<FoodInOrder>("блюдо в заказе", out var foodInOrder))
		{
			const string isReady = FoodInOrder.StateName.Ready;
			foodInOrder.State = isReady;
			var order = foodInOrder.Order;

			if (CollectFoodOfCurrentOrder(order).Any((fio) => fio.State != isReady) == false)
			{
				order.State = Order.StateName.ReadyForDelivery;
			}

			DbWorker.SaveAll();
			UpdateView();
		}
	}

	private static IEnumerable<FoodInOrder> CollectFoodOfCurrentOrder(Order order)
		=> DbWorker.Context.FoodsInOrders.AsEnumerable().Where((fio) => fio.Order == order);

	private void UpdateView()
	{
		OrdersDataGrid.Setup<Order>(Filter);
		SetupOrderColumns();
		FoodsInOrderDataGrid.Setup<FoodInOrder>(Filter);
		SetupFoodColumns();
	}

	private void SetupOrderColumns()
	{
		OrdersDataGrid
			.ClearColumns()
			.AddTextColumn("Номер", nameof(Order.Id))
			.AddTextColumn("ФИО заказчика", nameof(Order.Fullname))
			;
	}

	private void SetupFoodColumns()
	{
		FoodsInOrderDataGrid
			.ClearColumns()
			.AddTextColumn("Название", nameof(FoodInOrder.Food))
			.AddTextColumn("Количество", nameof(FoodInOrder.Amount))
			;
	}

	private bool Filter(Order order)
		=> order.State == Order.StateName.Processed
		   && SearchOrderIdTextBox.NumberEqualsTo(order.Id);

	private bool Filter(FoodInOrder foodInOrder)
		=> foodInOrder.Order == SelectedOrder
		   && foodInOrder.State == FoodInOrder.StateName.NotReady;
}