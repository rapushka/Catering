using System.Windows;
using System.Windows.Controls;
using Catering.DbWorking;
using CateringCore.Model;
using OrganizerCore.Tools.Extensions;

namespace CateringCore.Windows.Pages;

public partial class DishesTypesListPage
{
	public DishesTypesListPage() => InitializeComponent();

	private DishType? Item
	{
		get => new() { Title = EditTitleTextBox.Text };
		set => EditTitleTextBox.Text = value?.Title ?? string.Empty;
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
		if (EnsureSelected(out var dishType))
		{
			Item = dishType;
		}
	}

	private void AddItemButton_OnClick(object sender, RoutedEventArgs e)
	{
		DbWorker.Context.DishTypes.Add(Item!);
		ResetItem();
	}

	private void ApplyItemButton_OnClick(object sender, RoutedEventArgs e)
	{
		if (EnsureSelected(out var dishType))
		{
			var item = Item!;
			dishType!.Title = item.Title;
			DbWorker.Context.Update(dishType);
			DbWorker.SaveAll();
		}
	}

	private bool EnsureSelected(out DishType dishType)
		=> DishesTypesDataGrid.EnsureSelected("тип посуды", out dishType);

	private void ResetItem() => Item = null;
}