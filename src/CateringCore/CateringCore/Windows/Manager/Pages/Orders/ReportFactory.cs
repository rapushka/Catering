using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Catering.DbWorking;
using CateringCore.Model;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Paragraph = DocumentFormat.OpenXml.Wordprocessing.Paragraph;
using Table = DocumentFormat.OpenXml.Wordprocessing.Table;

namespace CateringCore.Windows.Pages;

public class ReportFactory
{
	public const string OfficeExceptionMessage = "Ошибка при создании квитанции, "
	                                             + "убедитесь, что у вас установлена официальная версия "
	                                             + "Microsoft Office 2016";

	public static void CreateReceipt(Order order)
	{
		const string templatePath = @"./ReportTemplate.docx";
		const string savePath = @"./Report.docx";

		using var doc = WordprocessingDocument.CreateFromTemplate(templatePath);
		// Get the main document part
		var mainPart = doc.MainDocumentPart;

		// Replace placeholders in the main document
		foreach (var paragraph in mainPart!.Document.Body!.Descendants<Paragraph>())
		{
			foreach (var text in paragraph.Descendants<Text>())
			{
				ReplacePlaceholder(text, order);
			}
		}

		// Replace placeholders in the header
		foreach (var headerPart in mainPart.HeaderParts)
		{
			foreach (var paragraph in headerPart.Header.Descendants<Paragraph>())
			{
				foreach (var text in paragraph.Descendants<Text>())
				{
					ReplacePlaceholder(text, order);
				}
			}
		}

		// Replace placeholders in the footer
		foreach (var footerPart in mainPart.FooterParts)
		{
			foreach (var paragraph in footerPart.Footer.Descendants<Paragraph>())
			{
				foreach (var text in paragraph.Descendants<Text>())
				{
					ReplacePlaceholder(text, order);
				}
			}
		}

		// Get the first table (foods table) and fill it with data
		var foodsTable = mainPart.Document.Body.Descendants<Table>().FirstOrDefault();
		if (foodsTable != null)
		{
			foreach (var food in CollectFoodsInOrder(order))
			{
				var newRow = new TableRow
				(
					new TableCell(new Paragraph(new Run(new Text(food.Food.Title)))),
					new TableCell(new Paragraph(new Run(new Text(food.Amount.ToString())))),
					new TableCell(new Paragraph(new Run(new Text(food.Cost.ToString("C")))))
				);
				foodsTable.Append(newRow);
			}
		}

		// Get the second table (dishes table) and fill it with data
		var dishesTable = mainPart.Document.Body.Descendants<Table>().Skip(1).FirstOrDefault();
		if (dishesTable != null)
		{
			foreach (var dishInOrder in CollectDishesInOrder(order))
			{
				var newRow = new TableRow
				(
					new TableCell(new Paragraph(new Run(new Text(dishInOrder.Dish.Title)))),
					new TableCell(new Paragraph(new Run(new Text(dishInOrder.Quantity.ToString())))),
					new TableCell(new Paragraph(new Run(new Text(dishInOrder.Cost.ToString("C")))))
				);
				dishesTable.Append(newRow);
			}
		}

		// Save the document to disk
		mainPart.Document.Save();
		doc.SaveAs(savePath);

		// Close the document and release resources
		doc.Close();
	}

	private static void ReplacePlaceholder(OpenXmlLeafTextElement text, Order order)
	{
		var placeholders = new[]
		{
			"<дата>", "<фио>", "<адрес>", "<номер>", "<аванс>", "<стоимость>", "<менеджер>", "<курьер>",
		};
		var replaceText = new[]
		{
			DateTime.Today.ToShortDateString(),
			order.Fullname,
			order.Address,
			order.PhoneNumber,
			order.AdvanceAmount.ToString("C"),
			order.Cost.ToString(CultureInfo.InvariantCulture),
			order.Manager.Fullname,
			order.Courier?.Fullname ?? "Нет информации",
		};

		for (var i = 0; i < placeholders.Length; i++)
		{
			if (text.Text.Contains(placeholders[i]))
			{
				text.Text = text.Text.Replace(placeholders[i], replaceText[i]);
			}
		}
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