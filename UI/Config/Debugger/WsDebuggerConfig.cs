using CommunityToolkit.Mvvm.ComponentModel;
using Mesen.ViewModels;

namespace Mesen.Config
{
	public partial class WsDebuggerConfig : ViewModelBase
	{
		[ObservableProperty] public partial bool BreakOnUndefinedOpCode { get; set; } = false;
	}
}
