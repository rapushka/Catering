using System.Windows;
using System.Windows.Controls;
using Catering.DbWorking;
using CateringCore.Model;
using OrganizerCore.DbWorking;

namespace CateringCore.Windows.Pages.Orders;

public partial class AppointToOrderPage : Page
{
	private Order _order;

	public AppointToOrderPage(Order order)
	{
		_order = order;
		InitializeComponent();
	}

	private void Apply(object sender, RoutedEventArgs e) { }

	private void Cancel(object sender, RoutedEventArgs e) { }

	private void Page_Load(object sender, RoutedEventArgs e)
	{
		IdView.Text = _order.Id.ToString();
		FullnameView.Text = _order.Fullname;
		AddressView.Text = _order.Address;
		DateTimeView.Value = _order.OrderDate;

		SetupComboBoxes();
	}

	private void SetupComboBoxes()
	{
		CarComboBox.ItemsSource = DbWorker.Context.Cars.Observe();
		CourierComboBox.ItemsSource = DbWorker.Context.Couriers.Observe();
	}
}