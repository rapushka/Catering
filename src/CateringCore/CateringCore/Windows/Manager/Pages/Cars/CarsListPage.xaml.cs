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
		   && SearchTypeComboBox.IsMatchSearch(item.Type);

	protected override bool IsAllFieldsFilled
		=> EditMarkTextBox.IsNotEmpty()
		   && EditNumberTextBox.IsNotEmpty()
		   && EditTypeComboBox.IsNotEmpty();

#region Repeating fields 4 (5) times

	protected override Car ReadItemFromControls()
		=> new()
		{
			Mark = EditMarkTextBox.Text,
			Type = EditTypeComboBox.Text,
			Number = EditNumberTextBox.Text,
		};

	protected override void WriteItemToControls(Car? item)
	{
		EditMarkTextBox.Text = item?.Mark;
		EditTypeComboBox.SelectedItem = item?.Type;
		EditNumberTextBox.Text = item?.Number;
	}

	protected override void SetupColumns()
	{
		DataGrid
			.ClearColumns()
			.AddTextColumn("Марка", nameof(Car.Mark))
			.AddTextColumn("Номер", nameof(Car.Number))
			.AddTextColumn("Тип", nameof(Car.Type))
			;
	}

	protected override void UpdateItem(ref Car selected, Car newItem)
	{
		selected.Mark = newItem.Mark;
		selected.Type = newItem.Type;
		selected.Number = newItem.Number;
	}

#endregion
}