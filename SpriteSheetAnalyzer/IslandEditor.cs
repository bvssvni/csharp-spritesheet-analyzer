using System;
using System.Collections.Generic;
using Gdk;

namespace SpriteSheetAnalyzer
{
	/// <summary>
	/// Allows joining island by drag drop.
	/// </summary>
	[System.ComponentModel.ToolboxItem(true)]
	public class IslandEditor : Gtk.DrawingArea
	{
		public IslandEditor()
		{
			// Insert initialization code here.
		}

		private Pixbuf m_image;
		private List<Island> m_islands;

		private void UpdateWidthAndHeightByImage() {
			if (m_image == null) return;

			this.SetSizeRequest(m_image.Width, m_image.Height);
		}

		public Pixbuf Image
		{
			get {
				return m_image;
			}
			set {
				m_image = value;

				UpdateWidthAndHeightByImage();
			}
		}

		public List<Island> Islands
		{
			get {
				return m_islands;
			}
			set {
				m_islands = value;
			}
		}

		protected override bool OnButtonPressEvent(Gdk.EventButton ev)
		{
			// Insert button press handling code here.
			return base.OnButtonPressEvent(ev);
		}

		private void DrawImage(Window window, Gdk.GC gc)
		{
			if (m_image == null) return;

			// Console.WriteLine("Draw image");
			int width = m_image.Width;
			int height = m_image.Height;
			window.DrawPixbuf(gc, m_image, 0, 0, 0, 0, width, height, RgbDither.None, 0, 0);
		}

		private void DrawIslands(Window window, Gdk.GC gc)
		{
			if (m_islands == null) return;

			gc.RgbFgColor = new Color(255, 0, 255);
			foreach (var island in m_islands) {
				window.DrawRectangle(gc, false, island.X, island.Y, island.Width, island.Height);
			}
		}

		protected override bool OnExposeEvent(Gdk.EventExpose ev)
		{
			base.OnExposeEvent(ev);
			// Insert drawing code here.

			var window = ev.Window;
			var gc = new Gdk.GC(window);

			// window.DrawRectangle(gc, true, new Rectangle(0, 0, 100, 100));
			CheckerPattern.Draw(window, gc, 10);

			DrawImage(window, gc);
			DrawIslands(window, gc);

			gc.Dispose();

			return true;
		}

		protected override void OnSizeAllocated(Gdk.Rectangle allocation)
		{
			base.OnSizeAllocated(allocation);
			// Insert layout code here.
		}

		protected override void OnSizeRequested(ref Gtk.Requisition requisition)
		{
			if (m_image != null) {
				requisition.Width = m_image.Width;
				requisition.Height = m_image.Height;
			}
			// Calculate desired size here.
			requisition.Height = 50;
			requisition.Width = 50;
		}
	}
}

