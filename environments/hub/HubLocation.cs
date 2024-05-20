using Godot;
using System;
using System.Collections.Generic;

public partial class HubLocation : Area3D
{
	static Dictionary<string, string> locationToScene = new Dictionary<string, string>{
	{
	  "Chapel", "res://environments/hub/rooms/chapel.tscn"
	},
	{
	  "Grounds", "res://environments/hub/rooms/grounds.tscn"
	},
	{
	  "Kitchen", "res://environments/hub/rooms/kitchen.tscn"
	},
	{
	  "Library", "res://environments/hub/rooms/library.tscn"
	},
	{
	  "Camp", "res://environments/hub/rooms/camp.tscn"
	},
  };
	private string name = "Placeholder";
	private bool isHovering = false;

	public override void _Ready()
	{
		isHovering = false;

		string path = GetPath();
		string[] splitPath = path.Split("/");
		name = splitPath[splitPath.Length - 1];
	}

	public override void _Input(InputEvent @event)
	{
		if (isHovering && @event is InputEventMouseButton)
		{
			GetTree().ChangeSceneToFile(locationToScene[name]);
		}
	}
	public override void _MouseEnter()
	{
		isHovering = true;
	}
	public override void _MouseExit()
	{
		isHovering = false;
	}
}
