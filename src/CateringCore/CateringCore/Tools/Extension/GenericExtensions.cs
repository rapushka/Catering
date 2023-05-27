using System.Collections.Generic;
using System.Linq;

namespace CateringCore.Tools.Extension;

public static class GenericExtensions
{
	public static T[] AsArray<T>(this T @this) => new[] { @this };

	public static IEnumerable<T> Concat<T>(this T @this, IEnumerable<T> other) => @this.AsArray().Concat(other);
}