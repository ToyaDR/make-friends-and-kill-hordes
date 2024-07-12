using Godot;
using System;

public partial class AnxietyGremlinCombatTest : Enemy
{
  public override void _Ready()
  {
	ReadyEnemy("AnxietyGremlinPrefab/HitPointsBar", 20);
  }

  public override void _Process(double delta)
  {
  }
}
