
using Godot;
using System;
using System.Transactions;

public partial class Dialogue : Node3D
{
	private Label3D NPCText;

	private NPCDialogue current;
	private DialogueTree dialogueTree;
	private PackedScene DialogueOptionBoxScene;

	public override void _Ready()
	{
		NPCText = GetChild<StaticBody3D>(0).GetChild<Label3D>(0);
		DialogueOptionBoxScene = GD.Load<PackedScene>("res://scenes/dialogue/DialogueOption.tscn");
	}

	public void SetTree(DialogueTree tree)
	{
		dialogueTree = tree;
		current = tree.Start;
		SetDialogueBoxes(current);
	}

	public void Talk(NPCDialogue npcText)
	{
		current = npcText;
		NPCText.Text = npcText.Text;
		if (npcText.Responses == null)
		{
			return;
		}
		DeleteDialogueBoxes();
		SetDialogueBoxes(current);
	}

	private void DeleteDialogueBoxes()
	{
		for (int i = 1; i < GetChildCount(); i++) // Child at index 0 is NPCDialogue
		{
			Node3D currentChild = GetChild<Node3D>(i);
			if (currentChild is DialogueOptionBox)
			{
				currentChild.QueueFree();
			}
		}
	}

	private void CreateDialogueBox(DialogueOption option, Vector3 optionPosition)
	{
		DialogueOptionBox newOption = DialogueOptionBoxScene.Instantiate() as DialogueOptionBox;
		AddChild(newOption);
		newOption.Label.Text = option.Text;
		newOption.IsExit = option.isExit;
		newOption.IsHovering = false;
		newOption.Position = optionPosition;
	}

	private void SetDialogueBoxes(NPCDialogue node)
	{
		NPCText.Text = node.Text;

		for (int i = 0; i < node.Responses.Length; i++)
		{
			CreateDialogueBox(node.Responses[i], new Vector3(1f, 0.3f - i * 0.55f, 0f));
		}
	}

	private void GetHoveredDialogue()
	{
		for (int i = 1; i < GetChildCount(); i++) // Child at index 0 is NPCDialogue
		{
			Node3D currentChild = GetChild<Node3D>(i);
			if (currentChild is DialogueOptionBox && (currentChild as DialogueOptionBox).IsHovering)
			{
				Talk(current.Responses[i - 1].Result);
			}
		}
	}

	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseButton)
		{
			// if (Option1Box != null && Option1Box.IsHovering)
			// {
			// 	if (current?.Responses?.Length > 0)
			// 	{
			// 		if (current.Responses[0].isExit)
			// 		{
			// 			GetTree().ChangeSceneToFile("res://scenes/locations/Tavern.tscn");
			// 			return;
			// 		}
			// 		Talk(current.Responses[0].Result);
			// 	}
			// }
			// if (Option2Box != null && Option2Box.IsHovering)
			{
				if (current?.Responses?.Length > 1)
				{
					if (current.Responses[1].isExit)
					{
						GetTree().ChangeSceneToFile("res://scenes/locations/Tavern.tscn");
						return;
					}
					Talk(current.Responses[1].Result);
				}
				else
				{
					GetTree().ChangeSceneToFile("res://scenes/locations/Tavern.tscn");
				}
			}
		}
	}
}