using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using Mesen.Config;
using Mesen.Utilities;

namespace Mesen.ViewModels
{
	public partial class InputConfigViewModel : DisposableViewModel
	{
		[ObservableProperty] public partial InputConfig Config { get; set; }
		[ObservableProperty] public partial InputConfig OriginalConfig { get; set; }

		public InputConfigViewModel()
		{
			Config = ConfigManager.Config.Input;
			OriginalConfig = Config.Clone();

			if(Design.IsDesignMode) {
				return;
			}

			AddDisposable(ReactiveHelper.RegisterRecursiveObserver(Config, (s, e) => { Config.ApplyConfig(); }));
		}
	}
}
