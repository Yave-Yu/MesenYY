using Avalonia.Controls;

namespace Mesen.Utilities;

public static class TextBoxExtensions
{
	public static void FocusAndSelectAll(this TextBox txt)
	{
		txt.Focus();
		txt.SelectAll();
	}
}
