using Godot;
using System;

public partial class PlayerCombatTest : PlayerCharacter
{
	AnimationPlayer animationPlayer;
	public override void _Ready()
	{
		animationPlayer = GetNode<AnimationPlayer>("PlayerCharacterPrefab/pc_arms_rig_04/AnimationPlayer");
		animationPlayer.SpeedScale = 1.5f;
		ReadyPlayerCharacter();
	}

	public override void _Process(double delta)
	{
		HandleMovement(delta);

		if (Mathf.RoundToInt(delta) % 1000 == 0)
		{
			TakeDamage(1);
		}
		if (Input.IsActionJustPressed("attack"))
		{
			animationPlayer.Play("swordSwing");
		}
	}
}
