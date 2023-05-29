using System.Windows;
using Catering.DbWorking;
using CateringCore.Model;

namespace CateringCore.Windows.Pages.Orders;

public partial class EditOrderSecondPage
{
	private Order _order;

	public EditOrderSecondPage(Order order)
	{
		_order = order;
		InitializeComponent();
	}

	private void SaveButton_OnClick(object sender, RoutedEventArgs e) { }

	private void CancelButton_OnClick(object sender, RoutedEventArgs e)
	{
		DbWorker.ResetAll();
		NavigationService!.Navigate(new OrdersListPage());
	}
}