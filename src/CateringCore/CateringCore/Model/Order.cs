using System;
using System.Collections.Generic;
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

	public decimal Cost => FoodsInThisOrder.Sum((fio) => fio.Cost) + DishesInThisOrder.Sum((dio) => dio.Cost);

	private IQueryable<FoodInOrder> FoodsInThisOrder  => Context.FoodsInOrders.Where((fio) => fio.Order == this);
	private IQueryable<DishInOrder> DishesInThisOrder => Context.DishesInOrders.Where((dio) => dio.Order == this);

	public override string ToString() => $"заказ номер {Id} клиента {Fullname}";
}