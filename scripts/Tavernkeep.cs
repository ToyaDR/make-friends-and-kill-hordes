using Godot;
using System;

public partial class Tavernkeep : Interactable
{
	// Called when the node enters the scene tree for the first time.
	private Dialogue DialogueBox;

	private DialogueTree TavernkeepDialogueTree;
	public override void _Ready()
	{
		DialogueBox = GetChild<Dialogue>(2);
		DialogueBox.Visible = true;
		TavernkeepDialogueTree = new TavernkeepDialogue().Tree; // TODO: save state in dialogue
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public override void Interact()
	{
		GD.Print("Interact with Tavernkeep");
		DialogueBox.Talk(TavernkeepDialogueTree.Start);
		DialogueBox.Visible = true;
	}
	public override void ExitInteraction()
	{
		GD.Print("ExitInteraction with Tavernkeep");
		DialogueBox.Visible = false;
	}
}
