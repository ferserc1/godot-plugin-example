@tool
extends PrintNode3D

var elapsed : float = 0.0

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta: float):
	elapsed = elapsed + delta
	position.x = sin(elapsed)
	position.y = cos(elapsed)
	super(delta)
