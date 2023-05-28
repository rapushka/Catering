using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Catering.DbWorking;
using CateringCore.Model;
using CateringCore.Tools.Extension;
using OrganizerCore.Tools.Extensions;

namespace CateringCore.Windows.Pages.Cars;

public partial class CarsListPage
{
	private const string UnableToChangePositionMessage = "Чтобы перевести сотрудника на другую должность "
	                                                     + "— удалите его и добавьте заново";
	public CarsListPage() => InitializeComponent();

	protected override DataGrid DataGrid => CarsDataGrid;

	protected override string NameOfItemType => "сотрудника";

	protected override IEnumerable<UIElement> EditItemElements => ApplyButton.AsArray();

	protected override void Page_OnLoaded(object? sender = null, RoutedEventArgs? e = null)
	{
		base.Page_OnLoaded(sender, e);

		// TODO: Comboboxes
	}

	protected override bool Filter(Car item) => true;

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
			// TODO: other
			;
		throw new NotImplementedException();
	}

	protected override void UpdateItem(ref Car selected, Car newItem)
	{
		throw new NotImplementedException();
	}

#endregion
}