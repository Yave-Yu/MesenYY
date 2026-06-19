using Mesen.Config;
using Mesen.Interop;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;

namespace Mesen.ViewModels
{
	public class AudioPlayerViewModel : ViewModelBase
	{
		[Reactive] public AudioPlayerConfig Config { get; set; }
		[Reactive] public bool IsPaused { get; set; }

		public AudioPlayerViewModel()
		{
			Config = ConfigManager.Config.AudioPlayer;

			this.WhenAnyValue(x => x.Config.Volume).Subscribe((vol) => {
				Config.ApplyConfig();
			});
		}

		public void UpdatePauseFlag()
		{
			IsPaused = EmuApi.IsPaused();
		}
	}
}
