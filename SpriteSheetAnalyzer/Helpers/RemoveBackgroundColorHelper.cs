using System;
using System.Collections.Generic;
using Gdk;

namespace SpriteSheetAnalyzer
{
	public class RemoveBackgroundColorHelper
	{
		private Pixbuf m_image;

		public void Step1_SetImage(Pixbuf image)
		{
			m_image = image;
		}

		public void Step2_SetDetectByFirstRow()
		{
			// Do nothing, as there is no other options.
		}

		public void Step3_RemoveBackground()
		{
			Color color = RemoveBackground.DetectColorByFirstRow(m_image);
			RemoveBackground.Remove(m_image, color);
		}
	}
}

