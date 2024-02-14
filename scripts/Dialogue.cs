using Godot;
using System;

public partial class Dialogue : DialogueObject
{
	// Called when the node enters the scene tree for the first time.

	public override void _Ready()
	{
		canBePickedUp = false;
		text = GetChild<Label3D>(0);
	}

	public void Talk()
	{
		text.Text = "Placeholder until I get this json working";
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
