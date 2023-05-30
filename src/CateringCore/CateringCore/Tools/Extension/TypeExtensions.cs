using System;

namespace CateringCore.Windows.Pages;

public static class TypeExtensions
{
	public static bool Is<T>(this Type @this) => @this == typeof(T);
}