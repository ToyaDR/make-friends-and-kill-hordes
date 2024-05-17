using Godot;
using System;

public partial class Hub : Node3D
{

	public float mouseSensitivityY = 0.003f;
	public float mouseSensitivityX = 0.003f;

	public float maxX = 8f;
	public float minX = 4f;

	public float maxY = 8f;
	public float minY = 4f;

	public Camera3D Camera;
	public override void _Ready()
	{
		Camera3D camera = GetNode("Camera3D") as Camera3D;
		Camera = camera;
		Input.MouseMode = Input.MouseModeEnum.Confined;
	}
	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseMotion)
		{
			InputEventMouseMotion mouseEvent = @event as InputEventMouseMotion;
			Camera.Translate(new Vector3(mouseEvent.Relative.X * mouseSensitivityX, -mouseEvent.Relative.Y * mouseSensitivityY, 0));
		}
	}
	public override void _Process(double delta)
	{
	}
}
