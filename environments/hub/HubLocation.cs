using Godot;
using System;

public partial class HubLocation : Area3D
{
	public override void _Ready()
	{
	}

	public override void _MouseEnter()
	{
		GD.Print("MOUSE ENTER");
	}
}
