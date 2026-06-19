using Mesen.ViewModels;
using ReactiveUI.Fody.Helpers;

namespace Mesen.Config
{
	public class WsDebuggerConfig : ViewModelBase
	{
		[Reactive] public bool BreakOnUndefinedOpCode { get; set; } = false;
	}
}
