using System;
using Godot;

public partial class GameManager : Node
{
  public override void _Ready()
  {
    GD.Print("Set Mouse to captured");
    // Input.MouseMode = Input.MouseModeEnum.Captured;
  }

  public override void _Process(double delta)
  {
    if (Input.IsActionJustPressed("open_map"))
    {
      GetTree().ChangeSceneToFile("res://scenes/Map.tscn");
    }
  }
}