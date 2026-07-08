using CommunityToolkit.Mvvm.ComponentModel;

namespace Mesen.Config.Shortcuts
{
	public partial class ShortcutKeyInfo : ObservableObject
	{
		[ObservableProperty] public partial EmulatorShortcut Shortcut { get; set; }
		[ObservableProperty] public partial KeyCombination KeyCombination { get; set; } = new KeyCombination();
		[ObservableProperty] public partial KeyCombination KeyCombination2 { get; set; } = new KeyCombination();
	}
}
