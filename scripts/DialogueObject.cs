

using System;
using Godot;

public partial class DialogueObject : Node
{

  public bool canBePickedUp = false;
  public Label3D text;

  public override void _Ready()
  {
    base._Ready();
    text = GetNode<Label3D>("Label3D");
  }

  public virtual void PickUp()
  {
    GD.Print("PickUp");
  }

  public virtual void PutBack()
  {
    GD.Print("PutBack");
  }
}