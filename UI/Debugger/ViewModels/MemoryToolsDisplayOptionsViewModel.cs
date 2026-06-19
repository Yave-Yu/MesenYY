using Avalonia.Controls;
using Mesen.Config;
using Mesen.Interop;
using Mesen.ViewModels;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Reactive.Linq;

namespace Mesen.Debugger.ViewModels
{
	public class MemoryToolsDisplayOptionsViewModel : DisposableViewModel
	{
		public HexEditorConfig Config { get; }
		public MemoryToolsViewModel MemoryTools { get; }

		public int[] AvailableWidths => new int[] { 4, 8, 16, 32, 48, 64, 80, 96, 112, 128 };

		[Reactive] public bool ShowFrozenAddressesOption { get; set; }
		[Reactive] public bool ShowNesPcmDataOption { get; set; }
		[Reactive] public bool ShowNesDrawnChrRomOption { get; set; }

		[Obsolete("For designer only")]
		public MemoryToolsDisplayOptionsViewModel() : this(new()) { }

		public MemoryToolsDisplayOptionsViewModel(MemoryToolsViewModel memoryTools)
		{
			Config = memoryTools.Config;
			MemoryTools = memoryTools;

			if(Design.IsDesignMode) {
				return;
			}

			AddDisposable(this.WhenAnyValue(x => x.Config.MemoryType).Subscribe(x => UpdateAvailableOptions()));
		}

		public void UpdateAvailableOptions()
		{
			ShowFrozenAddressesOption = Config.MemoryType.SupportsFreezeAddress();
			ShowNesPcmDataOption = Config.MemoryType.ToCpuType() == CpuType.Nes;
			ShowNesDrawnChrRomOption = Config.MemoryType.ToCpuType() == CpuType.Nes && DebugApi.GetMemorySize(MemoryType.NesChrRom) > 0;
		}
	}
}
