using System.Collections.ObjectModel;
using System.Windows.Controls;
using Catering.DbWorking;
using CateringCore.Model;
using CateringCore.Tools.Extension;
using OrganizerCore.DbWorking;

namespace OrganizerCore.Windows.Pages.StudentsTab;

public static class ComboBoxExtensions
{
	public static string GetSelectedText(this ComboBox @this)
		=> (@this.SelectedItem as ComboBoxItem)?.Content.ToString() ?? string.Empty;

	public static void SetupSearch<T>(this ComboBox @this)
		where T : class, ITitledTable, new()
	{
		@this.ItemsSource = new T { Title = "Все" }.Concat(LoadTable<T>());
		@this.SelectedIndex = 0;
	}

	public static void SetupEdit<T>(this ComboBox @this)
		where T : class, ITitledTable, new()
		=> @this.ItemsSource = LoadTable<T>();

	private static ObservableCollection<T> LoadTable<T>() where T : class, ITitledTable, new()
		=> DbWorker.Context.GetTable<T>().Observe();

	public static bool IsMatchSearch<T>(this ComboBox @this, T entry)
		=> @this.SelectedIndex == 0 || Equals(entry, (T)@this.SelectedItem);
}