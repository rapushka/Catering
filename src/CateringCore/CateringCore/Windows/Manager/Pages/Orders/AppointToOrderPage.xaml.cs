using System;
using System.Windows;
using Catering.DbWorking;
using CateringCore.Model;
using OrganizerCore.DbWorking;
using OrganizerCore.Tools;

namespace CateringCore.Windows.Pages.Orders;

public partial class AppointToOrderPage
{
	private readonly Order _order;

	public AppointToOrderPage(Order order)
	{
		_order = order;
		InitializeComponent();
	}

	private void Page_Load(object sender, RoutedEventArgs e)
	{
		IdView.Text = _order.Id.ToString();
		FullnameView.Text = _order.Fullname;
		AddressView.Text = _order.Address;
		DateTimeView.Value = _order.OrderDate;

		CarComboBox.ItemsSource = DbWorker.Context.Cars.Observe();
		CourierComboBox.ItemsSource = DbWorker.Context.Couriers.Observe();
	}

	private void Apply(object sender, RoutedEventArgs e)
	{
		try
		{
			_order.Car = CarComboBox.SelectedItem as Car;
			_order.Courier = CourierComboBox.SelectedItem as Model.Courier;

			DbWorker.SaveAll();
			NavigationService!.GoBack();
		}
		catch (Exception ex)
		{
			MessageBoxUtils.ShowOnSaveException(ex);
		}
	}

	private void Cancel(object sender, RoutedEventArgs e)
	{
		DbWorker.ResetAll();
		NavigationService!.GoBack();
	}
}