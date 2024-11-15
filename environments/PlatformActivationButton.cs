using Godot;
using System;

public partial class PlatformActivationButton : Interactable
{
	ElevatorPlatform elevatorPlatform;
	AnimationPlayer animationPlayer;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// elevatorPlatform = GetNode<ElevatorPlatform>("root/Ballastgrayboxlevel/ElevatorPlatform");
		string elevatorPath = (string)GetMeta("LiftPath");
		elevatorPlatform = GetNode<ElevatorPlatform>(elevatorPath);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}
}
