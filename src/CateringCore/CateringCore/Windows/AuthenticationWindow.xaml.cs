using System;
using System.Linq;
using System.Windows;
using Catering.DbWorking;
using CateringCore.Model;
using CateringCore.Tools;
using CateringCore.Windows;
using CateringCore.Windows.Cook;
using CateringCore.Windows.Courier;
using OrganizerCore.Tools;

namespace CateringCore;

public partial class AuthenticationWindow
{
	public AuthenticationWindow()
	{
		InitializeComponent();
		DbWorker.Open();
	}

	private void LoginButton_Click(object sender, RoutedEventArgs e)
	{
		var login = LoginTextBox.Text;
		var password = PasswordTextBox.Text;

		var user = DbWorker.LoginUsers.FirstOrDefault((u) => u.Authorize(login, password));

		if (user is null)
		{
			MessageBoxUtils.ShowError("Неправильный лоґин или пароль");
			return;
		}

		Window userWindow = user switch
		{
			Manager manager => new ManagerMainWindow(manager),
			Courier courier => new CourierMainWindow(courier),
			Cook cook       => new CookMainWindow(cook),
			_               => throw new ArgumentException("Unknown role!"),
		};

		Session.ActiveUser = user;
		Hide();
		userWindow.ShowDialog();
		Close();
	}
}