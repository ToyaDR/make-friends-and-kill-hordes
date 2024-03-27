
using Godot;

public partial class Weapon : Area3D
{
  private int damage;

  public int Damage { get => damage; set => damage = value; }

  public override void _Ready()
  {
    Damage = 5;
  }

  public void OnBodyEnter(Node3D node)
  {
    if (node is Player)
    {
      DealDamage(node as Player);
    }
  }

  public virtual void DealDamage(Player player)
  {
    player.CurrentHitPoints -= Damage;
  }
}
