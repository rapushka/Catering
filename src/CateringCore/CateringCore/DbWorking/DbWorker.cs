namespace Catering.DbWorking;

public static class DbWorker
{
	public static ApplicationContext Context => Connection.CurrentContext;

	private static DataBaseConnection Connection => DataBaseConnection.Instance;

	public static void Open() => Connection.OpenDataBase();

	public static void SaveAll() => Context.SaveChanges();

	public static void ResetAll() => Connection.ResetAll();
}