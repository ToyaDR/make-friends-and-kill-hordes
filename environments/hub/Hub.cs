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
	}
	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseMotion)
		{
			InputEventMouseMotion mouseEvent = @event as InputEventMouseMotion;

			Vector3 cameraPosition = Camera.GlobalTransform.Origin;

			float translatedX = mouseEvent.Position.X + cameraPosition.X;
			float translatedY = mouseEvent.Position.Y + cameraPosition.Y;

			float clampedX = mouseEvent.Position.X;
			float clampedY = mouseEvent.Position.Y;
			if (translatedX > maxX || translatedX < minX)
			{
				clampedX = 0;
			}

			if (translatedY > maxY || translatedY < minY)
			{
				clampedX = 0;
			}
			Camera.Translate(new Vector3(clampedX * mouseSensitivityX, -clampedY * mouseSensitivityY, 5.325f));
		}
	}
	public override void _Process(double delta)
	{
	}
}
