using System;

namespace SpriteSheetAnalyzer
{
	/// <summary>
	/// Contains information about a sprite sheet sequence fit.
	/// </summary>
	public class Fit
	{
		public int Offset;
		public int Width;
		
		public Fit(int offset, int width)
		{
			this.Offset = offset;
			this.Width = width;
		}
		
		public override string ToString()
		{
			return "offset = " + Offset.ToString() + ", width = " + Width.ToString();
		}
	}
}

