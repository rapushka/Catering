using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Catering.DbWorking;
using CateringCore.Model;
using OrganizerCore.DbWorking;
using OrganizerCore.Tools;
using OrganizerCore.Tools.Extensions;

namespace CateringCore.Windows.Pages.Common;

public abstract class EditableListPage<T> : Page
	where T : Table
{
	private T? _item;

	public abstract DataGrid DataGrid { get; }

	protected virtual T? Item
	{
		get => _item;
		set
		{
			_item = value;

			foreach (var element in EditItemElements)
			{
				element.IsEnabled = _item is not null;
			}
		}
	}

	protected abstract string NameOfItemType { get; }

	protected abstract IEnumerable<UIElement> EditItemElements { get; }

	protected void Page_OnLoaded(object? sender = null, RoutedEventArgs? e = null)
	{
		UpdateTableView();
		SetupTable();
	}

	protected abstract void SetupTable();

	protected void UpdateTableView() => DataGrid.Setup<T>(Filter);

	protected abstract bool Filter(T item);

	protected void OnItemSelected(object? sender = null, SelectedCellsChangedEventArgs? e = null)
		=> Item = DataGrid.SelectedItem as T;

	protected void AddItem(object? sender = null, RoutedEventArgs? e = null)
	{
		DbWorker.Context.GetTable<T>().Add(Item!);
		DbWorker.SaveAll();
		ResetItem();
	}

	protected void ApplyItem(object? sender = null, RoutedEventArgs? e = null)
	{
		if (EnsureSelected(out var item))
		{
			item = Item!;
			DbWorker.Context.Update(item);
			DbWorker.SaveAll();
			UpdateTableView();
		}
	}

	protected virtual void ResetItem(object? sender = null, RoutedEventArgs? e = null)
	{
		Item = default;
		UpdateTableView();
	}

	protected void RemoveItem(object? sender = null, RoutedEventArgs? e = null)
	{
		if (EnsureSelected(out var item)
		    && MessageBoxUtils.ConfirmDeletion(item))
		{
			DbWorker.Context.GetTable<T>().Observe().Remove(item);
			DbWorker.SaveAll();
		}
	}

	protected bool EnsureSelected(out T item) => DataGrid.EnsureSelected(NameOfItemType, out item);
}