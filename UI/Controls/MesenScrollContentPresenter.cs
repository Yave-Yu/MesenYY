using Avalonia.Controls.Presenters;
using Avalonia.Input;
using System;

namespace Mesen.Controls
{
	public class MesenScrollContentPresenter : ScrollContentPresenter
	{
		protected override Type StyleKeyOverride => typeof(ScrollContentPresenter);

		protected override void OnPointerWheelChanged(PointerWheelEventArgs e)
		{
			if(!e.KeyModifiers.HasFlag(KeyModifiers.Control)) {
				//Skip event if control is pressed, because this is used to zoom in/out
				base.OnPointerWheelChanged(e);
			}
		}
	}
}
