﻿using System.Collections.Generic;
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

	protected void Page_OnLoaded(object? sender = null, RoutedEventArgs? e = null)
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
		DbWorker.Context.GetTable<T>().Add(Item!);
		DbWorker.SaveAll();
		ResetItem();
	}

	protected void ApplyItem(object? sender = null, RoutedEventArgs? e = null)
	{
		if (EnsureSelected(out var selected))
		{
			UpdateItem(ref selected);
			DbWorker.Context.Update(selected);
			DbWorker.SaveAll();
			UpdateTableView();
		}
	}

	protected abstract void UpdateItem(ref T selected);

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