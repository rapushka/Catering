using System;
using System.Collections.Generic;
using System.Linq;
using Catering.DbWorking;
using CateringCore.Model;
using Microsoft.Office.Interop.Word;

namespace CateringCore.Windows.Pages;

public class ReportFactory
{
	public const string OfficeExceptionMessage = "Ошибка при создании квитанции, "
	                                             + "убедитесь, что у вас установлена официальная версия "
	                                             + "Microsoft Office 2016";

	public static void CreateReceipt(Order order)
	{
		var wordApp = new Application
		{
			Visible = true,
		};

		const string templatePath = @"./ReportTemplate.docx";
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
		const string savePath = @"./Report.docx";
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
}