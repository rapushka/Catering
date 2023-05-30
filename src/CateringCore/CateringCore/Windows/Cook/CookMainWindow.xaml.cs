using System.Windows;
using System.Windows.Controls;
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

	private bool Filter(Order order)
		=> order.State == Order.StateName.Processed
		   && SearchOrderIdTextBox.NumberEqualsTo(order.Id);

	private bool Filter(FoodInOrder foodInOrder)
		=> foodInOrder.Order == SelectedOrder
		   && foodInOrder.State == FoodInOrder.StateName.NotReady;

	private void UpdateFilters(object sender, TextChangedEventArgs e) => UpdateView();

	private void OnOrderReselected(object sender, SelectedCellsChangedEventArgs e)
	{
		FoodsInOrderDataGrid.Setup<FoodInOrder>(Filter);
	}

	private void MarkAsCooked(object sender, RoutedEventArgs e)
	{
		if (FoodsInOrderDataGrid.EnsureSelected<FoodInOrder>("блюдо в заказе", out var foodInOrder))
		{
			foodInOrder.State = FoodInOrder.StateName.Ready;
			UpdateView();
		}
	}

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
}