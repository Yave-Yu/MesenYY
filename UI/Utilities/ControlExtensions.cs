using Avalonia.Controls;
using Avalonia.VisualTree;

namespace Mesen.Utilities
{
	static class ControlExtensions
	{
		public static bool IsParentWindowFocused(this Control ctrl)
		{
			return ctrl.GetWindow()?.IsKeyboardFocusWithin == true;
		}

		public static Window? GetWindow(this Control ctrl)
		{
			if(ctrl.GetPresentationSource()?.RootVisual?.Parent is Window wnd) {
				return wnd;
			}
			return null;
		}
	}
}
