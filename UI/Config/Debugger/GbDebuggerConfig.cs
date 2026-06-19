using Mesen.ViewModels;
using ReactiveUI.Fody.Helpers;

namespace Mesen.Config
{
	public class GbDebuggerConfig : ViewModelBase
	{
		[Reactive] public bool GbBreakOnInvalidOamAccess { get; set; } = false;
		[Reactive] public bool GbBreakOnInvalidVramAccess { get; set; } = false;
		[Reactive] public bool GbBreakOnDisableLcdOutsideVblank { get; set; } = false;
		[Reactive] public bool GbBreakOnInvalidOpCode { get; set; } = false;
		[Reactive] public bool GbBreakOnNopLoad { get; set; } = false;
		[Reactive] public bool GbBreakOnOamCorruption { get; set; } = false;
	}
}
