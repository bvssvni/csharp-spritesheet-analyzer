using System;

namespace SpriteSheetAnalyzer
{
	/// <summary>
	/// Used to communicate request for updating a part of user interface.
	/// </summary>
	public class UIEventArgs : EventArgs
	{
		private UI m_ui;
		
		public UI UI
		{
			get {
				return m_ui;
			}
		}
		
		public UIEventArgs(UI appEvent)
		{
			m_ui = appEvent;
		}
	}
}

