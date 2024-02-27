using Godot;
using System;

public partial class Map : Node3D
{

	private Camera3D camera;

	public override void _Ready()
	{
		camera = GetNode<Camera3D>("Camera3D");
	}

	public override void _Process(double delta)
	{
	}
}
