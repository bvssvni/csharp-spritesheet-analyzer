using System;
using System.Collections.Generic;
using Gdk;

namespace SpriteSheetAnalyzer
{
	/// <summary>
	/// The App object stores the data and redirects messages.
	/// 
	/// The event UpdateInterface is triggered when there is a request to update.
	/// 
	/// The Should callback is used to check whether an action is allowed or not.
	/// </summary>
	public class App
	{
		// Fields.
		// These are used to communicate between different parts of the application.
		public string Filename;
		public string ErrorMessage;
		public string Task;
		public string Output;
		public Pixbuf Image;
		public List<Island> Islands;

		// An advisor detects whether an action is possible or not.
		public delegate bool AdvisorDelegate(Act action);
		public AdvisorDelegate Should;

		public event EventHandler<UIEventArgs> UpdateInterface;

		public App()
		{
		}

		/// <summary>
		/// Tell a part of the interface to refresh.
		/// </summary>
		/// <param name='ui'>
		/// The interface part to refresh.
		/// </param>
		public void UI(UI ui)
		{
			if (this.UpdateInterface != null) UpdateInterface(this, new UIEventArgs(ui));
		}

		/// <summary>
		/// Do an action.
		/// </summary>
		/// <param name='action'>
		/// Action.
		/// </param>
		public void Do(Act action)
		{
			if (!Should(action)) return;

			var app = this;
			switch (action) {
				case Act.AnalyzeHorizontal: AnalyzeAction.AnalyzeHorizontal(app); return;
				case Act.AnalyzeVertical: AnalyzeAction.AnalyzeVertical(app); return;
				case Act.AnalyzeIslands: AnalyzeAction.AnalyzeIslands(app); return;
				case Act.Analyze: AnalyzeAction.Analyze(app); return;
				case Act.Clean: CleanAction.Clean(app); return;
				case Act.RemoveBackground: RemoveBackgroundAction.RemoveBackground(app); return;
				case Act.CopyToClipboard: CopyToClipboardAction.CopyToClipboard(app); return;
				case Act.RefreshIslandsOutputAction: RefreshIslandsOutputAction.Refresh(app); return;
				case Act.Process: ProcessAction.Process(app); return;
			}

#if DEBUG
			throw new NotImplementedException(action.ToString());
#endif
		}
	}
}

