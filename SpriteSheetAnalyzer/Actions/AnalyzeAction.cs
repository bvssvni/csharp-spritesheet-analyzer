using System;
using System.Text;
using Gdk;
using Utils;

namespace SpriteSheetAnalyzer
{
	public class AnalyzeAction
	{
		public static void Analyze(App app)
		{
			if (app.Filename == null) return;
			
			// Analyze the sprite sheet and show fit options.
			string filename = app.Filename;
			app.Output = "(no output)";
			app.UI(UI.Output);
			app.UI(UI.Filename);

			app.Islands = null;
			app.Image = null;
			app.ErrorMessage = null;
			app.UI(UI.ErrorMessage);
			try {
				var buf = new Pixbuf(filename);
				app.Image = buf;
				app.Do(Act.AnalyzeHorizontal);
				app.Do(Act.AnalyzeVertical);
				app.Do(Act.AnalyzeIslands);
			}
			catch (Exception ex) {
				app.ErrorMessage = ex.Message;
				app.UI(UI.ErrorMessage);
				Console.WriteLine(ex.ToString());
			}
			
			// Update the island editor.
			app.UI(UI.IslandEditor);
			app.UI(UI.CompletedTask);
		}

		public static void AnalyzeHorizontal(App app)
		{
			app.Task = "Analyze horizontal";
			var list = SpriteAnalyzer.FindFit(SpriteAnalyzer.TransparentColumns(app.Image));
			if (list.Count == 0) {
				app.Output = "(Did not found any sprite frames)";
				app.UI(UI.Output);
				return;
			}

			var strb = new StringBuilder();
			for (int i = 0; i < list.Count; i++) {
				strb.Append("{");
				strb.Append(list[i].ToString());
				strb.Append("}\n");
			}
			app.Output = strb.ToString();
			app.UI(UI.Output);
			app.UI(UI.CompletedTask);
		}

		public static void AnalyzeVertical(App app)
		{
			app.Task = "Analyze vertical";
			var list = SpriteAnalyzer.FindFit(SpriteAnalyzer.TransparentRows(app.Image));
			if (list.Count == 0) {
				app.Output = "(Did not found any sprite frames)";
				app.UI(UI.Output);
				return;
			}

			var strb = new StringBuilder();
			for (int i = 0; i < list.Count; i++) {
				strb.Append("{");
				strb.Append(list[i].ToString());
				strb.Append("}\n");
			}
			app.Output = strb.ToString();
			app.UI(UI.Output);
			app.UI(UI.CompletedTask);
		}

		public static void AnalyzeIslands(App app)
		{
			var rectangles = SpriteAnalyzer.FindIslands(app.Image);
			if (rectangles.Count == 0) {
				app.Output = "(Did not found any island)";
				app.UI(UI.Output);
				return;
			}

			app.Task = "Analyze islands";
			app.Islands = rectangles;
			app.Do(Act.RefreshIslandsOutputAction);
			app.UI(UI.CompletedTask);
		}
	}
}

