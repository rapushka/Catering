namespace CateringCore.Model;

public class Manager : User
{
	public static User Construct(string login, string password)
		=> new Manager
		{
			FirstName = "Админ",
			Login = login,
			Password = password,
		};
}