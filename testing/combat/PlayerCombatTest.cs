using Godot;
using System;

public partial class PlayerCombatTest : PlayerCharacter
{
	AnimationPlayer animationPlayer;
	private bool takeDamage = false;
	public override void _Ready()
	{
		animationPlayer = GetNode<AnimationPlayer>("PlayerCharacterPrefab/pc_arms_rig_v6/AnimationPlayer");
		animationPlayer.SpeedScale = 1.5f;
		ReadyPlayerCharacter();
		takeDamage = true;
	}

	public override void _Process(double delta)
	{
		HandleMovement(delta);
		HandleInteraction();

		SwapItem();

		if (Mathf.RoundToInt(delta) % 1000 == 0 && HPBar.HitPointsValue.CurrentHitPoints > 50 && takeDamage)
		{
			TakeDamage(1);
		}
		if (Input.IsActionJustPressed("attack_or_heal"))
		{
			if (CurrentItem == "Sword")
			{
				animationPlayer.Play("swordSwing");
			}

			if (CurrentItem == "Heal")
			{
				animationPlayer.Play("healingSpell");
				takeDamage = false;
				HPBar.ReceiveHealing(25);
			}
		}
	}
}
