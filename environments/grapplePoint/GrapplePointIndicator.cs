using Godot;
using System;

public partial class GrapplePointIndicator : CanvasLayer
{
	GrapplePoint grapplePoint;
	ColorRect lockOn;
	static Color hoverColor = new(255, 0, 236, 1);
	static Color defaultColor = new(0, 0, 0, 1);
	public override void _Ready()
	{
		grapplePoint = GetParent<GrapplePoint>();
		lockOn = GetChild<Control>(0).GetChild<ColorRect>(0);
	}

	public void SetColor(bool isHovering)
	{
		if (isHovering)
		{
			lockOn.Color = hoverColor;
		}
		else
		{
			lockOn.Color = defaultColor;
		}

	}

	public override void _Process(double delta)
	{
		Camera3D camera = GetViewport().GetCamera3D();
		Vector3 parentPosition = grapplePoint.GlobalPosition;
		float distance = camera.GlobalPosition.DistanceTo(parentPosition);

		Vector2 unprojectedParentPosition = camera.UnprojectPosition(parentPosition + new Vector3(1 / (distance * distance), 1 / (distance * distance), 1));

		lockOn.GlobalPosition = unprojectedParentPosition;
		Visible = !camera.IsPositionBehind(parentPosition);
	}
}
