using Godot;
using System;

public partial class Tavernkeep : Interactable
{
	// Called when the node enters the scene tree for the first time.
	public Dialogue dialogueBox;
	public override void _Ready()
	{
		dialogueBox = GetChild<Dialogue>(2);
		dialogueBox.Visible = false;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public override void Interact()
	{
		GD.Print("Interact with Tavernkeep");
		dialogueBox.Talk();
		dialogueBox.Visible = true;
	}
	public override void ExitInteraction()
	{
		GD.Print("ExitInteraction with Tavernkeep");
		dialogueBox.Visible = false;
	}
}
