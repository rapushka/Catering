using System.Windows;
using System.Windows.Controls;
using Catering.DbWorking;
using CateringCore.Model;

namespace CateringCore.Windows.Pages.Orders;

public partial class EditOrderFirstPage
{
	private Order _order;

	public EditOrderFirstPage(Order order)
	{
		_order = order;
		InitializeComponent();
	}

	private void NextButton_Click(object sender, RoutedEventArgs e)
	{
		DbWorker.SaveAll();
		// TODO: open next page
	}

	private void CancelButton_OnClick(object sender, RoutedEventArgs e)
	{
		DbWorker.ResetAll();
		NavigationService!.GoBack();
	}
}