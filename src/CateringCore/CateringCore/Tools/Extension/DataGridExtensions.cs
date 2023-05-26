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

	public static void Setup<T>(this DataGrid @this, Func<T, bool> accepted)
		where T : class
	{
		var viewSource = new CollectionViewSource
		{
			Source = DbWorker.Context.GetTable<T>().Observe(),
		};

		viewSource.Filter += (_, e) =>  Filter(e, accepted);
		@this.ItemsSource = viewSource.View;
	}

	private static void Filter<T>(FilterEventArgs e, Func<T, bool> accepted) 
		=> e.Accepted = accepted((T)e.Item);
}