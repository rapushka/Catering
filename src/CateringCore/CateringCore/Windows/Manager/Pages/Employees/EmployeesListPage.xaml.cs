using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Catering.DbWorking;
using CateringCore.Model;
using CateringCore.Tools.Extension;
using OrganizerCore.Tools.Extensions;
using OrganizerCore.Windows.Pages.StudentsTab;
using static CateringCore.Model.User;

namespace CateringCore.Windows.Pages.Employees;

public partial class EmployeesListPage
{
	private const string UnableToChangePositionMessage = "Чтобы перевести сотрудника на другую должность "
	                                                     + "— удалите его и добавьте заново";
	public EmployeesListPage() => InitializeComponent();

	protected override DataGrid DataGrid => EmployeesDataGrid;

	protected override string NameOfItemType => "сотрудника";

	protected override IEnumerable<UIElement> EditItemElements => ApplyButton.AsArray();

	protected override void Page_OnLoaded(object? sender = null, RoutedEventArgs? e = null)
	{
		base.Page_OnLoaded(sender, e);

		SearchPositionComboBox.SetupSearch(PositionName.All);
		EditPositionComboBox.SetupEdit(PositionName.All);
	}

	protected override void UpdateTableView() => DataGrid.Setup<User>(Filter, DbWorker.Users);

	protected override bool Filter(User item) => true;

#region Repeating fields 4 (5) times

	protected override User ReadItemFromControls()
	{
		User user = EditPositionComboBox.SelectedItem switch
		{
			PositionName.Manager => new Manager(),
			PositionName.Courier => new Model.Courier(),
			PositionName.Cook    => new Model.Cook(),
			_                    => throw new Exception("Выбрана неизвестная должность"),
		};
		return SetupUser(user);
	}

	private User SetupUser(User user)
	{
		user.FirstName = EditFirstNameTextBox.Text;
		user.LastName = EditLastNameTextBox.Text;
		user.MiddleName = EditMiddleNameTextBox.Text;
		user.Login = EditLoginTextBox.Text;
		user.Password = EditPasswordTextBox.Text;
		user.PhoneNumber = EditPhoneNumberTextBox.Text;
		return user;
	}

	protected override void WriteItemToControls(User? item)
	{
		EditFirstNameTextBox.Text = item?.FirstName;
		EditLastNameTextBox.Text = item?.LastName;
		EditMiddleNameTextBox.Text = item?.MiddleName;
		EditLoginTextBox.Text = item?.Login;
		EditPasswordTextBox.Text = item?.Password;
		EditPhoneNumberTextBox.Text = item?.PhoneNumber;
		EditPositionComboBox.SelectedItem = item?.Position;
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
		if (selected.Position != newItem.Position)
		{
			throw new InvalidOperationException(UnableToChangePositionMessage);
		}

		selected.FirstName = newItem.FirstName;
		selected.LastName = newItem.LastName;
		selected.MiddleName = newItem.MiddleName;
		selected.Login = newItem.Login;
		selected.Password = newItem.Password;
		selected.PhoneNumber = newItem.PhoneNumber;
	}

#endregion
}