using Godot;
using System;

public partial class TavernkeepNoDialoguePrototype : Interactable
{
	public override void Interact()
	{
		GetTree().ChangeSceneToFile("res://scenes/Prototyping/SeparateDialogueScene.tscn");
	}
}
