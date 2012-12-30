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

		/// <summary>
		/// Runs through the first row and picks the color that appears most frequently.
		/// </summary>
		/// <returns>
		/// Returns the most common color in first row in iage.
		/// </returns>
		/// <param name='image'>
		/// The image to analyze for background color.
		/// </param>
		private static Color DetectColorByFirstRow(Pixbuf image)
		{
			var hash = new Dictionary<int, int>();
			unsafe {
				byte* start = (byte*)image.Pixels;
				int w = image.Width;
				for (int x = 0; x < w; x++) {
					byte* current = start + 4 * x;
					int red = current[0];
					int green = current[1];
					int blue = current[2];
					int alpha = current[3];
					if (alpha == 0) continue;

					int argb = (red << 16) | (green << 8) | blue;
					if (hash.ContainsKey(argb)) {
						hash[argb]++;
					} else {
						hash[argb] = 1;
					}
				}
			}

			int max = int.MinValue;
			int maxColor = 0;
			foreach (var item in hash) {
				if (item.Value > max) {
					max = item.Value;
					maxColor = item.Key;
				}
			}

			// TEST
			Console.WriteLine(max.ToString());

			byte cred = (byte)((maxColor >> 16) & 0xff);
			byte cgreen = (byte)((maxColor >> 8) & 0xff);
			byte cblue = (byte)((maxColor) & 0xff);
			return new Color(cred, cgreen, cblue);
		}

		public void Step2_SetDetectByFirstRow()
		{
			// Do nothing, as there is no other options.
		}

		/// <summary>
		/// Removes the background color of an image and replaces it with transparency.
		/// </summary>
		/// <param name='image'>
		/// The image to remove background color.
		/// </param>
		/// <param name='color'>
		/// The background color to remove.
		/// </param>
		private static void RemoveBackground(Pixbuf image, Color color)
		{
			byte r = (byte)color.Red;
			byte g = (byte)color.Green;
			byte b = (byte)color.Blue;
			unsafe {
				byte* start = (byte*)image.Pixels;
				int stride = image.Rowstride;
				int w = image.Width;
				int h = image.Height;
				for (int y = 0; y < h; y++) {
					for (int x = 0; x < w; x++) {
						byte* current = start + 4 * x + stride * y;
						if (current[3] > 0) continue;
						if (current[0] == r && current[1] == g && current[2] == b) {
							current[0] = current[1] = current[2] = current[3] = 0;
						}
					}
				}
			}
		}

		public void Step3_RemoveBackground()
		{
			var color = DetectColorByFirstRow(m_image);
			// TEST
			Console.WriteLine("Red " + color.Red);
			Console.WriteLine("Green " + color.Green);
			Console.WriteLine("Blue " + color.Blue);

			RemoveBackground(m_image, color);
		}
	}
}

