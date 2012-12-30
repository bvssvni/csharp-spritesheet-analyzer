using System;
using System.Text;

namespace SpriteSheetAnalyzer
{
	public class RefreshIslandsOutputAction
	{
		public static void Refresh(App app)
		{
			var rectangles = app.Islands;
			rectangles.Sort();
			var strb = new StringBuilder();
			for (int i = 0; i < rectangles.Count; i++) {
				var r = rectangles[i];
				strb.Append("{x = ");
				strb.Append(r.X.ToString());
				strb.Append(", y = ");
				strb.Append(r.Y.ToString());
				strb.Append(", w = ");
				strb.Append(r.Width.ToString());
				strb.Append(", h = ");
				strb.Append(r.Height.ToString());
				strb.Append("},\n");
			}
			app.Output = strb.ToString();
			app.UI(UI.Output);
		}
	}
}

