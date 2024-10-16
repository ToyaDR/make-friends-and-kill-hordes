using Godot;
using System;

public partial class ElevatorPlatform : CsgCombiner3D
{
	AnimationPlayer PlatformMove;
	Label Prompter;
	
	public void LiftUp()
	{
		PlatformMove.Play("UpandDown");
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{	
		PlatformMove =  GetNode<AnimationPlayer>("ElevatorPlatform");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}
}
