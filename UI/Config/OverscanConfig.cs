using CommunityToolkit.Mvvm.ComponentModel;
using System;

namespace Mesen.Config
{
	public partial class OverscanConfig : BaseConfig<OverscanConfig>
	{
		[ObservableProperty][MinMax(0, 100)] public partial UInt32 Left { get; set; } = 0;
		[ObservableProperty][MinMax(0, 100)] public partial UInt32 Right { get; set; } = 0;
		[ObservableProperty][MinMax(0, 95)] public partial UInt32 Top { get; set; } = 0;
		[ObservableProperty][MinMax(0, 95)] public partial UInt32 Bottom { get; set; } = 0;

		public InteropOverscanDimensions ToInterop()
		{
			return new InteropOverscanDimensions() {
				Left = Left,
				Right = Right,
				Top = Top,
				Bottom = Bottom,
			};
		}
	}

	public struct InteropOverscanDimensions
	{
		public UInt32 Left;
		public UInt32 Right;
		public UInt32 Top;
		public UInt32 Bottom;
	}
}