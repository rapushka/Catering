using System.Windows;
using System.Windows.Controls;
using Catering.DbWorking;
using CateringCore.Model;
using CateringCore.Windows.Pages;
using OrganizerCore.Tools.Extensions;
using OrganizerCore.Windows.Pages.ScheduleTab;

namespace CateringCore.Windows.Courier;

public partial class CourierMainWindow
{
	private const string CourierSuffix = ", Курьер";
	private readonly Model.Courier _courier;

	public CourierMainWindow(Model.Courier courier)
	{
		_courier = courier;
		InitializeComponent();
	}

	private void Page_Load(object sender, RoutedEventArgs e)
	{
		EmployeeFullnameTextBlock.Text = _courier.Fullname + CourierSuffix;

		UpdateView();
	}

	private void UpdateView()
	{
		OrdersDataGrid.Setup<Order>(Filter);
		SetupOrderColumns();
	}

	private bool Filter(Order order)
		=> order.State == Order.StateName.ReadyForDelivery
		   && SearchOrderIdTextBox.NumberEqualsTo(order.Id)
		   && order.Fullname.Contains(SearchFullnameTextBox.Text)
		   && order.Courier == DbWorker.ActiveCourier
		   && order.FulfillmentDate.IsToday();

	private void UpdateFilters(object sender, TextChangedEventArgs e) => UpdateView();

	private void ApproveDelivery(object sender, RoutedEventArgs e)
	{
		if (OrdersDataGrid.EnsureSelected<Order>("заказ", out var order))
		{
			const string isDelivered = Order.StateName.Delivered;
			order.State = isDelivered;

			DbWorker.SaveAll();
			UpdateView();
		}
	}

	private void SetupOrderColumns()
	{
		OrdersDataGrid
			.ClearColumns()
			.AddTextColumn("Номер", nameof(Order.Id))
			.AddTextColumn("ФИО заказчика", nameof(Order.Fullname))
			.AddTextColumn("Телефона", nameof(Order.PhoneNumber))
			.AddTextColumn("Адрес", nameof(Order.Address))
			.AddTextColumn("Сумма аванса", nameof(Order.AdvanceAmount))
			.AddTextColumn("Стоимость", nameof(Order.Cost))
			.AddTextColumn("Авто", nameof(Order.Car))
			;
	}
}