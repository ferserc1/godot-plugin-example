@tool
extends EditorPlugin

var dock
var bottomPanel

func _enter_tree():
	add_custom_type("PrintNode3D", "Node3D", preload("print_node_3d.gd"), preload("icon.png"))

	var ui = preload("res://addons/my_custom_node/custom_dock.tscn")
	dock = ui.instantiate()
	bottomPanel = ui.instantiate()
	
	add_control_to_dock(DOCK_SLOT_RIGHT_BL, dock)
	add_control_to_bottom_panel(bottomPanel, "My Plugin")

func _exit_tree():
	remove_custom_type("PrintNode3D")

	remove_control_from_docks(dock);
	dock.free()
	
	remove_control_from_bottom_panel(bottomPanel)
	bottomPanel.free()
