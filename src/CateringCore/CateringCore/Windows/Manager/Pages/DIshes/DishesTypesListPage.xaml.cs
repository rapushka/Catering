﻿using System.Collections.Generic;
using System.Windows;
using System.Windows.Data;
using CateringCore.Model;
using OrganizerCore.Tools.Extensions;

namespace CateringCore.Windows.Pages;

public partial class DishesTypesListPage
{
	public DishesTypesListPage() => InitializeComponent();

	private void DishesTypesListPage_OnLoaded(object sender, RoutedEventArgs e)
	{
		DishesTypesDataGrid.Setup<DishType>(Filter);
		SetupDishesTypes();
	}

	private void Filter(object sender, FilterEventArgs e) { }

	private void SetupDishesTypes()
	{
		DishesTypesDataGrid.SetColumns
		(
			new Dictionary<string, string>
			{
				["Наименование"] = nameof(DishType.Title),
			}
		);
	}
}