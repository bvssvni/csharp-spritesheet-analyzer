using System;

namespace SpriteSheetAnalyzer
{
	public class CopyToClipboardAction
	{
		public static void CopyToClipboard(App app)
		{
			var atom = Gdk.Atom.Intern("CLIPBOARD", false);
			var clipboard = Gtk.Clipboard.Get(atom);
			clipboard.Text = app.Output;
		}
	}
}

