using System.Windows;

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

	private void CourierMainWindow_OnLoaded(object sender, RoutedEventArgs e)
		=> EmployeeFullnameTextBlock.Text = _courier.Fullname + CourierSuffix;
}