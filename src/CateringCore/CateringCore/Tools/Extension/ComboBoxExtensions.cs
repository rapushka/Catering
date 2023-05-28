using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using Catering.DbWorking;
using CateringCore.Model;
using CateringCore.Tools.Extension;
using OrganizerCore.DbWorking;

namespace OrganizerCore.Windows.Pages.StudentsTab;

public static class ComboBoxExtensions
{
	private const string AllEntry = "Все";

	public static string GetSelectedText(this ComboBox @this)
		=> (@this.SelectedItem as ComboBoxItem)?.Content.ToString() ?? string.Empty;

	public static void SetupSearch<T>(this ComboBox @this)
		where T : class, ITitledTable, new()
		=> @this.SetupSearch(LoadTable<T>());

	public static void SetupSearch<T>(this ComboBox @this, IEnumerable<T> collection)
		where T : class, ITitledTable, new()
	{
		@this.ItemsSource = new T { Title = AllEntry }.Concat(collection);
		@this.SelectedIndex = 0;
	}

	public static void SetupSearch(this ComboBox @this, IEnumerable<string> collection)
	{
		@this.ItemsSource = AllEntry.Concat(collection);
		@this.SelectedIndex = 0;
	}

	public static void SetupEdit<T>(this ComboBox @this)
		where T : class
		=> @this.SetupEdit(LoadTable<T>());

	public static void SetupEdit<T>(this ComboBox @this, IEnumerable<T> collection)
		=> @this.ItemsSource = collection;

	private static ObservableCollection<T> LoadTable<T>()
		where T : class
		=> DbWorker.Context.GetTable<T>().Observe();

	public static bool IsMatchSearch<T>(this ComboBox @this, T entry)
		=> @this.SelectedIndex == 0 || Equals(entry, (T)@this.SelectedItem);
}