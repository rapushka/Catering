using System.Windows;
using System.Windows.Controls;

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

	private void UpdateFilters(object sender, TextChangedEventArgs e) { }

	private void UpdateFilters(object sender, SelectionChangedEventArgs e) { }
}