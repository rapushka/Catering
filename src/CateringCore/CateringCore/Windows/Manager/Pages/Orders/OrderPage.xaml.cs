using System.Windows;
using System.Windows.Controls;
using Catering.DbWorking;
using CateringCore.Model;
using CateringCore.Tools;
using CateringCore.Windows.Pages.Orders;
using OrganizerCore.Tools.Extensions;

namespace CateringCore.Windows.Pages;

public partial class OrdersListPage
{
	public OrdersListPage() => InitializeComponent();

#pragma warning disable CA1822
	private Order? SelectedOrder => OrdersDataGrid.SelectedItem as Order;
#pragma warning restore CA1822

	private void Page_Load(object sender, RoutedEventArgs e)
	{
		OrdersDataGrid.SetupWithColumns<Order>(Filter);
		FoodsInOrderDataGrid.SetupWithColumns<FoodInOrder>(Filter);
		DishesInOrderDataGrid.SetupWithColumns<DishInOrder>(Filter);
	}

	private bool Filter(Order order)             => true;
	private bool Filter(FoodInOrder foodInOrder) => foodInOrder.Order == SelectedOrder;
	private bool Filter(DishInOrder dishInOrder) => dishInOrder.Order == SelectedOrder;

	private void AddButton_Click(object sender, RoutedEventArgs e)
	{
		var newOrder = new Order
		{
			Manager = (Manager)Session.ActiveUser,
		};
		DbWorker.Context.Orders.Add(newOrder);
		EditOrder(newOrder);
	}

	private void EditButton_Click(object sender, RoutedEventArgs e)
	{
		if (OrdersDataGrid.EnsureSelected("заказ", out Order order))
		{
			EditOrder(order);
		}
	}

	private void AssignButton_Click(object sender, RoutedEventArgs e) { }

	private void RemoveButton_Click(object sender, RoutedEventArgs e) { }

	private void EditOrder(Order order) => Open(new EditOrderFirstPage(order));
	private void Open(Page page)        => NavigationService!.Navigate(page);
}