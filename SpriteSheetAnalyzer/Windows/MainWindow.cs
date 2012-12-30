using System;
using System.Collections.Generic;
using System.Text;
using Gtk;
using Gdk;
using SpriteSheetAnalyzer;

public partial class MainWindow: Gtk.Window
{	
	App m_app = new App();

	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();

		m_app.Should += delegate(SpriteSheetAnalyzer.Act action) {
			switch (action) {
				case Act.AnalyzeHorizontal: return this.IsHorizontalActive;
				case Act.AnalyzeVertical: return this.IsVerticalActive;
				case Act.AnalyzeIslands: return this.IsIslandsActive;
				case Act.Analyze: return true;
				case Act.Clean: return true;
				case Act.RemoveBackground: return true;
				case Act.RefreshIslandsOutputAction: return true;
				case Act.CopyToClipboard: return true;
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
				case UI.ErrorMessage: this.ShowError(app.ErrorMessage); return;
				case UI.Output: this.outputLabel.Text = app.Output; return;
				case UI.Filename: this.fileLabel.Text = System.IO.Path.GetFileName(app.Filename); return;
				case UI.IslandEditor: islandeditor.App = m_app; islandeditor.QueueDraw(); return;
			}

#if DEBUG
			throw new NotImplementedException(e.UI.ToString());
#endif
		};

		this.mode.Active = 0;

		this.islandeditor.IslandsUpdated += delegate(object sender, EventArgs e) {
			m_app.Do(Act.RefreshIslandsOutputAction);
		};
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	public void ShowError(string error)
	{
		string title = "Sprite Sheet Analyzer";
		if (error == null) this.Title = title;
		else this.Title = title + ", Error: " + error.ToString();
	}

	private bool IsHorizontalActive
	{
		get {
			return mode.Active == 0;
		}
	}

	private bool IsVerticalActive
	{
		get {
			return mode.Active == 1;
		}
	}

	private bool IsIslandsActive
	{
		get {
			return mode.Active == 2;
		}
	}

	protected void openFileClicked (object sender, EventArgs e)
	{
		// Open sprite sheet.
		var dialog = new Gtk.FileChooserDialog("Select Sprite Sheet", this, FileChooserAction.Open,
		                                       "gtk-cancel", ResponseType.Cancel,
		                                       "gtk-ok", ResponseType.Ok);
		dialog.Filter = new FileFilter();
		dialog.Filter.AddPattern("*.png");
		var result = (ResponseType)dialog.Run();
		dialog.Hide();

		if (result != ResponseType.Ok) return;

		var app = m_app;
		app.Filename = dialog.Filename;
		app.Do(Act.Analyze);
	}

	protected void clipboardButtionClicked (object sender, EventArgs e)
	{
		m_app.Do(Act.CopyToClipboard);
	}

	protected void cleanButtonClicked (object sender, EventArgs e)
	{
		m_app.Do(Act.Clean);
	}

	protected void modeChanged (object sender, EventArgs e)
	{
		m_app.Do(Act.Analyze);
	}

	protected void removeBackgroundClicked (object sender, EventArgs e)
	{
		m_app.Do(Act.RemoveBackground);
	}
}
