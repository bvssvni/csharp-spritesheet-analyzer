using System;
using System.Collections.Generic;
using Gdk;

namespace SpriteSheetAnalyzer
{
	/// <summary>
	/// Allows joining island by linking islands together.
	/// </summary>
	[System.ComponentModel.ToolboxItem(true)]
	public class IslandEditor : Gtk.DrawingArea
	{
		public IslandEditor()
		{
			// Insert initialization code here.
			this.ButtonPressEvent += delegate(object o, Gtk.ButtonPressEventArgs args) {
				if (m_app == null) return;
				if (m_app.Islands == null) return;
				if (args.Event.Button == 1) {
					m_linkIslandsHelper = new LinkIslandsHelper();
					m_linkIslandsHelper.Step1_SetIslands(m_app.Islands);
					m_linkIslandsHelper.Step2_SetStart((int)args.Event.X, (int)args.Event.Y);
					this.QueueDraw();
				}
			};
			this.ButtonReleaseEvent += delegate(object o, Gtk.ButtonReleaseEventArgs args) {
				if (m_app == null) return;
				if (m_app.Islands == null) return;
				if (args.Event.Button == 1) {
					m_linkIslandsHelper.Step3_SetEnd((int)args.Event.X, (int)args.Event.Y);
					m_linkIslandsHelper.Step4_Join();
					m_linkIslandsHelper = new LinkIslandsHelper();

					// Tell the owner that the islands are updated.
					if (this.IslandsUpdated != null) this.IslandsUpdated(this, new EventArgs());

					this.QueueDraw();
				}
			};
			this.MotionNotifyEvent += delegate(object o, Gtk.MotionNotifyEventArgs args) {
				var state = (ModifierType)args.Event.State;
				if ((state & ModifierType.Button1Mask) != 0) {
					m_linkIslandsHelper.Step3_SetEnd((int)args.Event.X, (int)args.Event.Y);
					this.QueueDraw();
				}
			};

			this.Events = EventMask.ButtonPressMask | EventMask.ButtonReleaseMask | EventMask.PointerMotionMask;
		}

		private App m_app;
		private LinkIslandsHelper m_linkIslandsHelper = new LinkIslandsHelper();

		public event EventHandler<EventArgs> IslandsUpdated;

		private void UpdateWidthAndHeightByImage() {
			if (m_app == null) return;
			if (m_app.Image == null) return;

			var img = m_app.Image;
			this.SetSizeRequest(img.Width, img.Height);
		}

		public App App
		{
			get {
				return m_app;
			}
			set {
				m_app = value;

				UpdateWidthAndHeightByImage();
				m_linkIslandsHelper.Step1_SetIslands(m_app.Islands);
			}
		}

		protected override bool OnButtonPressEvent(Gdk.EventButton ev)
		{
			// Insert button press handling code here.
			return base.OnButtonPressEvent(ev);
		}

		private void DrawImage(Window window, Gdk.GC gc)
		{
			if (m_app == null) return;
			if (m_app.Image == null) return;

			var img = m_app.Image;
			int width = img.Width;
			int height = img.Height;
			window.DrawPixbuf(gc, img, 0, 0, 0, 0, width, height, RgbDither.None, 0, 0);
		}

		private void DrawIslands(Window window, Gdk.GC gc)
		{
			if (m_app == null) return;
			if (m_app.Islands == null) return;

			gc.RgbFgColor = new Color(255, 0, 255);
			foreach (var island in m_app.Islands) {
				window.DrawRectangle(gc, false, island.X, island.Y, island.Width, island.Height);
			}
		}

		private int DrawingWidth
		{
			get {
				if (m_app == null || m_app.Image == null) return this.GdkWindow.FrameExtents.Width;

				return m_app.Image.Width;
			}
		}

		private int DrawingHeight
		{
			get {
				if (m_app == null || m_app.Image == null) return this.GdkWindow.FrameExtents.Height;

				return m_app.Image.Height;
			}
		}

		private int RequestWidth
		{
			get {
				if (m_app == null || m_app.Image == null) return 50;

				return m_app.Image.Width;
			}
		}

		private int RequestHeight
		{
			get {
				if (m_app == null || m_app.Image == null) return 50;

				return m_app.Image.Height;
			}
		}

		protected override bool OnExposeEvent(Gdk.EventExpose ev)
		{
			base.OnExposeEvent(ev);
			// Insert drawing code here.

			var window = ev.Window;
			var gc = new Gdk.GC(window);

			// window.DrawRectangle(gc, true, new Rectangle(0, 0, 100, 100));
			int width = this.DrawingWidth;
			int height = this.DrawingHeight;
			CheckerPattern.Draw(window, gc, 10, width, height);

			DrawImage(window, gc);
			DrawIslands(window, gc);

			m_linkIslandsHelper.Step4_Draw(window, gc);

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
			// Calculate desired size here.
			requisition.Height = this.RequestWidth;
			requisition.Width = this.RequestHeight;
		}
	}
}

