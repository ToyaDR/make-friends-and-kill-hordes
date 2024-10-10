using Godot;
using System;

public partial class Interactable : StaticBody3D
{
	public void Hover(Label Prompter)
	{
		Prompter.Text = "Press Y to Interact";
	}
	public void LeaveHover(Label Prompter)
	{
		Prompter.Text = "";
	}
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
