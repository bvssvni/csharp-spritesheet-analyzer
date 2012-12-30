using System;

namespace SpriteSheetAnalyzer
{
	public class ProcessAction
	{
		public static void Process(App app)
		{
			app.Do(Act.Clean);
			app.Do(Act.RemoveBackground);
		}
	}
}

