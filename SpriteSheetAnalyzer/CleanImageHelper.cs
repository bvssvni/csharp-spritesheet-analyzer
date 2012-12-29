using System;
using Gdk;

namespace SpriteSheetAnalyzer
{
	public class CleanImageHelper
	{
		private Pixbuf m_image;
		private byte m_maxAlpha;

		public void Step1_SetImage(Pixbuf image)
		{
			m_image = image;
		}

		public void Step2_SetMaxAlpha(byte alpha)
		{
			m_maxAlpha = alpha;
		}

		/// <summary>
		/// Finds the maximum alpa within an island.
		/// </summary>
		/// <returns>
		/// The max alpha value found in island.
		/// </returns>
		/// <param name='buf'>
		/// The image to containing the island.
		/// </param>
		/// <param name='rect'>
		/// A region to check for maximum alpha.
		/// </param>
		private static byte FindMaxAlpha(Pixbuf buf, Island rect)
		{
			// Make sure not to read and write outside the image.
			var clip = Island.Clip(rect, new Island(0, 0, buf.Width, buf.Height));
			byte max = 0;
			unsafe {
				byte* start = (byte*)buf.Pixels;
				int stride = buf.Rowstride;
				int startX = clip.X;
				int startY = clip.Y;
				int endX = clip.X + clip.Width;
				int endY = clip.Y + clip.Height;
				for (int y = startY; y < endY; y++) {
					for (int x = startX; x < endX; x++) {
						byte* current = start + 4 * x + y * stride;
						byte alpha = current[3];
						if (alpha > max) max = alpha;
					}
				}
			}
			return max;
		}

		/// <summary>
		/// Erase an island from image.
		/// </summary>
		/// <param name='buf'>
		/// The image to erase the island from.
		/// </param>
		/// <param name='rect'>
		/// An island to erase all pixels.
		/// </param>
		private static byte Erase(Pixbuf buf, Island rect)
		{
			// Make sure not to read and write outside the image.
			var clip = Island.Clip(rect, new Island(0, 0, buf.Width, buf.Height));
			byte max = 0;
			unsafe {
				byte* start = (byte*)buf.Pixels;
				int stride = buf.Rowstride;
				int startX = clip.X;
				int startY = clip.Y;
				int endX = clip.X + clip.Width;
				int endY = clip.Y + clip.Height;
				for (int y = startY; y < endY; y++) {
					for (int x = startX; x < endX; x++) {
						byte* current = start + 4 * x + y * stride;
						current[0] = current[1] = current[2] = current[3] = 0;
					}
				}
			}
			return max;
		}

		public void Step3_Clean()
		{
			Pixbuf img = m_image;
			var islands = Analyzer.FindIslands(img);
			byte maxAlpha = m_maxAlpha;
			foreach (var a in islands) {
				byte alpha = FindMaxAlpha(m_image, a);
				Console.WriteLine(alpha.ToString());
				if (alpha >= maxAlpha)  continue;

				Console.WriteLine("Erasing");
				Erase(img, a);
			}
		}
	}
}

