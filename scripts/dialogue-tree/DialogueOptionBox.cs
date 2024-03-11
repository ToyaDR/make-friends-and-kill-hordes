using Godot;
using System;

public partial class DialogueOptionBox : StaticBody3D
{
	static Color hoverColor = new(255, 0, 236, 1);
	static Color defaultColor = new(0, 0, 0, 1);
	private Label3D label;
	private bool isHovering;
	public bool IsHovering { get => isHovering; set => isHovering = value; }

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