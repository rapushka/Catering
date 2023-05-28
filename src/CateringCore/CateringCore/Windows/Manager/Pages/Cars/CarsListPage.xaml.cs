using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using CateringCore.Model;
using CateringCore.Tools.Extension;
using OrganizerCore.Tools.Extensions;
using OrganizerCore.Windows.Pages.StudentsTab;

namespace CateringCore.Windows.Pages.Cars;

public partial class CarsListPage
{
	public CarsListPage() => InitializeComponent();

	protected override DataGrid DataGrid => CarsDataGrid;

	protected override string NameOfItemType => "машину";

	protected override IEnumerable<UIElement> EditItemElements => ApplyButton.AsArray();

	protected override void Page_OnLoaded(object? sender = null, RoutedEventArgs? e = null)
	{
		base.Page_OnLoaded(sender, e);

		SearchTypeComboBox.SetupSearch(Car.TypeName.All);
		EditTypeComboBox.SetupEdit(Car.TypeName.All);
	}

	protected override bool Filter(Car item) 
		=> item.Number.Contains(SearchNumberTextBox.Text)
		&& item.Mark.Contains(SearchMarkTextBox.Text)
		&& item.Type == SearchTypeComboBox.GetSelectedText();

#region Repeating fields 4 (5) times

	protected override Car ReadItemFromControls()
	{
		throw new NotImplementedException();
	}

	protected override void WriteItemToControls(Car? item)
	{
		throw new NotImplementedException();
	}

	protected override void SetupColumns()
	{
		DataGrid
			.ClearColumns()
			.AddTextColumn("Марка", nameof(Car.Mark))
			.AddTextColumn("Номер", nameof(Car.Number))
			.AddTextColumn("Тип", nameof(Car.Type))
			;
		throw new NotImplementedException();
	}

	protected override void UpdateItem(ref Car selected, Car newItem)
	{
		throw new NotImplementedException();
	}

#endregion
}