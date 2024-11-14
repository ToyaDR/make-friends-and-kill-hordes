using Godot;

public partial class GameManager : Node3D
{

  public override void _Ready()
  {
    SpellsLoader.LoadSpells();
  }
}