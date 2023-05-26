using System;
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
	where T : Table, new()
{
	public abstract DataGrid DataGrid { get; }

	protected virtual T? Item
	{
		get => new();
		set
		{
			foreach (var element in EditItemElements)
			{
				element.IsEnabled = value is not null;
			}
		}
	}

	protected abstract string NameOfItemType { get; }

	protected abstract IEnumerable<UIElement> EditItemElements { get; }

	protected virtual void Page_OnLoaded(object? sender = null, RoutedEventArgs? e = null)
	{
		UpdateTableView();
		SetupColumns();
	}

	protected abstract void SetupColumns();

	protected void UpdateTableView() => DataGrid.Setup<T>(Filter);

	protected abstract bool Filter(T item);

	protected void OnItemSelected(object? sender = null, SelectedCellsChangedEventArgs? e = null)
		=> Item = DataGrid.SelectedItem as T;

	protected void AddItem(object? sender = null, RoutedEventArgs? e = null)
	{
		try
		{
			DbWorker.Context.GetTable<T>().Add(Item!);
			DbWorker.SaveAll();
			ResetItem();
		}
		catch (Exception ex)
		{
			MessageBoxUtils.ShowError($"Ошибка при добавелении записи!\n{ex.Message}");
		}
	}

	protected void ApplyItem(object? sender = null, RoutedEventArgs? e = null)
	{
		try
		{
			if (EnsureSelected(out var selected))
			{
				UpdateItem(ref selected, Item!);
				DbWorker.Context.Update(selected);
				DbWorker.SaveAll();
				UpdateTableView();
			}
		}
		catch (Exception ex)
		{
			MessageBoxUtils.ShowError($"Ошибка при изменении записи!\n{ex.Message}");
		}
	}

	protected void RemoveItem(object? sender = null, RoutedEventArgs? e = null)
	{
		try
		{
			if (EnsureSelected(out var item)
			    && MessageBoxUtils.ConfirmDeletion(item))
			{
				DbWorker.Context.GetTable<T>().Observe().Remove(item);
				DbWorker.SaveAll();
			}
		}
		catch (Exception ex)
		{
			MessageBoxUtils.ShowError($"Ошибка при удалении записи!\n{ex.Message}");
		}
	}

	protected abstract void UpdateItem(ref T selected, T newItem);

	protected virtual void ResetItem(object? sender = null, RoutedEventArgs? e = null)
	{
		Item = default;
		UpdateTableView();
	}

	protected bool EnsureSelected(out T item) => DataGrid.EnsureSelected(NameOfItemType, out item);
}