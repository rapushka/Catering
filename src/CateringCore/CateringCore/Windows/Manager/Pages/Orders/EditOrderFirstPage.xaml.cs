using System.Windows;
using System.Windows.Controls;
using CateringCore.Model;

namespace CateringCore.Windows.Pages.Orders;

public partial class EditOrderFirstPage : Page
{
	private Order _order;

	public EditOrderFirstPage(Order order)
	{
		_order = order;
		InitializeComponent();
	}

	private void NextButton_Click(object sender, RoutedEventArgs e) { }
}