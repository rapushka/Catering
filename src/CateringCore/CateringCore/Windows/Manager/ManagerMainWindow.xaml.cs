using System.Windows;
using CateringCore.Model;

namespace CateringCore.Windows;

public partial class ManagerMainWindow : Window
{
	private const string ManagerSuffix = ", Менеджер";

	private readonly Manager _manager;

	public ManagerMainWindow(Manager manager)
	{
		_manager = manager;
		InitializeComponent();
	}

	private void ManagerMainWindow_OnLoaded(object sender, RoutedEventArgs e)
	{
		EmployeeFullnameTextBlock.Text = _manager.Fullname + ManagerSuffix;
	}
}