using Godot;
using System;

public partial class AnxietyGremlin : Enemy
{
  public override void _Ready()
  {
    ReadyEnemy("HitPointsBar", 20);
  }

  public override void _Process(double delta)
  {
  }
}
