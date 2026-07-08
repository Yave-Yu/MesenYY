using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Mesen.ViewModels;

namespace Mesen.Windows
{
	public class HdPackBuilderWindow : MesenWindow
	{
		private HdPackBuilderViewModel _model;

		public HdPackBuilderWindow()
		{
			_model = new HdPackBuilderViewModel();
			DataContext = _model;

			InitializeComponent();
		}

		protected override void OnClosing(WindowClosingEventArgs e)
		{
			base.OnClosing(e);
			_model.StopRecording();
			_model.Dispose();
		}

		private void InitializeComponent()
		{
			AvaloniaXamlLoader.Load(this);
		}
	}
}