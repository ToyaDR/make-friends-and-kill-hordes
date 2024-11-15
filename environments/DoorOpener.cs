using Godot;
using System;

public partial class DoorOpener : Interactable
{
    //load the player character into the next scene
	public string ScenePath;
    public override void PushButton()
    {
    	GetTree().ChangeSceneToFile(ScenePath);
    }
    public override void _Ready()
	{
		ScenePath = (string)GetMeta("ScenePath");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
