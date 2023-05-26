using System;
using System.Windows.Controls;
using System.Windows.Data;
using Catering.DbWorking;
using OrganizerCore.DbWorking;

namespace OrganizerCore.Tools.Extensions;

public static class DataGridExtensions
{
	public static void FocusOn<T>(this DataGrid @this, T item)
	{
		@this.SelectedItem = item;
		@this.ScrollIntoView(item ?? throw new ArgumentNullException(nameof(item)));
		@this.BeginEdit();
	}

	public static void Setup<T>(this DataGrid @this, FilterEventHandler filter)
		where T : class
	{
		var viewSource = new CollectionViewSource
		{
			Source = DbWorker.Context.GetTable<T>().Observe(),
		};

		viewSource.Filter += filter;
		@this.ItemsSource = viewSource.View;
	}

}