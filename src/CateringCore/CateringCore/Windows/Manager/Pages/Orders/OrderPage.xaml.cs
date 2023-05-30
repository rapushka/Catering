using System;
using System.Linq;
using System.Net.Http;
using System.Reflection.Metadata.Ecma335;
using System.Windows;
using System.Windows.Controls;
using Catering.DbWorking;
using CateringCore.Model;
using CateringCore.Windows.Pages.Orders;
using OrganizerCore.Tools;
using OrganizerCore.Tools.Extensions;

namespace CateringCore.Windows.Pages;

public partial class OrdersListPage
{
	public OrdersListPage() => InitializeComponent();

#pragma warning disable CA1822
	private Order? SelectedOrder => OrdersDataGrid.SelectedItem as Order;
#pragma warning restore CA1822

	private void Page_Load(object sender, RoutedEventArgs e) => UpdateView();

	private void UpdateView()
	{
		OrdersDataGrid.SetupWithColumns<Order>(Filter);
		FoodsInOrderDataGrid.SetupWithColumns<FoodInOrder>(Filter);
		DishesInOrderDataGrid.SetupWithColumns<DishInOrder>(Filter);
	}

	private bool Filter(Order order) => SearchOrderIdTextBox.NumberEqualsTo(order.Id)
	                                    && order.Fullname.Contains(SearchFullNameTextBox.Text);

	private bool Filter(FoodInOrder foodInOrder) => foodInOrder.Order == SelectedOrder;
	private bool Filter(DishInOrder dishInOrder) => dishInOrder.Order == SelectedOrder;

	private void AddButton_Click(object sender, RoutedEventArgs e)
	{
		var newOrder = new Order
		{
			OrderDate = DateTime.Now,
			State = Order.StateName.All.First(),
			Manager = DbWorker.ActiveManager,
		};
		DbWorker.Context.Orders.Add(newOrder);
		EditOrder(newOrder);
	}

	private void EditButton_Click(object sender, RoutedEventArgs e)
	{
		if (EnsureSelectedOrder(out var order))
		{
			order.OrderDate = DateTime.Now;
			EditOrder(order);
		}
	}

	private void AssignButton_Click(object sender, RoutedEventArgs e)
	{
		if (EnsureSelectedOrder(out var order))
		{
			NavigationService!.Navigate(new AppointToOrderPage(order));
		}
	}

	private void RemoveButton_Click(object sender, RoutedEventArgs e)
	{
		if (EnsureSelectedOrder(out var order)
		    && MessageBoxUtils.ConfirmDeletion(order))
		{
			DbWorker.Context.Orders.Remove(order);
			DbWorker.SaveAll();
			UpdateView();
		}
	}

	private void EditOrder(Order order) => Open(new EditOrderFirstPage(order));

	private void Open(Page page) => NavigationService!.Navigate(page);

	private bool EnsureSelectedOrder(out Order order) => OrdersDataGrid.EnsureSelected("заказ", out order);
}