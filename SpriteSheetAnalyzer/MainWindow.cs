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

	private void AnalyzeHorizontal(Pixbuf buf)
	{
		var list = SpriteSheetAnalyzer.Analyzer.FindFit(buf);
		if (list.Count == 0) {
			this.outputLabel.Text = "(Did not found any sprite frames)";
			return;
		}

		var strb = new StringBuilder();
		for (int i = 0; i < list.Count; i++) {
			strb.Append("{");
			strb.Append(list[i].ToString());
			strb.Append("}\n");
		}
		this.outputLabel.Text = strb.ToString();
	}

	private void AnalyzeIslands(Pixbuf buf)
	{
		var rectangles = SpriteSheetAnalyzer.Analyzer.FindIslands(buf);
		if (rectangles.Count == 0) {
			this.outputLabel.Text = "(Did not found any island)";
			return;
		}

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
		this.outputLabel.Text = strb.ToString();
	}

	/// <summary>
	/// Analyze an image and displays the sequence fit alternatives.
	/// </summary>
	/// <param name='buf'>
	/// The image to analyze.
	/// </param>
	public void Analyze(Pixbuf buf)
	{
		if (horizontalRadioButton.Active) AnalyzeHorizontal(buf);
		if (islandsRadioButton.Active) AnalyzeIslands(buf);
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
		// try {
			var buf = new Pixbuf(filename);
			Analyze(buf);
			buf.Dispose();
		//}
		//catch (Exception ex) {
		//	ShowError(ex.Message);
		//}
	}

	protected void clipboardButtionClicked (object sender, EventArgs e)
	{
		var atom = Gdk.Atom.Intern("CLIPBOARD", false);
		var clipboard = Gtk.Clipboard.Get(atom);
		clipboard.Text = this.outputLabel.Text;
	}
}
