namespace CateringCore.Tools.Extension;

public static class GenericExtensions
{
	public static T[] AsArray<T>(this T @this) => new[] { @this };
}