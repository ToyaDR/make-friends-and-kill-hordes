using Godot;
using System;

public partial class Dialogue : Node3D
{
	private Label3D NPCText;

	private StaticBody3D Option1Box;
	private Label3D Option1Text;

	private StaticBody3D Option2Box;
	private Label3D Option2Text;

	public override void _Ready()
	{
		NPCText = GetChild<RigidBody3D>(0).GetChild<Label3D>(0);

		Option1Box = GetChild<StaticBody3D>(1);
		Option1Text = Option1Box.GetChild<Label3D>(0);

		Option2Box = GetChild<StaticBody3D>(2);
		Option2Text = Option2Box.GetChild<Label3D>(0);
	}

	public void Talk(NPCDialogue npcText)
	{
		NPCText.Text = npcText.Text;
		Option1Text.Text = npcText.Responses[0].Text;
		Option2Text.Text = npcText.Responses[1].Text;
	}

	public override void _Process(double delta)
	{
	}
}
