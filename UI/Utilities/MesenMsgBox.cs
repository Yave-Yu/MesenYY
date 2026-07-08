using Avalonia.Controls;
using Mesen.Localization;
using Mesen.Windows;
using System;
using System.Threading.Tasks;

namespace Mesen.Utilities
{
	public class MesenMsgBox
	{
		public static Task ShowException(Exception ex)
		{
			return MesenMsgBox.Show(null, "UnexpectedError", MessageBoxButtons.OK, MessageBoxIcon.Error, ex.Message + Environment.NewLine + ex.StackTrace);
		}

		public static Task<DialogResult> Show(Window? parent, string text, MessageBoxButtons buttons, MessageBoxIcon icon, params string[] args)
		{
			Window? wnd = parent as Window;
			if(parent != null && wnd == null) {
				throw new Exception("Invalid parent window");
			}

			string resourceText = ResourceHelper.GetMessage(text, args);

			if(resourceText.StartsWith("[[")) {
				if(args != null && args.Length > 0) {
					return MessageBox.Show(wnd, string.Format("Critical error (" + text + ") {0}", args), "MesenYY", buttons, icon);
				} else {
					return MessageBox.Show(wnd, string.Format("Critical error (" + text + ")"), "MesenYY", buttons, icon);
				}
			} else {
				return MessageBox.Show(wnd, ResourceHelper.GetMessage(text, args), "MesenYY", buttons, icon);
			}
		}
	}
}
