#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.VisualTree;
using Mesen.Debugger.Controls;
using Mesen.Utilities;
using Mesen.ViewModels;
using Mesen.Windows;
using System;
using System.Threading.Tasks;

namespace Mesen.Views
{
	public class GameboyConfigView : UserControl
	{
		private GameboyConfigViewModel _model;

		public GameboyConfigView()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
			AvaloniaXamlLoader.Load(this);
		}

		protected override void OnDataContextChanged(EventArgs e)
		{
			if(DataContext is GameboyConfigViewModel model) {
				_model = model;
			}
		}

		private async Task<Color> SelectColor(Color color)
		{
			ColorPickerViewModel model = new ColorPickerViewModel() { Color = color };
			ColorPickerWindow wnd = new ColorPickerWindow() { DataContext = model };

			bool success = await wnd.ShowCenteredDialog<bool>(this.GetWindow());
			if(success) {
				return model.Color;
			}
			return color;
		}

		private async void BgColor_OnClick(object sender, PaletteSelector.ColorClickEventArgs e)
		{
			Color color = await SelectColor(e.Color);
			UInt32[] colors = (UInt32[])_model.Config.BgColors.Clone();
			colors[e.ColorIndex] = color.ToUInt32();
			_model.Config.BgColors = colors;
		}

		private async void Obj0Color_OnClick(object sender, PaletteSelector.ColorClickEventArgs e)
		{
			Color color = await SelectColor(e.Color);
			UInt32[] colors = (UInt32[])_model.Config.Obj0Colors.Clone();
			colors[e.ColorIndex] = color.ToUInt32();
			_model.Config.Obj0Colors = colors;
		}

		private async void Obj1Color_OnClick(object sender, PaletteSelector.ColorClickEventArgs e)
		{
			Color color = await SelectColor(e.Color);
			UInt32[] colors = (UInt32[])_model.Config.Obj1Colors.Clone();
			colors[e.ColorIndex] = color.ToUInt32();
			_model.Config.Obj1Colors = colors;
		}

		private void BtnSelectPreset_OnClick(object sender, RoutedEventArgs e)
		{
			((Button)sender).ContextMenu?.Open();
		}

		private void mnuGrayPreset_Click(object sender, RoutedEventArgs e)
		{
			SetPalette(Color.FromArgb(255, 255, 255, 255), Color.FromArgb(255, 181, 181, 181), Color.FromArgb(255, 115, 115, 115), Color.FromArgb(255, 0, 0, 0));
		}

		private void mnuOlivePreset_Click(object sender, RoutedEventArgs e)
		{
			SetPalette(Color.FromArgb(255, 222, 239, 148), Color.FromArgb(255, 173, 198, 66), Color.FromArgb(255, 82, 132, 49), Color.FromArgb(255, 33, 74, 33));
		}

		private void mnuLimePreset_Click(object sender, RoutedEventArgs e)
		{
			SetPalette(Color.FromArgb(255, 214, 255, 214), Color.FromArgb(255, 123, 198, 123), Color.FromArgb(255, 66, 132, 66), Color.FromArgb(255, 16, 66, 16));
		}

		private void mnuTealPreset_Click(object sender, RoutedEventArgs e)
		{
			SetPalette(Color.FromArgb(255, 165, 239, 222), Color.FromArgb(255, 115, 198, 181), Color.FromArgb(255, 66, 132, 115), Color.FromArgb(255, 16, 74, 66));
		}

		private void SetPalette(Color color0, Color color1, Color color2, Color color3)
		{
			_model.Config.BgColors = new UInt32[] { color0.ToUInt32(), color1.ToUInt32(), color2.ToUInt32(), color3.ToUInt32() };
			_model.Config.Obj0Colors = new UInt32[] { color0.ToUInt32(), color1.ToUInt32(), color2.ToUInt32(), color3.ToUInt32() };
			_model.Config.Obj1Colors = new UInt32[] { color0.ToUInt32(), color1.ToUInt32(), color2.ToUInt32(), color3.ToUInt32() };
		}
	}
}
