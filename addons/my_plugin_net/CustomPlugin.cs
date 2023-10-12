#if TOOLS
using Godot;

[Tool]
public partial class CustomPlugin : EditorPlugin
{
	private Control _panel;
	
	public override void _EnterTree()
	{
		var script = GD.Load<Script>("res://addons/my_plugin_net/MyButton.cs");
		var icon = GD.Load<Texture2D>("res://addons/my_plugin_net/icon.png");
		AddCustomType("MyButton", "Button", script, icon);

		_panel = GD.Load<PackedScene>("res://addons/my_plugin_net/PluginPanel.tscn").Instantiate<Control>();
		AddControlToBottomPanel(_panel, "My Custom Plugin");
		
		GD.Print("CustomPlugin loaded");
	}

	public override void _ExitTree()
	{
		RemoveCustomType("MyButton");
		
		RemoveControlFromBottomPanel(_panel);
		_panel.Free();
	}

}
#endif
