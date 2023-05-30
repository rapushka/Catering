using System.Windows;
using System.Windows.Controls;
using CateringCore.Model;

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
}