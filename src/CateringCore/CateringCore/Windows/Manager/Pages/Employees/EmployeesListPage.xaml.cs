using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using CateringCore.Model;
using CateringCore.Tools.Extension;
using OrganizerCore.Tools.Extensions;

namespace CateringCore.Windows.Pages.Employees;

public partial class EmployeesListPage
{
	public EmployeesListPage() => InitializeComponent();

	protected override DataGrid DataGrid => EmployeesDataGrid;

	protected override string NameOfItemType => "сотрудника";

	protected override IEnumerable<UIElement> EditItemElements => ApplyButton.AsArray();

	protected override void Page_OnLoaded(object? sender = null, RoutedEventArgs? e = null)
	{
		base.Page_OnLoaded(sender, e);

		// TODO: init comboboxes
	}

	protected override bool Filter(User item) => true;

#region Repeating fields 4 (5) times

	protected override User ReadItemFromControls()
		=> new()
		{
			FirstName = EditFirstNameTextBox.Text,
			LastName = EditLastNameTextBox.Text,
			MiddleName = EditMiddleNameTextBox.Text,
			Login = EditLoginTextBox.Text,
			Password = EditPasswordTextBox.Text,
			PhoneNumber = EditPhoneNumberTextBox.Text,
		};

	protected override void WriteItemToControls(User? item)
	{
		EditFirstNameTextBox.Text = item?.FirstName;
		EditLastNameTextBox.Text = item?.LastName;
		EditMiddleNameTextBox.Text = item?.MiddleName;
		EditLoginTextBox.Text = item?.Login;
		EditPasswordTextBox.Text = item?.Password;
		EditPhoneNumberTextBox.Text = item?.PhoneNumber;
	}

	protected override void SetupColumns()
	{
		DataGrid
			.ClearColumns()
			.AddTextColumn("Имя", nameof(User.FirstName))
			.AddTextColumn("Фамилия", nameof(User.LastName))
			.AddTextColumn("Отчество", nameof(User.MiddleName))
			.AddTextColumn("Номер телефона", nameof(User.PhoneNumber))
			.AddTextColumn("Логин", nameof(User.Login))
			.AddTextColumn("Пароль", nameof(User.Password))
			.AddTextColumn("Должность", nameof(User.Position))
			;
	}

	protected override void UpdateItem(ref User selected, User newItem)
	{
		selected.FirstName = newItem.FirstName;
		selected.LastName = newItem.LastName;
		selected.MiddleName = newItem.MiddleName;
		selected.Login = newItem.Login;
		selected.Password = newItem.Password;
		selected.PhoneNumber = newItem.PhoneNumber;
	}

#endregion
}