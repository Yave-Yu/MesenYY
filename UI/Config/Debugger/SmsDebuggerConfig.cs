using Mesen.ViewModels;
using ReactiveUI.Fody.Helpers;

namespace Mesen.Config
{
	public class SmsDebuggerConfig : ViewModelBase
	{
		[Reactive] public bool BreakOnNopLoad { get; set; } = false;
	}
}
