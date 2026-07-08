using System.Collections.Generic;

namespace Mesen.Config
{
	public partial class CheatWindowConfig : BaseWindowConfig<CheatWindowConfig>
	{
		public bool DisableAllCheats { get; set; } = false;
		public List<int> ColumnWidths { get; set; } = new();
	}
}
