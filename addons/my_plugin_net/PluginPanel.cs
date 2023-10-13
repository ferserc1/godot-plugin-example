using Godot;
using System;
using System.IO;
using bg2io;

[Tool]
public partial class PluginPanel : Control
{
	protected EditorSelection eds = null;
	protected FileDialog OpenFileDialog = null;
	
	public override void _Ready()
	{
		if (Engine.IsEditorHint()) {
			eds = new EditorPlugin().GetEditorInterface().GetSelection();
		}
	}
	
	private void _on_center_selection_button_pressed()
	{
		if (eds != null) {
			var sel = eds.GetSelectedNodes();
			foreach (Node node in sel) {
				if (node is Node2D) {
					(node as Node2D).Position = new Vector2(0.0f, 0.0f);
				}
				else if (node is Node3D) {
					(node as Node3D).Position = new Vector3(0.0f, 0.0f, 0.0f);
				}
			}
		}
	}
	
	private void _OnOpenFilePressed()
	{
		if (OpenFileDialog == null) {
			var dialog = new FileDialog();
			dialog.AddFilter("*.bg2");
			dialog.AddFilter("*.vwglb");
			dialog.Access = FileDialog.AccessEnum.Filesystem;
			dialog.FileMode = FileDialog.FileModeEnum.OpenFile;
			dialog.MinSize = new Vector2I(550, 450);
			this.AddChild(dialog);
			OpenFileDialog = dialog;
			dialog.FileSelected += _FileSelected;
		}
		OpenFileDialog.Show();
	}
	
	private void _FileSelected(string path)
	{
		GD.Print(path);
		
		Bg2FileReader fileReader = new Bg2FileReader();
		
		try {
			Bg2File bg2File = fileReader.Open(path);
			GD.Print("Version: " +  bg2File.GetVersion());
			GD.Print(bg2File.materialDataString);
		}
		catch (IOException err) {
			GD.Print("File input error: " + err.Message);
		}
		catch (bg2io.FormatException err) {
			GD.Print("File format error: " + err.Message);
		}
		catch (Exception err) {
			GD.Print(err.Message);
		}
	}
}




