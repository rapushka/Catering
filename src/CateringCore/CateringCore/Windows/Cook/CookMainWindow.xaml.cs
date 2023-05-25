namespace CateringCore.Windows.Cook;

public partial class CookMainWindow
{
	private Model.Cook _cook;

	public CookMainWindow(Model.Cook cook)
	{
		_cook = cook;
		InitializeComponent();
	}
}