using Godot;
using System;

public partial class PlayerCombatTest : PlayerCharacter
{
	AnimationPlayer animationPlayer;
	public override void _Ready()
	{
		animationPlayer = GetNode<AnimationPlayer>("Medieval/AnimationPlayer");
		ReadyPlayerCharacter();
	}

	public override void _Process(double delta)
	{
		HandleMovement(delta);
		if (Input.IsActionJustPressed("attack"))
		{
			animationPlayer.Play("Sword_Slash");
		}
	}
}
