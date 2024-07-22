using Godot;
using System;

public partial class Enemy : RigidBody3D
{
	private HitPoints hitPoints;
	private EnemyHitPointsBar hitPointsBar;
	public EnemyHitPointsBar HPBar { get => hitPointsBar; set => hitPointsBar = value; }
	public int PoofTimer { get => poofTimer; set => poofTimer = value; }

	private int poofTimer = 100;

	private bool startPoofTimer = false;
	public bool StartPoofTimer { get => startPoofTimer; set => startPoofTimer = value; }

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

	public void HandlePoofing()
	{
		if (StartPoofTimer)
		{
			poofTimer -= 1;
			GD.Print(poofTimer);
		}

		if (poofTimer <= 0)
		{
			QueueFree();
		}
	}
	public override void _Process(double delta)
	{
	}
}
