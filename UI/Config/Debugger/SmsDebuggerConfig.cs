using CommunityToolkit.Mvvm.ComponentModel;
using Mesen.ViewModels;

namespace Mesen.Config
{
	public partial class SmsDebuggerConfig : ViewModelBase
	{
		[ObservableProperty] public partial bool BreakOnNopLoad { get; set; } = false;
	}
}
