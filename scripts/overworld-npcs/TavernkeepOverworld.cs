using Godot;
using System;

public partial class TavernkeepOverworld : Interactable
{
	public override void Interact()
	{
		GetTree().ChangeSceneToFile("res://scenes/tavern/TavernkeepDialogue.tscn");
	}
}
