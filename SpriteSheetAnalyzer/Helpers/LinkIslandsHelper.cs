using System;
using System.Collections.Generic;
using Gdk;
using Utils;

namespace SpriteSheetAnalyzer
{
	public class LinkIslandsHelper
	{
		private List<SpriteIsland> m_islands;
		private bool m_startSet = false;
		private bool m_endSet = false;
		private int m_startx, m_starty;
		private int m_endx, m_endy;

		public LinkIslandsHelper()
		{
		}

		public void Step1_SetIslands(List<SpriteIsland> islands) {
			m_islands = islands;
		}

		public void Step2_SetStart(int x, int y) {
			if (m_islands == null) return;

			int hitIndex = SpriteIsland.HitIndex(m_islands, x, y);
			m_startx = x;
			m_starty = y;
			m_startSet = hitIndex >= 0;
		}

		public void Step3_SetEnd(int x, int y) {
			if (m_islands == null) return;

			m_endx = x;
			m_endy = y;
			m_endSet = true;
		}

		public void Step4_Draw(Window window, Gdk.GC gc) {
			if (m_islands == null) return;
			if (!m_startSet) return;
			if (!m_endSet) return;

			// Draw a line from start point to ending point.
			gc.RgbFgColor = new Color(255, 0, 255);
			window.DrawLine(gc, m_startx, m_starty, m_endx, m_endy);
		}

		public void Step4_Join() {
			if (m_islands == null) return;
			if (!m_startSet) return;
			if (!m_endSet) return;

			int startHitIndex = SpriteIsland.HitIndex(m_islands, m_startx, m_starty);
			if (startHitIndex == -1) return;
			int endHitIndex = SpriteIsland.HitIndex(m_islands, m_endx, m_endy);
			if (endHitIndex == -1) return;

			SpriteIsland.Join(m_islands, startHitIndex, endHitIndex);
			SpriteIsland.JoinOverlaps(m_islands);
		}
	}
}

