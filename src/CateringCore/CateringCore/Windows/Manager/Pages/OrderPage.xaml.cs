using System.Windows;
using CateringCore.Model;
using OrganizerCore.Tools.Extensions;

namespace CateringCore.Windows.Pages;

public partial class OrdersListPage
{
	public OrdersListPage() => InitializeComponent();

#pragma warning disable CA1822 - fuck you
	private Order? SelectedOrder => OrdersDataGrid.SelectedItem as Order;
#pragma warning restore CA1822

	private void Page_Load(object sender, RoutedEventArgs e)
	{
		OrdersDataGrid.Setup<Order>(Filter);
		FoodsInOrderDataGrid.Setup<FoodInOrder>(Filter);
		DishesInOrderDataGrid.Setup<DishInOrder>(Filter);
	}

	private bool Filter(Order order)             => true;
	private bool Filter(FoodInOrder foodInOrder) => foodInOrder.Order == SelectedOrder;
	private bool Filter(DishInOrder dishInOrder) => dishInOrder.Order == SelectedOrder;

	private void AddButton_Click(object sender, RoutedEventArgs e) { }

	private void EditButton_Click(object sender, RoutedEventArgs e) { }

	private void AssignButton_Click(object sender, RoutedEventArgs e) { }

	private void RemoveButton_Click(object sender, RoutedEventArgs e) { }
}