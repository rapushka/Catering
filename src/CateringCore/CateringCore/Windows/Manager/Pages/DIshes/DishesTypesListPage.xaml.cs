using System.Windows;
using System.Windows.Controls;
using Catering.DbWorking;
using CateringCore.Model;
using OrganizerCore.DbWorking;
using OrganizerCore.Tools;
using OrganizerCore.Tools.Extensions;

namespace CateringCore.Windows.Pages;

public partial class DishesTypesListPage
{
	public DishesTypesListPage() => InitializeComponent();

	private DishType? Item
	{
		get => new() { Title = EditTitleTextBox.Text };
		set
		{
			EditTitleTextBox.Text = value?.Title ?? string.Empty;
			EditTitleTextBox.IsEnabled = value is not null;
		}
	}

	private void DishesTypesListPage_OnLoaded(object sender, RoutedEventArgs e)
	{
		UpdateTableView();
		SetupDishesTypes();
	}

	private void UpdateTableView() => DishesTypesDataGrid.Setup<DishType>(Filter);

	private void SetupDishesTypes()
	{
		DishesTypesDataGrid
			.ClearColumns()
			.AddTextColumn("Наименование", nameof(DishType.Title))
			;
	}

	private bool Filter(DishType dishType) => dishType.Title.Contains(SearchTitleTextBox.Text);

	private void SearchTitleTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
		=> UpdateTableView();

	private void DishesTypesDataGrid_OnSelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
	{
		if (DishesTypesDataGrid.SelectedItem is DishType dishType)
		{
			Item = dishType;
		}
	}

	private void ItemAddButton_OnClick(object sender, RoutedEventArgs e)
	{
		DbWorker.Context.DishTypes.Add(Item!);
		DbWorker.SaveAll();
		ResetItem();
	}

	private void ItemApplyButton_OnClick(object sender, RoutedEventArgs e)
	{
		if (EnsureSelected(out var dishType))
		{
			var item = Item!;
			dishType.Title = item.Title;
			DbWorker.Context.Update(dishType);
			DbWorker.SaveAll();
			UpdateTableView();
		}
	}

	private bool EnsureSelected(out DishType dishType)
		=> DishesTypesDataGrid.EnsureSelected("тип посуды", out dishType);

	private void ItemResetButton_OnClick(object sender, RoutedEventArgs e) => ResetItem();

	private void ResetItem() => Item = null;

#region CRUD

	private void AddButton_OnClick(object sender, RoutedEventArgs e) { }

	private void EditButton_OnClick(object sender, RoutedEventArgs e) { }

	private void RemoveButton_OnClick(object sender, RoutedEventArgs e)
	{
		if (EnsureSelected(out var dishType)
		    && MessageBoxUtils.ConfirmDeletion(dishType))
		{
			DbWorker.Context.DishTypes.Observe().Remove(dishType);
			DbWorker.SaveAll();
		}
	}

#endregion
}