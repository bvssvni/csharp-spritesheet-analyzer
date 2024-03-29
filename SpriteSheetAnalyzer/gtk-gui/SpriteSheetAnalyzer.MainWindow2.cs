
// This file has been generated by the GUI designer. Do not modify.
namespace SpriteSheetAnalyzer
{
	public partial class MainWindow2
	{
		private global::Gtk.VBox vbox1;
		private global::Gtk.HBox hbox1;
		private global::Gtk.FileChooserButton filechooserbuttonOpen;
		private global::Gtk.ComboBox comboboxMode;
		private global::Gtk.VSeparator vseparator1;
		private global::Gtk.ComboBox comboboxProcess;
		private global::Gtk.Button buttonProcess;
		private global::Gtk.HPaned hpaned1;
		private global::Gtk.ScrolledWindow GtkScrolledWindow;
		private global::Gtk.TextView textviewOutput;
		private global::Gtk.ScrolledWindow GtkScrolledWindow1;
		private global::SpriteSheetAnalyzer.IslandEditor islandeditor1;
		private global::Gtk.Statusbar statusbar1;
		
		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget SpriteSheetAnalyzer.MainWindow2
			this.Name = "SpriteSheetAnalyzer.MainWindow2";
			this.Title = global::Mono.Unix.Catalog.GetString ("SpriteSheetAnalyzer 0.001");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			this.AllowShrink = true;
			// Container child SpriteSheetAnalyzer.MainWindow2.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox ();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			this.vbox1.BorderWidth = ((uint)(8));
			// Container child vbox1.Gtk.Box+BoxChild
			this.hbox1 = new global::Gtk.HBox ();
			this.hbox1.Name = "hbox1";
			this.hbox1.Spacing = 6;
			// Container child hbox1.Gtk.Box+BoxChild
			this.filechooserbuttonOpen = new global::Gtk.FileChooserButton (global::Mono.Unix.Catalog.GetString ("Select a File"), ((global::Gtk.FileChooserAction)(0)));
			this.filechooserbuttonOpen.Name = "filechooserbuttonOpen";
			this.hbox1.Add (this.filechooserbuttonOpen);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.filechooserbuttonOpen]));
			w1.Position = 0;
			// Container child hbox1.Gtk.Box+BoxChild
			this.comboboxMode = global::Gtk.ComboBox.NewText ();
			this.comboboxMode.AppendText (global::Mono.Unix.Catalog.GetString ("Horizontal"));
			this.comboboxMode.AppendText (global::Mono.Unix.Catalog.GetString ("Vertical"));
			this.comboboxMode.AppendText (global::Mono.Unix.Catalog.GetString ("Islands"));
			this.comboboxMode.Name = "comboboxMode";
			this.hbox1.Add (this.comboboxMode);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.comboboxMode]));
			w2.Position = 1;
			w2.Expand = false;
			w2.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.vseparator1 = new global::Gtk.VSeparator ();
			this.vseparator1.Name = "vseparator1";
			this.hbox1.Add (this.vseparator1);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.vseparator1]));
			w3.Position = 2;
			w3.Expand = false;
			w3.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.comboboxProcess = global::Gtk.ComboBox.NewText ();
			this.comboboxProcess.AppendText (global::Mono.Unix.Catalog.GetString ("Clean"));
			this.comboboxProcess.AppendText (global::Mono.Unix.Catalog.GetString ("Remove Background Color"));
			this.comboboxProcess.Name = "comboboxProcess";
			this.hbox1.Add (this.comboboxProcess);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.comboboxProcess]));
			w4.Position = 3;
			w4.Expand = false;
			w4.Fill = false;
			// Container child hbox1.Gtk.Box+BoxChild
			this.buttonProcess = new global::Gtk.Button ();
			this.buttonProcess.CanFocus = true;
			this.buttonProcess.Name = "buttonProcess";
			this.buttonProcess.UseUnderline = true;
			this.buttonProcess.Label = global::Mono.Unix.Catalog.GetString ("Process");
			this.hbox1.Add (this.buttonProcess);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.hbox1 [this.buttonProcess]));
			w5.Position = 4;
			w5.Expand = false;
			w5.Fill = false;
			this.vbox1.Add (this.hbox1);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hbox1]));
			w6.Position = 0;
			w6.Expand = false;
			w6.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.hpaned1 = new global::Gtk.HPaned ();
			this.hpaned1.CanFocus = true;
			this.hpaned1.Name = "hpaned1";
			this.hpaned1.Position = 258;
			// Container child hpaned1.Gtk.Paned+PanedChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.textviewOutput = new global::Gtk.TextView ();
			this.textviewOutput.Buffer.Text = "(no output)";
			this.textviewOutput.CanFocus = true;
			this.textviewOutput.Name = "textviewOutput";
			this.textviewOutput.Editable = false;
			this.GtkScrolledWindow.Add (this.textviewOutput);
			this.hpaned1.Add (this.GtkScrolledWindow);
			global::Gtk.Paned.PanedChild w8 = ((global::Gtk.Paned.PanedChild)(this.hpaned1 [this.GtkScrolledWindow]));
			w8.Resize = false;
			// Container child hpaned1.Gtk.Paned+PanedChild
			this.GtkScrolledWindow1 = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow1.Name = "GtkScrolledWindow1";
			this.GtkScrolledWindow1.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow1.Gtk.Container+ContainerChild
			global::Gtk.Viewport w9 = new global::Gtk.Viewport ();
			w9.ShadowType = ((global::Gtk.ShadowType)(0));
			// Container child GtkViewport.Gtk.Container+ContainerChild
			this.islandeditor1 = new global::SpriteSheetAnalyzer.IslandEditor ();
			this.islandeditor1.Name = "islandeditor1";
			w9.Add (this.islandeditor1);
			this.GtkScrolledWindow1.Add (w9);
			this.hpaned1.Add (this.GtkScrolledWindow1);
			this.vbox1.Add (this.hpaned1);
			global::Gtk.Box.BoxChild w13 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.hpaned1]));
			w13.Position = 1;
			// Container child vbox1.Gtk.Box+BoxChild
			this.statusbar1 = new global::Gtk.Statusbar ();
			this.statusbar1.Name = "statusbar1";
			this.statusbar1.Spacing = 6;
			this.vbox1.Add (this.statusbar1);
			global::Gtk.Box.BoxChild w14 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.statusbar1]));
			w14.Position = 2;
			w14.Expand = false;
			w14.Fill = false;
			this.Add (this.vbox1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 654;
			this.DefaultHeight = 300;
			this.Show ();
			this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.windowDeleted);
			this.filechooserbuttonOpen.SelectionChanged += new global::System.EventHandler (this.selectedFileChanged);
			this.comboboxMode.Changed += new global::System.EventHandler (this.modeChanged);
			this.buttonProcess.Clicked += new global::System.EventHandler (this.processClicked);
		}
	}
}
