using CateringCore.Model;

namespace CateringCore.Tools;

public static class Session
{
	public static User ActiveUser { get; set; } = null!;
}