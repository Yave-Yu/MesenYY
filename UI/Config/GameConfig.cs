using Mesen.Interop;
using Mesen.Utilities;
using Mesen.ViewModels;
using ReactiveUI.Fody.Helpers;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace Mesen.Config
{
	public class GameConfig : BaseConfig<GameConfig>
	{
		[Reactive] public UInt32 DipSwitches { get; set; } = 0;

		[Reactive] public bool OverrideOverscan { get; set; } = false;
		[Reactive] public OverscanConfig Overscan { get; set; } = new();

		public void ApplyConfig()
		{
			ConfigApi.SetGameConfig(new InteropGameConfig() {
				DipSwitches = DipSwitches,
				OverrideOverscan = OverrideOverscan,
				Overscan = Overscan.ToInterop()
			});
		}

		public static GameConfig LoadGameConfig(RomInfo romInfo)
		{
			string path = Path.Combine(ConfigManager.GameConfigFolder, romInfo.GetRomName() + ".json");
			GameConfig? cfg;
			if(File.Exists(path)) {
				string? fileData = FileHelper.ReadAllText(path);
				if(fileData != null) {
					try {
						cfg = (GameConfig?)JsonSerializer.Deserialize(fileData, typeof(GameConfig), MesenSerializerContext.Default);
						if(cfg != null) {
							return cfg;
						}
					} catch { }
				}
			}

			cfg = new GameConfig();
			cfg.DipSwitches = DipSwitchDatabase.GetGameDipswitches(romInfo.DipSwitches).DefaultDipSwitches;
			return cfg;
		}

		public void Save()
		{
			string romName = MainWindowViewModel.Instance.RomInfo.GetRomName();
			string path = Path.Combine(ConfigManager.GameConfigFolder, romName + ".json");
			FileHelper.WriteAllText(path, JsonSerializer.Serialize(this, typeof(GameConfig), MesenSerializerContext.Default));
		}
	}

	public struct InteropGameConfig
	{
		public UInt32 DipSwitches;

		[MarshalAs(UnmanagedType.I1)] public bool OverrideOverscan;
		public InteropOverscanDimensions Overscan;
	}
}