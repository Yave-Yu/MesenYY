using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Markup.Xaml;
using Mesen.Config;

namespace Mesen.Controls
{
	public class OverscanInput : UserControl
	{
		public static readonly StyledProperty<OverscanConfig> OverscanProperty = AvaloniaProperty.Register<OverscanInput, OverscanConfig>(nameof(Overscan), new OverscanConfig(), defaultBindingMode: BindingMode.TwoWay);

		public OverscanConfig Overscan
		{
			get { return GetValue(OverscanProperty); }
			set { SetValue(OverscanProperty, value); }
		}

		public OverscanInput()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			AvaloniaXamlLoader.Load(this);
		}
	}
}
