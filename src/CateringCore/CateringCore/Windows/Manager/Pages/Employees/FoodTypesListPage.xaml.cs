using System;
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

	protected override string NameOfItemType => "вид блюда";

	protected override User ReadItemFromControls()
	{
		throw new NotImplementedException();
	}

	protected override void WriteItemToControls(User? item)
	{
		throw new NotImplementedException();
	}

	protected override IEnumerable<UIElement> EditItemElements => ApplyButton.AsArray();

	protected override void SetupColumns()
	{
		DataGrid
			.ClearColumns()
			.AddTextColumn("Наименование", nameof(FoodType.Title))
			;
	}

	protected override bool Filter(User item) => true;

	protected override void UpdateItem(ref User selected, User newItem)
		=> throw new NotImplementedException();

	private void OnSearchChange(object sender, TextChangedEventArgs e) => UpdateTableView();
}