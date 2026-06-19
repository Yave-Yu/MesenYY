using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Mesen.Utilities;
using System.Collections.Generic;

namespace Mesen.Windows
{
	public class CommandLineHelpWindow : MesenWindow
	{
		public List<CommandLineTabEntry> HelpTabs { get; } = new();

		public CommandLineHelpWindow()
		{
			Dictionary<string, string> switchesPerCategory = CommandLineHelper.GetAvailableSwitches();
			foreach(var kvp in switchesPerCategory) {
				HelpTabs.Add(new() { Name = kvp.Key, Content = kvp.Value });
			}

			InitializeComponent();
		}

		private void InitializeComponent()
		{
			AvaloniaXamlLoader.Load(this);
		}

		private void btnOk_OnClick(object? sender, RoutedEventArgs e)
		{
			Close();
		}
	}

	public class CommandLineTabEntry
	{
		public string Name { get; set; } = "";
		public string Content { get; set; } = "";
	}
}