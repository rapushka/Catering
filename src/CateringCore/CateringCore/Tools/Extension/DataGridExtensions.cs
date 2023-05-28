using System;
using System.Collections;
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
		=> @this.Setup(accepted, DbWorker.Context.GetTable<T>().Observe());

	public static void Setup<T>(this DataGrid @this, Func<T, bool> accepted, IEnumerable collection)
		where T : class
	{
		var viewSource = new CollectionViewSource { Source = collection, };

		viewSource.Filter += (_, e) => Filter(e, accepted);
		@this.ItemsSource = viewSource.View;
	}

	private static void Filter<T>(FilterEventArgs e, Func<T, bool> accepted)
		=> e.Accepted = accepted((T)e.Item);

	public static bool EnsureSelected<T>(this DataGrid @this, string itemName, out T item)
		where T : class
	{
#pragma warning disable CS8601
		item = @this.SelectedItem as T;
#pragma warning restore CS8601
		var isSelected = item is not null;

		if (isSelected == false)
		{
			MessageBoxUtils.AtFirstSelect(itemName);
		}

		return isSelected;
	}
}