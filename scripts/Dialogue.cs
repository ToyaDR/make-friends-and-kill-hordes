using Godot;
using System;

public partial class Dialogue : Node3D
{
	private Label3D NPCText;
	private Label3D Option1Text;
	private Label3D Option2Text;

	public override void _Ready()
	{
		NPCText = GetChild<RigidBody3D>(0).GetChild<Label3D>(0);
		Option1Text = GetChild<RigidBody3D>(1).GetChild<Label3D>(0);
		Option2Text = GetChild<RigidBody3D>(2).GetChild<Label3D>(0);
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
