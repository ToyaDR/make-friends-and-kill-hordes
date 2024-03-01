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

	public void OnHover()
	{
		if (!IsHovering)
		{
			label.OutlineModulate = hoverColor;
			IsHovering = true;
		}
	}

	public void OnHoverExit()
	{
		if (IsHovering)
		{
			label.OutlineModulate = defaultColor;
			IsHovering = false;
		}
	}
	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseButton && IsHovering)
		{
			GD.Print(string.Format("Clicked {0}", GetPath()));
		}
	}
}
