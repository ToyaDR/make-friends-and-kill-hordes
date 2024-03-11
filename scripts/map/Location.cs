using System;
using System.Collections.Generic;
using Godot;

public partial class Location : StaticBody3D
{

  static Dictionary<string, string> locationToScene = new Dictionary<string, string>{
    {
      "Temple", "res://scenes/locations/Temple.tscn"
    },
    {
      "Tavern", "res://scenes/locations/Tavern.tscn"
    },
    {
      "Library", "res://scenes/locations/Library.tscn"
    },
    {
      "Camp", "res://scenes/locations/Camp.tscn"
    }
  };
  static Color hoverColor = new(255, 0, 236, 1);
  static Color defaultColor = new(0, 0, 0, 1);
  private Label3D label;
  private bool isHovering;

  private string name = "Placeholder";

  public override void _Ready()
  {
    label = GetNode<Label3D>("Label3D");
    isHovering = false;

    if (label != null)
    {
      string path = GetPath();
      string[] splitPath = path.Split("/");
      name = splitPath[splitPath.Length - 1];
    }
  }

  public override void _Input(InputEvent @event)
  {
    if (isHovering && @event is InputEventMouseButton)
    {
      GetTree().ChangeSceneToFile(locationToScene[name]);
    }
  }
  public override void _MouseEnter()
  {
    label.OutlineModulate = hoverColor;
    isHovering = true;
  }

  public override void _MouseExit()
  {
    label.OutlineModulate = defaultColor;
    isHovering = false;
  }

  public override void _Process(double delta)
  {
  }
}