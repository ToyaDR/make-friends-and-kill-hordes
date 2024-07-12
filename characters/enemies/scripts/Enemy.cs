using Godot;
using System;

public partial class Enemy : RigidBody3D
{
	private HitPoints hitPoints;
	private EnemyHitPointsBar hitPointsBar;
	public EnemyHitPointsBar HPBar { get => hitPointsBar; set => hitPointsBar = value; }

	public void ReadyEnemy(string hitPointsBarPath, int totalHP)
	{
		if (hitPointsBarPath.Length > 0)
		{
			hitPoints = new HitPoints(totalHP);
			hitPointsBar = GetNode<EnemyHitPointsBar>(hitPointsBarPath);
			hitPointsBar.InitHitPointsBars(hitPoints);
		}
	}
	public override void _Ready()
	{
		ReadyEnemy("", 100);
	}

	public override void _Process(double delta)
	{
	}
}
