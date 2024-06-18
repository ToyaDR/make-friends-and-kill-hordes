using Godot;
using System;

public partial class PlayerCombatTest : PlayerCharacter
{
	AnimationPlayer animationPlayer;
	public override void _Ready()
	{
		animationPlayer = GetNode<AnimationPlayer>("PlayerCharacterPrefab/pc_arms_rig_v4/AnimationPlayer");
		ReadyPlayerCharacter();
	}

	public override void _Process(double delta)
	{
		HandleMovement(delta);
		if (Input.IsActionJustPressed("attack"))
		{
			animationPlayer.Play("pc_anims_v1/playerCharacter_rigAction_001");
		}
	}
}
