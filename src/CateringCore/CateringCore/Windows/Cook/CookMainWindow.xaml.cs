using System.Windows;

namespace CateringCore.Windows.Cook;

public partial class CookMainWindow
{
	private const string CookSuffix = ", Повар";

	private readonly Model.Cook _cook;

	public CookMainWindow(Model.Cook cook)
	{
		_cook = cook;
		InitializeComponent();
	}

	private void CookMainWindow_OnLoaded(object sender, RoutedEventArgs e)
		=> EmployeeFullnameTextBlock.Text = _cook.Fullname + CookSuffix;
}