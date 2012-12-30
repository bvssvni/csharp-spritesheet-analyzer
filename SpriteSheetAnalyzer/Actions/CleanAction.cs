using System;

namespace SpriteSheetAnalyzer
{
	public class CleanAction
	{
		public static void Clean(App app)
		{
			if (app.Filename == null) return;
			if (app.Image == null) return;
			
			var img = app.Image;
			if (img == null) return;

			app.Task = "Clean";
			
			// Clean up islands with less than 50 alpha.
			CleanImageHelper helper = new CleanImageHelper();
			helper.Step1_SetImage(img);
			helper.Step2_SetMaxAlpha(50);
			helper.Step3_Clean();

			app.ErrorMessage = null;
			app.UI(UI.ErrorMessage);
			try {
				img.Save(app.Filename, "png");
			} catch (Exception ex) {
				app.ErrorMessage = ex.Message;
				app.UI(UI.ErrorMessage);
				Console.WriteLine(ex.ToString());
			}
			
			app.UI(UI.CompletedTask);

			app.Do(Act.Analyze);
		}
	}
}

