using Godot;
using System;

public partial class AnxietyGremlin : Enemy
{
  public override void _Ready()
  {
    ReadyEnemy("HitPointsBar", 20);
    ContactMonitor = true;
    MaxContactsReported = 5;
    BodyEntered += OnBodyEntered;
  }

  public override void _Process(double delta)
  {
    HandlePoofing();
  }

  private void OnBodyEntered(Node body)
  {
    PhysicsBody3D physicsBody = body as PhysicsBody3D;
    bool isWeapon = Utilities.IsInCollisionLayer(4, physicsBody.CollisionLayer);

    if (isWeapon)
    {
      Sword sword = body as Sword;
      HPBar.TakeDamage(sword.Damage);

      if (HPBar.HitPointsValue.CurrentHitPoints <= 0)
      {
        StartPoofTimer = true;
      }
    }
  }
}
