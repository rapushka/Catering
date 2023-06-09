﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Catering.DbWorking;
using CateringCore.Model;
using OrganizerCore.Tools;
using OrganizerCore.Tools.Extensions;

namespace CateringCore.Windows.Pages.Common;

public abstract class EditableListPage<T> : Page
	where T : Table, new()
{
	protected abstract DataGrid DataGrid { get; }

	private T? Item
	{
		get => ReadItemFromControls();
		set
		{
			WriteItemToControls(value);
			foreach (var element in EditItemElements)
			{
				element.IsEnabled = value is not null;
			}
		}
	}

	protected abstract void WriteItemToControls(T? item);
	protected abstract T    ReadItemFromControls();

	protected abstract string NameOfItemType { get; }

	protected abstract IEnumerable<UIElement> EditItemElements { get; }

	protected virtual void Page_OnLoaded(object? sender = null, RoutedEventArgs? e = null)
	{
		UpdateTableView();
		SetupColumns();
		DataGrid.SelectedItem = null;
		Item = null;
	}

	protected abstract void SetupColumns();

	protected virtual void UpdateTableView() => DataGrid.Setup<T>(Filter);

	protected abstract bool Filter(T item);

	protected void OnItemSelected(object? sender = null, SelectedCellsChangedEventArgs? e = null)
		=> Item = DataGrid.SelectedItem as T;

	protected abstract bool IsAllFieldsFilled { get; }

	protected void AddItem(object? sender = null, RoutedEventArgs? e = null)
	{
		try
		{
			if (IsAllFieldsFilled == false)
			{
				throw new Exception("Не все поля заполнены!");
			}

			DbWorker.Context.Add(Item!);
			DbWorker.SaveAll();
			ResetItem();
		}
		catch (Exception ex)
		{
			MessageBoxUtils.ShowError($"Ошибка при добавелении записи!\n{ex.Message}");
		}
		finally
		{
			UpdateTableView();
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
				DbWorker.Context.Remove(item);
				DbWorker.SaveAll();
				UpdateTableView();
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
		Item = null;
		DataGrid.SelectedItem = null;
	}

	private   bool EnsureSelected(out T item) => DataGrid.EnsureSelected(NameOfItemType, out item);
	protected void UpdateSearch(object sender, SelectionChangedEventArgs e) => UpdateTableView();
	protected void UpdateSearch(object sender, TextChangedEventArgs e) => UpdateTableView();

	protected void NavigateTo<TPage>() where TPage : Page, new() => NavigationService!.Navigate(new TPage());
}