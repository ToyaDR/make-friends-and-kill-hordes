using Godot;
using System;

public partial class Enemy : Node3D
{
	private float hitPoints;
	public float HitPoints { get => hitPoints; set => hitPoints = value; }

	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
	}
}
