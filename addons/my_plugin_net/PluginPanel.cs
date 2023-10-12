using Godot;
using System;

[Tool]
public partial class PluginPanel : Control
{
	protected EditorSelection eds = null;
	
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
}


