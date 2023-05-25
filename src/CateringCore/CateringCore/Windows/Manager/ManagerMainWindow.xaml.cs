﻿using System.Windows;
using System.Windows.Controls;
using CateringCore.Model;
using CateringCore.Windows.Pages;

namespace CateringCore.Windows;

public partial class ManagerMainWindow
{
	private const string ManagerSuffix = ", Менеджер";

	private readonly Manager _manager;

	public ManagerMainWindow(Manager manager)
	{
		_manager = manager;
		InitializeComponent();
	}

	private void ManagerMainWindow_OnLoaded(object sender, RoutedEventArgs e)
		=> EmployeeFullnameTextBlock.Text = _manager.Fullname + ManagerSuffix;

	private void OrderButton_OnClick(object sender, RoutedEventArgs e) => Open<OrderPage>();

	private void EmployeesButton_OnClick(object sender, RoutedEventArgs e) { }

	private void FoodButton_OnClick(object sender, RoutedEventArgs e) { }

	private void DishesButton_OnClick(object sender, RoutedEventArgs e) { }

	private void CarsButton_OnClick(object sender, RoutedEventArgs e) { }

	private void Open<T>()
		where T : Page, new()
		=> Frame.Content = new T();
}