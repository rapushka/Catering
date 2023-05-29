using System;
using System.Globalization;
using System.Windows;
using Catering.DbWorking;
using CateringCore.Model;
using OrganizerCore.Tools;

namespace CateringCore.Windows.Pages.Orders;

public partial class EditOrderFirstPage
{
	private readonly Order _order;

	public EditOrderFirstPage(Order order)
	{
		_order = order;
		InitializeComponent();
	}

	private void Page_Load(object sender, RoutedEventArgs e) => Load();

	private void NextButton_Click(object sender, RoutedEventArgs e)
	{
		try
		{
			Save();
			DbWorker.SaveAll();
			NavigationService!.GoBack();
			NavigationService!.Navigate(new EditOrderSecondPage(_order));
		}
		catch (Exception ex)
		{
			var errorText = ex.InnerException is not null
				? ex.InnerException?.Message
				: ex.Message;

			MessageBoxUtils.ShowError($"Ошибка при сохранении изменений\nТекст ошибки: {errorText}");
		}
	}

	private void CancelButton_OnClick(object sender, RoutedEventArgs e)
	{
		DbWorker.ResetAll();
		NavigationService!.GoBack();
	}

	private void Load()
	{
		FullNameTextBox.Text = _order.Fullname;
		PhoneNumberTextBox.Text = _order.PhoneNumber;
		AddressTextBox.Text = _order.Address;
		DateTimePicker.Value = _order.FulfillmentDate;
		EmailTextBox.Text = _order.Email;
		NumberOfPeopleTextBox.Text = _order.NumberOfPeople.ToString();
		AdvanceAmountTextBox.Text = _order.AdvanceAmount.ToString(CultureInfo.InvariantCulture);
	}

	private void Save()
	{
		_order.Fullname = FullNameTextBox.Text;
		_order.PhoneNumber = PhoneNumberTextBox.Text;
		_order.Address = AddressTextBox.Text;
		_order.FulfillmentDate = DateTimePicker.Value ?? DateTime.Now;
		_order.Email = EmailTextBox.Text;
		_order.NumberOfPeople = int.Parse(NumberOfPeopleTextBox.Text);
		_order.AdvanceAmount = decimal.Parse(AdvanceAmountTextBox.Text);
	}
}