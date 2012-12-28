using System;
using Gdk;

namespace SpriteSheetAnalyzer
{
	/// <summary>
	/// Draws a checker pattern using the Gdk API.
	/// </summary>
	public class CheckerPattern
	{
		public static void Draw(Window window, Gdk.GC gc, int units)
		{
			var rect = window.FrameExtents;

			var darkColor = new Gdk.Color(50, 50, 50);
			var brightColor = new Gdk.Color(100, 100, 100);
			int nw = rect.Width / units;
			int nh = rect.Height / units;
			for (int i = 0; i < nw; i++) {
				for (int j = 0; j < nh; j++) {
					bool dark = ((i + j) % 2) == 0;
					if (dark) gc.RgbFgColor = darkColor;
					else gc.RgbFgColor = brightColor;
					window.DrawRectangle(gc, true, units * i, units * j, units, units);
				}
			}
		}
	}
}

