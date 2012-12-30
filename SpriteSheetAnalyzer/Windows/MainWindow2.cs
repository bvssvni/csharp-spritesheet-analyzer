using System;
using Gtk;

namespace SpriteSheetAnalyzer
{
	public partial class MainWindow2 : Gtk.Window
	{
		private App m_app;

		public MainWindow2() : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build();

			m_app = new App();

			m_app.Should += delegate(Act action) {
				switch (action) {
					case Act.AnalyzeHorizontal: return IsHorizontalActive;
					case Act.AnalyzeVertical: return IsVerticalActive;
					case Act.AnalyzeIslands: return IsIslandsActive;
					case Act.Analyze: return true;
					case Act.Clean: return IsCleanActive;
					case Act.RemoveBackground: return IsRemoveBackgroundActive;
					case Act.RefreshIslandsOutputAction: return true;
					case Act.Process: return true;
				}

#if DEBUG
				throw new NotImplementedException(action.ToString());
#else
				return false;
#endif
			};

			m_app.UpdateInterface += delegate(object sender, UIEventArgs e) {
				var app = m_app;
				switch (e.UI) {
					case UI.Output: textviewOutput.Buffer.Text = app.Output; return;
					case UI.ErrorMessage: ShowError(app.ErrorMessage); return;
					case UI.Filename: return;
					case UI.IslandEditor: islandeditor1.App = m_app; islandeditor1.QueueDraw(); return;
					case UI.CompletedTask: ShowCompleted(app.Task); return;
				}

#if DEBUG
				throw new NotImplementedException(e.UI.ToString());
#endif
			};

			comboboxMode.Active = 0;
			comboboxProcess.Active = 0;
			islandeditor1.App = m_app;

			var filter = new FileFilter();
			filter.AddPattern("*.png");
			filter.AddPattern("*.PNG");
			filechooserbuttonOpen.AddFilter(filter);


		}

		private bool IsCleanActive
		{
			get {
				return comboboxProcess.Active == 0;
			}
		}

		private bool IsRemoveBackgroundActive
		{
			get {
				return comboboxProcess.Active == 1;
			}
		}

		private bool IsHorizontalActive
		{
			get {
				return comboboxMode.Active == 0;
			}
		}

		private bool IsVerticalActive
		{
			get {
				return comboboxMode.Active == 1;
			}
		}

		private bool IsIslandsActive
		{
			get {
				return comboboxMode.Active == 2;
			}
		}

		private void ShowError(string errorMessage)
		{
			if (errorMessage == null) statusbar1.Push(statusbar1.GetContextId("Status"), "");
			else statusbar1.Push(statusbar1.GetContextId("Error"), m_app.ErrorMessage);
		}

		private void ShowCompleted(string task)
		{
			statusbar1.Push(statusbar1.GetContextId("Completed"), task + " completed");
		}

		protected void windowDeleted (object o, Gtk.DeleteEventArgs args)
		{
			Application.Quit();
			args.RetVal = true;
		}

		protected void selectedFileChanged (object sender, EventArgs e)
		{
			m_app.Filename = filechooserbuttonOpen.Filename;
			m_app.Do(Act.Analyze);
		}

		protected void modeChanged (object sender, EventArgs e)
		{
			m_app.Do(Act.Analyze);
		}

		protected void processClicked (object sender, EventArgs e)
		{
			m_app.Do(Act.Process);
		}
	}
}

