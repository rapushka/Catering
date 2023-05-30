using System.Windows.Controls;

namespace CateringCore.Windows.Pages;

public static class TextBoxExtensions
{
	public static bool NumberEqualsTo(this TextBox @this, int number)
		=> string.IsNullOrEmpty(@this.Text) == false
		   && string.IsNullOrWhiteSpace(@this.Text) == false
		   && int.TryParse(@this.Text, out var parsed)
		   && number != parsed;
}