using Mesen.ViewModels;
using ReactiveUI.Fody.Helpers;

namespace Mesen.Config
{
	public class PceDebuggerConfig : ViewModelBase
	{
		[Reactive] public bool BreakOnBrk { get; set; } = false;
		[Reactive] public bool BreakOnUnofficialOpCode { get; set; } = false;
		[Reactive] public bool BreakOnInvalidVramAddress { get; set; } = false;
	}
}
