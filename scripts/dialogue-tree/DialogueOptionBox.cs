using Godot;
using System;

public partial class DialogueOptionBox : StaticBody3D
{
	static Color hoverColor = new(255, 0, 236, 1);
	static Color defaultColor = new(0, 0, 0, 1);
	private Label3D label;
	public Label3D Label { get => label; set => label = value; }

	private bool isHovering;
	public bool IsHovering { get => isHovering; set => isHovering = value; }
	private bool isExit;
	public bool IsExit { get => isExit; set => isExit = value; }

	public override void _Ready()
	{
		label = GetNode<Label3D>("Label3D");
	}

	public override void _MouseEnter()
	{
		label.OutlineModulate = hoverColor;
		isHovering = true;
	}
	public override void _MouseExit()
	{
		label.OutlineModulate = defaultColor;
		isHovering = false;
	}
}
