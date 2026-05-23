using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Mesen.Views;

public class WsPcV2ControllerView : UserControl
{
	public WsPcV2ControllerView()
	{
		InitializeComponent();
	}

	private void InitializeComponent()
	{
		AvaloniaXamlLoader.Load(this);
	}
}