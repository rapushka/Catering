namespace CateringCore.Windows.Courier;

public partial class CourierMainWindow
{
	private Model.Courier _courier;

	public CourierMainWindow(Model.Courier courier)
	{
		_courier = courier;
		InitializeComponent();
	}
}