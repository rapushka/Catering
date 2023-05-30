using System.Windows.Controls;

namespace CateringCore.Windows.Pages;

public static class TextBoxExtensions
{
	public static bool NumberEqualsTo(this TextBox @this, int number) => number.ToString().Contains(@this.Text);
}