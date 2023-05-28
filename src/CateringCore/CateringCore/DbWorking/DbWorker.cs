using System.Collections.Generic;
using System.Linq;
using CateringCore.Model;
using CateringCore.Tools;

namespace Catering.DbWorking;

public static class DbWorker
{
	public static ApplicationContext Context => Connection.CurrentContext;

	private static DataBaseConnection Connection => DataBaseConnection.Instance;

	public static void Open() => Connection.OpenDataBase();

	public static void SaveAll() => Context.SaveChanges();

	public static void ResetAll() => Connection.ResetAll();

#region Tooling

	public static IEnumerable<User> Users
		=> Context.Managers.AsEnumerable()
		          .Cast<User>()
		          .Concat(Context.Couriers)
		          .Concat(Context.Cooks);

	public static Manager ActiveManager => Context.Managers.Find(Session.ActiveUser.Id)!;
	public static Courier ActiveCourier => Context.Couriers.Find(Session.ActiveUser.Id)!;
	public static Cook    ActiveCook    => Context.Cooks.Find(Session.ActiveUser.Id)!;

#endregion
}