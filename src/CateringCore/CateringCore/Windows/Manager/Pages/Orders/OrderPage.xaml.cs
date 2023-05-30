using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Catering.DbWorking;
using CateringCore.Model;
using CateringCore.Windows.Pages.Orders;
using OrganizerCore.Tools;
using OrganizerCore.Tools.Extensions;
using Microsoft.Office.Interop.Word;
using Word = Microsoft.Office.Interop.Word;
using Page = System.Windows.Controls.Page;

namespace CateringCore.Windows.Pages;

public partial class OrdersListPage
{
	private const string OfficeExceptionMessage = "Ошибка при создании квитанции, "
	                                              + "убедитесь, что у вас установлена официальная версия "
	                                              + "Microsoft Office 2016";

	public OrdersListPage() => InitializeComponent();

#pragma warning disable CA1822
	private Order? SelectedOrder => OrdersDataGrid.SelectedItem as Order;
#pragma warning restore CA1822

	private void Page_Load(object sender, RoutedEventArgs e) => UpdateView();

	private void UpdateView()
	{
		OrdersDataGrid.SetupWithColumns<Order>(Filter);
		FoodsInOrderDataGrid.SetupWithColumns<FoodInOrder>(Filter);
		DishesInOrderDataGrid.SetupWithColumns<DishInOrder>(Filter);
	}

	private bool Filter(Order order) => SearchOrderIdTextBox.NumberEqualsTo(order.Id)
	                                    && order.Fullname.Contains(SearchFullNameTextBox.Text);

	private bool Filter(FoodInOrder foodInOrder) => foodInOrder.Order == SelectedOrder;
	private bool Filter(DishInOrder dishInOrder) => dishInOrder.Order == SelectedOrder;

	private void AddButton_Click(object sender, RoutedEventArgs e)
	{
		var newOrder = new Order
		{
			OrderDate = DateTime.Now,
			State = Order.StateName.All.First(),
			Manager = DbWorker.ActiveManager,
		};
		DbWorker.Context.Orders.Add(newOrder);
		EditOrder(newOrder);
	}

	private void EditButton_Click(object sender, RoutedEventArgs e)
	{
		if (EnsureSelectedOrder(out var order))
		{
			order.OrderDate = DateTime.Now;
			EditOrder(order);
		}
	}

	private void AssignButton_Click(object sender, RoutedEventArgs e)
	{
		if (EnsureSelectedOrder(out var order))
		{
			NavigationService!.Navigate(new AppointToOrderPage(order));
		}
	}

	private void RemoveButton_Click(object sender, RoutedEventArgs e)
	{
		if (EnsureSelectedOrder(out var order)
		    && MessageBoxUtils.ConfirmDeletion(order))
		{
			DbWorker.Context.Orders.Remove(order);
			DbWorker.SaveAll();
			UpdateView();
		}
	}

	private void EditOrder(Order order) => Open(new EditOrderFirstPage(order));

	private void Open(Page page) => NavigationService!.Navigate(page);

	private bool EnsureSelectedOrder(out Order order) => OrdersDataGrid.EnsureSelected("заказ", out order);

	private void UpdateView(object sender, SelectedCellsChangedEventArgs e)
	{
		FoodsInOrderDataGrid.SetupWithColumns<FoodInOrder>(Filter);
		DishesInOrderDataGrid.SetupWithColumns<DishInOrder>(Filter);
	}

	private void ReceiptButton_OnClick(object sender, RoutedEventArgs e)
	{
		try
		{
			CreateReport();
		}
		catch (Exception)
		{
			MessageBoxUtils.ShowError(OfficeExceptionMessage);
		}
	}

	private void CreateReport()
	{
		if (EnsureSelectedOrder(out var order) == false)
		{
			return;
		}

		var wordApp = new Word.Application
		{
			Visible = true,
		};

		var templatePath = @"./ReportTemplate.docx"; // TODO: PATH
		var doc = wordApp.Documents.Add(templatePath);

		var orderDate = DateTime.Today.ToShortDateString();
		var customerName = order.Fullname;
		var customerAddress = order.Address;
		var customerPhoneNumber = order.PhoneNumber;
		var advancePayment = order.AdvanceAmount.ToString("C");
		var totalCost = order.Cost;
		var managerName = order.Manager.Fullname;
		var courierName = order.Courier?.Fullname ?? "Нет информации";

		doc.Content.Find.Execute("<дата>", Replace: WdReplace.wdReplaceAll, ReplaceWith: orderDate);
		doc.Content.Find.Execute("<фио>", Replace: WdReplace.wdReplaceAll, ReplaceWith: customerName);
		doc.Content.Find.Execute("<адрес>", Replace: WdReplace.wdReplaceAll, ReplaceWith: customerAddress);
		doc.Content.Find.Execute("<номер>", Replace: WdReplace.wdReplaceAll, ReplaceWith: customerPhoneNumber);
		doc.Content.Find.Execute("<аванс>", Replace: WdReplace.wdReplaceAll, ReplaceWith: advancePayment);
		doc.Content.Find.Execute("<стоимость>", Replace: WdReplace.wdReplaceAll, ReplaceWith: totalCost);
		doc.Content.Find.Execute("<менеджер>", Replace: WdReplace.wdReplaceAll, ReplaceWith: managerName);
		doc.Content.Find.Execute("<курьер>", Replace: WdReplace.wdReplaceAll, ReplaceWith: courierName);

		var foodsTable = doc.Tables[1]; // Assumes that the first table in the document is the table of dishes.
		foreach (var food in CollectFoodsInOrder(order))
		{
			var newRow = foodsTable.Rows.Add();
			newRow.Cells[1].Range.Text = food.Food.Title;
			newRow.Cells[2].Range.Text = food.Amount.ToString();
			newRow.Cells[3].Range.Text = food.Cost.ToString("C");
		}

		var dishesTable = doc.Tables[2]; // Assumes that the second table in the document is the table of utensils.
		foreach (var dishInOrder in CollectDishesInOrder(order))
		{
			var newRow = dishesTable.Rows.Add();
			newRow.Cells[1].Range.Text = dishInOrder.Dish.Title;
			newRow.Cells[2].Range.Text = dishInOrder.Quantity.ToString();
			newRow.Cells[3].Range.Text = dishInOrder.Cost.ToString("C");
		}

		// Save the document.
		var savePath = @"./Report.docx";
		doc.SaveAs2(savePath);

		// Close the document and release the resources.
		doc.Close();
		wordApp.Quit();
		System.Runtime.InteropServices.Marshal.ReleaseComObject(wordApp);
	}

	private static IEnumerable<DishInOrder> CollectDishesInOrder(Order order)
		=> DbWorker.Context.DishesInOrders
		           .AsEnumerable()
		           .Where((dio) => dio.Order == order);

	private static IEnumerable<FoodInOrder> CollectFoodsInOrder(Order order)
		=> DbWorker.Context.FoodsInOrders
		           .AsEnumerable()
		           .Where((fio) => fio.Order == order);

	private decimal CalculateTotalCost(Order order)
	{
		throw new NotImplementedException();
	}
}