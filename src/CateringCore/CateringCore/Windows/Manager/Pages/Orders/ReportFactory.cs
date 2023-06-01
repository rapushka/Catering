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
		var fileName = $"Receipt_Order_{order.Id}.docx";

		using var document = WordprocessingDocument.Create(fileName, WordprocessingDocumentType.Document);
		var mainPart = document.AddMainDocumentPart();
		mainPart.Document = new Document();
		var body = mainPart.Document.AppendChild(new Body());

		// Add a title to the document
		var titleParagraph = new Paragraph(new Run(new Text("Order Receipt")))
		{
			ParagraphProperties = new ParagraphProperties(new Justification { Val = JustificationValues.Center }),
		};
		body.AppendChild(titleParagraph);

		// Add order details
		body.AppendChild(CreateOrderDetailParagraph("Order ID:", order.Id.ToString()));
		body.AppendChild(CreateOrderDetailParagraph("Customer Name:", order.Fullname));
		body.AppendChild(CreateOrderDetailParagraph("Address:", order.Address));
		body.AppendChild(CreateOrderDetailParagraph("Phone Number:", order.PhoneNumber));
		body.AppendChild(CreateOrderDetailParagraph("Email:", order.Email));
		body.AppendChild(CreateOrderDetailParagraph("Number of People:", order.NumberOfPeople.ToString()));
		body.AppendChild(CreateOrderDetailParagraph("Advance Amount:", order.AdvanceAmount.ToString("C")));
		body.AppendChild(CreateOrderDetailParagraph("Order State:", order.State));
		body.AppendChild
			(CreateOrderDetailParagraph("Fulfillment Date:", order.FulfillmentDate.ToShortDateString()));
		body.AppendChild(CreateOrderDetailParagraph("Order Date:", order.OrderDate.ToShortDateString()));
		body.AppendChild(CreateOrderDetailParagraph("Total Cost:", order.Cost.ToString("C")));

		// Save the document
		mainPart.Document.Save();
	}

	private static Paragraph CreateOrderDetailParagraph(string label, string value)
	{
		var labelRun = new Run(new Text(label));
		var valueRun = new Run(new Text(value));
		labelRun.RunProperties = new RunProperties(new Bold());
		var paragraph = new Paragraph();
		paragraph.Append(labelRun);
		paragraph.Append(valueRun);
		return paragraph;
	}
}