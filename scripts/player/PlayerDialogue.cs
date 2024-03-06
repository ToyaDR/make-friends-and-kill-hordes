using Godot;
using System;

public partial class PlayerDialogue : Node3D
{
	public Camera3D Camera;

	public override void _Ready()
	{
		Camera3D camera = GetNode("Camera3D") as Camera3D;
		Input.MouseMode = Input.MouseModeEnum.Visible;
		Camera = camera;
	}

	public override void _Process(double delta)
	{
	}
}
