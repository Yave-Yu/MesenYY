using ReactiveUI.Fody.Helpers;
using System;

namespace Mesen.Config
{
	public class OverscanConfig : BaseConfig<OverscanConfig>
	{
		[Reactive][MinMax(0, 100)] public UInt32 Left { get; set; } = 0;
		[Reactive][MinMax(0, 100)] public UInt32 Right { get; set; } = 0;
		[Reactive][MinMax(0, 95)] public UInt32 Top { get; set; } = 0;
		[Reactive][MinMax(0, 95)] public UInt32 Bottom { get; set; } = 0;

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