using Mesen.Config;
using ReactiveUI.Fody.Helpers;
using System;

namespace Mesen.ViewModels
{
	public class SmsInputConfigViewModel : DisposableViewModel
	{
		[Reactive] public SmsConfig Config { get; set; }

		public Enum[] AvailableControllerTypesP12 => new Enum[] {
			ControllerType.None,
			ControllerType.SmsController,
			ControllerType.SmsLightPhaser,
		};

		[Obsolete("For designer only")]
		public SmsInputConfigViewModel() : this(new SmsConfig()) { }

		public SmsInputConfigViewModel(SmsConfig config)
		{
			Config = config;
		}
	}
}
