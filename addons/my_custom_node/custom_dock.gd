@tool
extends Control

var eds = null

func _ready():
	if Engine.is_editor_hint():
		eds = EditorPlugin.new().get_editor_interface().get_selection()

func _on_button_pressed():
	print("Hello from the custom panel")
	if eds:
		var sel = eds.get_selected_nodes()
		for i in sel:
			i.position.x = 0
			i.position.y = 0
			i.position.z = 0
	
