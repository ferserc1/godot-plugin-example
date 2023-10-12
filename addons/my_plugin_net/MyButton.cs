using Godot;

[Tool]
public partial class MyButton : Button
{
	public override void _EnterTree()
	{
		// Conectar la señal Pressed con la función Clicked
		Pressed += Clicked;
	}

	public void Clicked()
	{
		GD.Print("You clicked me!");
	}
}
