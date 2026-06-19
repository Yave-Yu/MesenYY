using ReactiveUI.Fody.Helpers;
using System;

namespace Mesen.Config
{
	public class VideoRecordConfig : BaseConfig<VideoRecordConfig>
	{
		[Reactive] public VideoCodec Codec { get; set; } = VideoCodec.CSCD;
		[Reactive] public UInt32 CompressionLevel { get; set; } = 6;
		[Reactive] public bool RecordSystemHud { get; set; } = false;
		[Reactive] public bool RecordInputHud { get; set; } = false;
	}

	public enum VideoCodec
	{
		None = 0,
		ZMBV = 1,
		CSCD = 2,
		GIF = 3
	}
}
