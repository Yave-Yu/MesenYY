using Avalonia.Controls;
using Avalonia.VisualTree;

namespace Mesen.Utilities
{
	static class ControlExtensions
	{
		public static bool IsParentWindowFocused(this Control ctrl)
		{
			return (ctrl.GetVisualRoot() as WindowBase)?.IsKeyboardFocusWithin == true;
		}
	}
}
