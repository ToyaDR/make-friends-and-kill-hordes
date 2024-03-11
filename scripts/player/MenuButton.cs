using Godot;
using System;

public partial class MenuButton : BaseButton
{
	private string name;

	public override void _Ready()
	{
		string path = GetPath();
		string[] splitPath = path.Split("/");
		name = splitPath[splitPath.Length - 1];
	}

	public override void _Pressed()
	{
		GD.Print(name);
		if (name == "QuitGameButton")
		{
			GetTree().Quit();
		}
	}

	public override void _Process(double delta)
	{
	}
}
