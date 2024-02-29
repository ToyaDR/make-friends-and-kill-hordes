using Godot;
using System;

public partial class Map : Node3D
{
	public override void _Ready()
	{
		GD.Print("Set Mouse to visible");
		Input.MouseMode = Input.MouseModeEnum.Visible;
	}

	public override void _Process(double delta)
	{
	}
}
