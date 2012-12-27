using System;
using NUnit.Framework;

namespace SpriteSheetAnalyzer
{
	[TestFixture()]
	public class Tests
	{
		[Test()]
		public void TestExpandRectangle1()
		{
			var r = new Island(0, 0, 10, 10);
			Assert.True(SpriteSheetAnalyzer.Analyzer.ExpandRectangle(r, 1, 1));
			Assert.True(r.X == 0);
			Assert.True(r.Y == 0);
			Assert.True(r.Width == 10);
			Assert.True(r.Height == 10);
		}

		[Test()]
		public void TestExpandRectangle2()
		{
			var r = new Island(0, 0, 10, 10);
			Assert.True(SpriteSheetAnalyzer.Analyzer.ExpandRectangle(r, -1, 0));
			Assert.True(r.X == -1);
			Assert.True(r.Y == 0);
			Assert.True(r.Width == 11);
			Assert.True(r.Height == 10);
		}

		[Test()]
		public void TestExpandRectangle3()
		{
			var r = new Island(0, 0, 10, 10);
			Assert.True(SpriteSheetAnalyzer.Analyzer.ExpandRectangle(r, 0, -1));
			Assert.True(r.X == 0);
			Assert.True(r.Y == -1);
			Assert.True(r.Width == 10);
			Assert.True(r.Height == 11);
		}

		[Test()]
		public void TestExpandRectangle4()
		{
			var r = new Island(0, 0, 10, 10);
			Assert.True(SpriteSheetAnalyzer.Analyzer.ExpandRectangle(r, 10, 0));
			Assert.True(r.X == 0);
			Assert.True(r.Y == 0);
			Assert.True(r.Width == 11);
			Assert.True(r.Height == 10);
		}

		[Test()]
		public void TestExpandRectangle5()
		{
			var r = new Island(0, 0, 10, 10);
			Assert.True(SpriteSheetAnalyzer.Analyzer.ExpandRectangle(r, 0, 10));
			Assert.True(r.X == 0);
			Assert.True(r.Y == 0);
			Assert.True(r.Width == 10);
			Assert.True(r.Height == 11);
		}

		[Test()]
		public void TestExpandRectangle6()
		{
			var r = new Island(0, 0, 10, 10);
			Assert.True(!SpriteSheetAnalyzer.Analyzer.ExpandRectangle(r, -2, -2));
			Assert.True(r.X == 0);
			Assert.True(r.Y == 0);
			Assert.True(r.Width == 10);
			Assert.True(r.Height == 10);
		}

		[Test()]
		public void TestExpandRectangle7()
		{
			var r = new Island(0, 0, 10, 10);
			Assert.True(!SpriteSheetAnalyzer.Analyzer.ExpandRectangle(r, 20, 0));
			Assert.True(r.X == 0);
			Assert.True(r.Y == 0);
			Assert.True(r.Width == 10);
			Assert.True(r.Height == 10);
		}

		[Test()]
		public void TestExpandRectangle8()
		{
			var r = new Island(0, 0, 10, 10);
			Assert.True(!SpriteSheetAnalyzer.Analyzer.ExpandRectangle(r, 20, 20));
			Assert.True(r.X == 0);
			Assert.True(r.Y == 0);
			Assert.True(r.Width == 10);
			Assert.True(r.Height == 10);
		}

		[Test()]
		public void TestExpandRectangle9()
		{
			var r = new Island(0, 0, 10, 10);
			Assert.True(!SpriteSheetAnalyzer.Analyzer.ExpandRectangle(r, 0, 20));
			Assert.True(r.X == 0);
			Assert.True(r.Y == 0);
			Assert.True(r.Width == 10);
			Assert.True(r.Height == 10);
		}
	}
}

