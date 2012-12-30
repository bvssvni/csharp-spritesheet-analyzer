using System;

namespace SpriteSheetAnalyzer
{
	public class RemoveBackgroundAction
	{
		public static void RemoveBackground(App app)
		{
			if (app.Filename == null) return;
			if (app.Image == null) return;
			
			var img = app.Image;
			if (img == null) return;

			app.Task = "Remove background color";
			
			var helper = new RemoveBackgroundColorHelper();
			helper.Step1_SetImage(img);
			helper.Step2_SetDetectByFirstRow();
			helper.Step3_RemoveBackground();

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

			AnalyzeAction.Analyze(app);
		}
	}
}

