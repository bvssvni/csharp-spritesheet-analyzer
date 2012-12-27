using System;
using System.Text;
using Gtk;
using Gdk;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
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

	/// <summary>
	/// Analyze an image and displays the sequence fit alternatives.
	/// </summary>
	/// <param name='buf'>
	/// The image to analyze.
	/// </param>
	public void Analyze(Pixbuf buf)
	{
		var list = SpriteSheetAnalyzer.Analyzer.FindFit(buf);
		if (list.Count == 0) {
			this.outputLabel.Text = "(Did not found any sprite frames)";
			return;
		}
		var strb = new StringBuilder();
		for (int i = 0; i < list.Count; i++) {
			strb.Append(list[i].ToString());
			strb.Append("\n");
		}
		this.outputLabel.Text = strb.ToString();
		buf.Dispose();
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

		// Analyze the sprite sheet and show fit options.
		string filename = dialog.Filename;
		this.outputLabel.Text = "(output)";
		this.fileLabel.Text = System.IO.Path.GetFileName(filename);
		ShowError(null);
		try {
			var buf = new Pixbuf(filename);
			Analyze(buf);
		}
		catch (Exception ex) {
			ShowError(ex.Message);
		}
	}
}
