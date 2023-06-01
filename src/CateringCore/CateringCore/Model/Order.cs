using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using static Catering.DbWorking.DbWorker;

namespace CateringCore.Model;

public class Order : Table
{
	public Manager  Manager         { get; set; } = null!;
	public Courier? Courier         { get; set; }
	public Car?     Car             { get; set; }
	public string   Fullname        { get; set; } = null!;
	public string   Address         { get; set; } = null!;
	public string   PhoneNumber     { get; set; } = null!;
	public string   Email           { get; set; } = null!;
	public int      NumberOfPeople  { get; set; }
	public decimal  AdvanceAmount   { get; set; }
	public string   State           { get; set; } = null!;
	public DateTime FulfillmentDate { get; set; }
	public DateTime OrderDate       { get; set; }

	public decimal Cost => Foods.Sum((fio) => fio.Cost) + Dishes.Sum((dio) => dio.Cost);

	[NotMapped]
	public IEnumerable<FoodInOrder> Foods
		=> Context.FoodsInOrders.AsEnumerable().Where((fio) => fio.Order == this);
	[NotMapped]
	public IEnumerable<DishInOrder> Dishes
		=> Context.DishesInOrders.AsEnumerable().Where((dio) => dio.Order == this);

	public override string ToString() => $"заказ номер {Id} клиента {Fullname}";

	public static class StateName
	{
		public const string Processing = "В обработке";
		public const string Processed = "Обработан";
		public const string ReadyForDelivery = "Готов к доставке";
		public const string Delivered = "Доставлен";

		public static string[] All => new[] { Processing, Processed, ReadyForDelivery, Delivered };
	}
}