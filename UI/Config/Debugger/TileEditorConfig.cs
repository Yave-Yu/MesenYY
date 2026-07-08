using CommunityToolkit.Mvvm.ComponentModel;
using Mesen.Interop;

namespace Mesen.Config
{
	public partial class TileEditorConfig : BaseWindowConfig<TileEditorConfig>
	{
		[ObservableProperty] public partial double ImageScale { get; set; } = 8;
		[ObservableProperty] public partial bool ShowGrid { get; set; } = false;
		[ObservableProperty] public partial TileBackground Background { get; set; } = TileBackground.Transparent;
	}
}
