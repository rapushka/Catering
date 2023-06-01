using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Order = CateringCore.Model.Order;
using Paragraph = DocumentFormat.OpenXml.Wordprocessing.Paragraph;

namespace CateringCore.Windows.Pages;

public class ReportFactory
{
	public static void CreateReceipt(Order order)
	{
		var fileName = $"Receipt_Order_{order.Id}.docx";

		using var document = WordprocessingDocument.Create(fileName, WordprocessingDocumentType.Document);
		var mainPart = document.AddMainDocumentPart();
		mainPart.Document = new Document();
		var body = mainPart.Document.AppendChild(new Body());

		CreateTitle(body);

		// Add order details
		body.AppendChild(CreateOrderDetailParagraph("Номер заказа", order.Id.ToString()));
		body.AppendChild(CreateOrderDetailParagraph("ФИО заказчика", order.Fullname));
		body.AppendChild(CreateOrderDetailParagraph("Адрес", order.Address));
		body.AppendChild(CreateOrderDetailParagraph("Номер телефона", order.PhoneNumber));
		body.AppendChild(CreateOrderDetailParagraph("Email", order.Email));
		body.AppendChild(CreateOrderDetailParagraph("Количество человек", order.NumberOfPeople.ToString()));
		body.AppendChild(CreateOrderDetailParagraph("Внесённый аванс", order.AdvanceAmount.ToString("C")));
		body.AppendChild(CreateOrderDetailParagraph("Дата заказа", order.OrderDate.ToShortDateString()));
		body.AppendChild(CreateOrderDetailParagraph("Стоимость", order.Cost.ToString("C")));

		// Save the document
		mainPart.Document.Save();
	}

	private static void CreateTitle(OpenXmlElement body)
	{
		var titleRun = new Run();
		var titleRunProperties = new RunProperties
		{
			FontSize = new FontSize { Val = "40" },
			RunFonts = new RunFonts { Ascii = "Bookman Old Style" },
		};
		titleRun.AppendChild(titleRunProperties);
		titleRun.AppendChild(new Text("Кейтеринг-агентство"));
		titleRun.AppendChild(new Break());
		titleRun.AppendChild(new Text("«Catering Life»"));
		var titleParagraph = new Paragraph(titleRun)
		{
			ParagraphProperties = new ParagraphProperties(new Justification { Val = JustificationValues.Center }),
		};
		body.AppendChild(titleParagraph);
	}

	private static Paragraph CreateOrderDetailParagraph(string label, string value)
	{
		var labelRun = new Run(new Text($"{label}:"))
		{
			RunProperties = new RunProperties(new Bold()),
		};
		var valueRun = new Run(new Text(value));
		var paragraph = new Paragraph();
		paragraph.Append(labelRun);
		paragraph.Append(valueRun);
		return paragraph;
	}
}