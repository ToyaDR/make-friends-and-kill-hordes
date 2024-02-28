using System;
using Godot;

public partial class Location : StaticBody3D
{
  static Color hoverColor = new(255, 0, 236, 1);
  static Color defaultColor = new(0, 0, 0, 1);
  private Label3D label;
  public override void _Ready()
  {
    label = GetNode<Label3D>("Label3D");
  }


  public override void _MouseEnter()
  {
    label.OutlineModulate = hoverColor;
  }

  public override void _MouseExit()
  {
    label.OutlineModulate = defaultColor;
  }

  public override void _Process(double delta)
  {
  }
}