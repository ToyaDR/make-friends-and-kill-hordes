using Godot;
using System;
using System.Transactions;

public partial class Dialogue : Node3D
{
	private Label3D NPCText;

	private DialogueOptionBox Option1Box;
	private Label3D Option1Text;

	private DialogueOptionBox Option2Box;
	private Label3D Option2Text;
	private NPCDialogue current;

	public override void _Ready()
	{
		NPCText = GetChild<StaticBody3D>(0).GetChild<Label3D>(0);

		Option1Box = GetChild<DialogueOptionBox>(1);
		Option1Text = Option1Box.GetChild<Label3D>(0);

		Option2Box = GetChild<DialogueOptionBox>(2);
		Option2Text = Option2Box.GetChild<Label3D>(0);
	}

	public void Talk(NPCDialogue npcText)
	{
		current = npcText;
		NPCText.Text = npcText.Text;
		if (npcText.Responses == null)
		{
			Option1Box.Visible = false;
			Option2Box.Visible = false;
			return;
		}
		Option1Text.Text = npcText.Responses[0].Text;
		Option2Text.Text = npcText.Responses[1].Text;
	}


	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseButton)
		{
			if (Option1Box != null && Option1Box.IsHovering)
			{
				if (current?.Responses?.Length > 0)
				{
					if (current.Responses[0].isExit)
					{
						GetTree().ChangeSceneToFile("res://scenes/Main.tscn");
						return;
					}
					Talk(current.Responses[0].Result);
				}
			}
			if (Option2Box != null && Option2Box.IsHovering)
			{
				if (current?.Responses?.Length > 1)
				{
					if (current.Responses[1].isExit)
					{
						GetTree().ChangeSceneToFile("res://scenes/Main.tscn");
						return;
					}
					Talk(current.Responses[1].Result);
				}
				else
				{
					GetTree().ChangeSceneToFile("res://scenes/Main.tscn");
				}
			}
		}
	}
}