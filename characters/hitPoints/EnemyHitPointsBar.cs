using Godot;
using System;

public partial class EnemyHitPointsBar : CanvasLayer
{
	private ColorRect currentHitPointsBar;
	private ColorRect totalHitPointsBar;

	private HitPoints hitPointsValue;
	private int barHeight = 20;
	private int mult = 4;
	private Vector3 offset = new Vector3(1, 1, 1);

	public HitPoints HitPointsValue { get => hitPointsValue; set => hitPointsValue = value; }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		currentHitPointsBar = GetNode<ColorRect>("CurrentHitPoints");
		currentHitPointsBar.SetSize(new Vector2(0, barHeight));

		totalHitPointsBar = GetNode<ColorRect>("TotalHitPoints");
		totalHitPointsBar.SetSize(new Vector2(0, barHeight));
	}

	public void InitHitPointsBars(HitPoints hpValue)
	{
		hitPointsValue = hpValue;
		currentHitPointsBar.SetSize(new Vector2(hitPointsValue.CurrentHitPoints * mult, barHeight));
		totalHitPointsBar.SetSize(new Vector2(hitPointsValue.TotalHitPoints * mult, barHeight));
	}

	public void TakeDamage(int damage)
	{
		if (hitPointsValue == null)
		{
			GD.Print("Set value for HitPointsBar");
			return;
		}

		if (hitPointsValue.CurrentHitPoints <= 0) return;

		int updatedCurrentHitPoints = hitPointsValue.TakeDamage(damage);
		currentHitPointsBar.SetSize(new Vector2(updatedCurrentHitPoints * mult, barHeight));
	}

	public void ReceiveHealing(int hitPoints)
	{
		if (hitPointsValue == null)
		{
			GD.Print("Set value for HitPointsBar");
			return;
		}

		if (hitPointsValue.CurrentHitPoints >= hitPointsValue.TotalHitPoints)
		{
			return;
		}

		int updatedCurrentHitPoints = hitPointsValue.ReceiveHealing(hitPoints);
		currentHitPointsBar.SetSize(new Vector2(updatedCurrentHitPoints * mult, barHeight));
	}

	public override void _Process(double delta)
	{
		Camera3D camera = GetViewport().GetCamera3D();
		Vector3 parentPosition = GetParent<RigidBody3D>().GlobalPosition;
		float distance = camera.GlobalPosition.DistanceTo(parentPosition);

		Vector2 unprojectedParentPosition = camera.UnprojectPosition(parentPosition + new Vector3(1 / (distance * distance), 1 / (distance * distance), 1));

		currentHitPointsBar.GlobalPosition = unprojectedParentPosition;
		totalHitPointsBar.GlobalPosition = unprojectedParentPosition;
		Visible = !camera.IsPositionBehind(parentPosition);
	}
}
