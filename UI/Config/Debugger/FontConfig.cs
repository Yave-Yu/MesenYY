using ReactiveUI.Fody.Helpers;

namespace Mesen.Config
{
	public class FontConfig : BaseConfig<FontConfig>
	{
		[Reactive] public string FontFamily { get; set; } = "";
		[Reactive] public double FontSize { get; set; } = 12;
	}
}
