using Avalonia;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mesen.Config;
using Mesen.Utilities;
using Mesen.Windows;
using System;

namespace Mesen.ViewModels
{
	public partial class WsConfigViewModel : DisposableViewModel
	{
		[ObservableProperty] public partial WsConfig Config { get; set; }
		[ObservableProperty] public partial WsConfig OriginalConfig { get; set; }
		[ObservableProperty] public partial WsConfigTab SelectedTab { get; set; } = 0;

		public IRelayCommand SetupPlayerHorizontal { get; }
		public IRelayCommand SetupPlayerVertical { get; }
		public IRelayCommand SetupPlayerPcV2 { get; }

		public WsConfigViewModel()
		{
			Config = ConfigManager.Config.Ws;
			OriginalConfig = Config.Clone();

			SetupPlayerHorizontal = new RelayCommand<Button>(btn => this.OpenSetup(btn!, ControllerType.WsController));
			SetupPlayerVertical = new RelayCommand<Button>(btn => this.OpenSetup(btn!, ControllerType.WsControllerVertical));
			SetupPlayerPcV2 = new RelayCommand<Button>(btn => this.OpenSetup(btn!, ControllerType.PcV2Controller));
			
			if(Design.IsDesignMode) {
				return;
			}

			AddDisposable(ReactiveHelper.RegisterRecursiveObserver(Config, (s, e) => { Config.ApplyConfig(); }));
		}

		private async void OpenSetup(Button btn, ControllerType type)
		{
			PixelPoint startPosition = btn.PointToScreen(new Point(-7, btn.Bounds.Height));
			ControllerConfigWindow wnd = new ControllerConfigWindow();
			ControllerConfig orgCfg = type switch {
				ControllerType.WsController => Config.ControllerHorizontal,
				ControllerType.WsControllerVertical => Config.ControllerVertical,
				ControllerType.PcV2Controller => Config.ControllerPcV2,
				_ => throw new NotImplementedException()
			};

			ControllerConfig cfg = orgCfg.Clone();

			wnd.DataContext = new ControllerConfigViewModel(type, cfg, orgCfg, 0);

			if(await wnd.ShowDialogAtPosition<bool>(btn.GetWindow(), startPosition)) {
				switch(type) {
					case ControllerType.WsController: Config.ControllerHorizontal = cfg; break;
					case ControllerType.WsControllerVertical: Config.ControllerVertical = cfg; break;
					case ControllerType.PcV2Controller: Config.ControllerPcV2 = cfg; break;
				}
			}
		}
	}

	public enum WsConfigTab
	{
		General,
		Audio,
		Emulation,
		Input,
		Video
	}
}
