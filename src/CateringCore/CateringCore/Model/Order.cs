using System;
using System.ComponentModel.DataAnnotations;

namespace CateringCore.Model;

public class Order
{
	[Key] public int      Id             { get; set; }
	public       Manager  Manager        { get; set; } = null!;
	public       Courier? Courier        { get; set; }
	public       Car?     Car            { get; set; }
	public       string   Fullname       { get; set; } = null!;
	public       string   Address        { get; set; } = null!;
	public       string   PhoneNumber    { get; set; } = null!;
	public       string   Email          { get; set; } = null!;
	public       int      NumberOfPeople { get; set; }
	public       decimal  AdvanceAmount  { get; set; }
	public       string   State          { get; set; } = null!;
	public       DateTime Date           { get; set; }
}