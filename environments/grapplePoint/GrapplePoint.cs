using Godot;
using System;

public partial class GrapplePoint : StaticBody3D
{
	public Vector3 grappleLocation;
	public GrapplePointIndicator lockOn;
	public override void _Ready()
	{
		grappleLocation = GlobalPosition;
		lockOn = GetChild<GrapplePointIndicator>(0);
	}

	public void Hover()
	{
		lockOn.SetColor(true);
	}

	public void LeaveHover()
	{
		lockOn.SetColor(false);
	}

	public override void _Process(double delta)
	{
	}
}
