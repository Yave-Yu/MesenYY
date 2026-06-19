using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Mesen.Config.Shortcuts
{
	public class ShortcutKeyInfo : ReactiveObject
	{
		[Reactive] public EmulatorShortcut Shortcut { get; set; }
		[Reactive] public KeyCombination KeyCombination { get; set; } = new KeyCombination();
		[Reactive] public KeyCombination KeyCombination2 { get; set; } = new KeyCombination();
	}
}
