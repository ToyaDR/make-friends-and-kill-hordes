using System;
using Godot;

public partial class GameManager : Node
{
  public override void _Ready()
  {
    base._Ready();
    GD.Print("Set Mouse to captured");
    Input.MouseMode = Input.MouseModeEnum.Captured;
  }
}