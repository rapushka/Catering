using System.Collections.Generic;
using System.Windows.Controls;
using CateringCore.Model;
using CateringCore.Tools.Extension;

namespace OrganizerCore.Windows.Pages.StudentsTab;

public static class ComboBoxExtensions
{
	public static string GetSelectedText(this ComboBox @this)
		=> (@this.SelectedItem as ComboBoxItem)?.Content.ToString() ?? string.Empty;

	public static void SetupSearch<T>(this ComboBox @this, IEnumerable<T> itemSource)
		where T : ITitledTable, new()
	{
		@this.ItemsSource = new T { Title = "Все" }.Concat(itemSource);
		@this.SelectedIndex = 0;
	}
}