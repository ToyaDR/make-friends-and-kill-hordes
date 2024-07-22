using Godot;
using System;

public partial class Sword : CharacterBody3D
{
  private int damage = 5;

  public int Damage { get => damage; set => damage = value; }

  public override void _Ready()
  {
  }
}