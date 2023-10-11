# No es necesario, pero esto facilitará ver los cambios sin 
# tener que ejecutar el juego
@tool
extends Node3D
# No es necesario definir el nombre de clase, pero facilita
# algunas cosas más tarde, como extender la clase
class_name PrintNode3D

var timeElapsed : float = 0.0

func _process(delta):
	timeElapsed += delta
	if timeElapsed > 1.0:
		print("x: ", position.x, ", y: ", position.y, ", z: ", position.z)
		timeElapsed = 0.0
