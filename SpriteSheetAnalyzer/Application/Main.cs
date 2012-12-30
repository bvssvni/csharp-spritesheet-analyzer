using System;
using Gtk;

namespace SpriteSheetAnalyzer
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init ();
			// var win = new MainWindow ();
			var win = new MainWindow2();
			win.Show ();
			Application.Run ();
		}
	}
}
