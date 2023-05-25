using System;
using System.Linq;
using System.Windows;
using Catering.DbWorking;
using CateringCore.Model;
using CateringCore.Windows;
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

		var user = DbWorker.Users.FirstOrDefault((u) => u.Authorize(login, password));

		if (user is null)
		{
			MessageBoxUtils.ShowError("Неправильный лоґин или пароль");
			return;
		}

		var userWindow = user switch
		{
			Manager manager => new ManagerMainWindow(manager),
			Cook cook       => throw new NotImplementedException(),
			Courier courier => throw new NotImplementedException(),
			_               => throw new ArgumentException("Unknown role!"),
		};

		Hide();
		userWindow.ShowDialog();
		Close();
	}
}