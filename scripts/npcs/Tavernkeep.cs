using Godot;
using System;

public partial class Tavernkeep : StaticBody3D
{
	// Called when the node enters the scene tree for the first time.
	private Dialogue DialogueBox;

	private DialogueTree TavernkeepDialogueTree;
	public override void _Ready()
	{
		DialogueBox = GetChild<Dialogue>(2);
		TavernkeepDialogueTree = new TavernkeepDialogue().Tree; // TODO: save state in dialogue
		DialogueBox.Talk(TavernkeepDialogueTree.Start);
	}
}
