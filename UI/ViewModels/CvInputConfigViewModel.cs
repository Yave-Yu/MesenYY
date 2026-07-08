using Mesen.Config;
using CommunityToolkit.Mvvm.ComponentModel;
using System;

namespace Mesen.ViewModels
{
	public partial class CvInputConfigViewModel : DisposableViewModel
	{
		[ObservableProperty] public partial CvConfig Config { get; set; }

		public Enum[] AvailableControllerTypesP12 => new Enum[] {
			ControllerType.None,
			ControllerType.ColecoVisionController,
		};

		[Obsolete("For designer only")]
		public CvInputConfigViewModel() : this(new CvConfig()) { }

		public CvInputConfigViewModel(CvConfig config)
		{
			Config = config;
		}
	}
}
