using Godot;
using System;

public partial class Player : CharacterBody3D
{
	public RayCast3D InteractionRaycast;
	public const float Speed = 5.0f;
	public const float JumpVelocity = 4.5f;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/3d/default_gravity").AsSingle();

	public override void _Ready()
	{
		base._Ready();
		RayCast3D interactionRayCast = GetNode("Adventurer/Camera3D/RayCast3D") as RayCast3D;
		InteractionRaycast = interactionRayCast;
	}

	public override void _PhysicsProcess(double delta)
	{
		// Add the gravity.
		// if (!IsOnFloor())
		// 	velocity.Y -= gravity * (float)delta;

		// Handle Jump.
		// if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
		// 	velocity.Y = JumpVelocity;

		// // Get the input direction and handle the movement/deceleration.
		// // As good practice, you should replace UI actions with custom gameplay actions.
		// Vector2 inputDir = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		// Vector3 direction = (Transform.Basis * new Vector3(inputDir.X, 0, inputDir.Y)).Normalized();
		// if (direction != Vector3.Zero)
		// {
		// 	velocity.X = direction.X * Speed;
		// 	velocity.Z = direction.Z * Speed;
		// }
		// else
		// {
		// 	velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		// 	velocity.Z = Mathf.MoveToward(Velocity.Z, 0, Speed);
		// }

		if (InteractionRaycast.IsColliding())
		{
			GodotObject interactable = InteractionRaycast.GetCollider();

			if (interactable != null && interactable.HasMethod("Interact"))
			{
				// GD.Print("See interactable");
				Interactable hitInteractable = interactable as Interactable;
				// TODO set message on gui
				if (Input.IsActionPressed("interact"))
				{
					hitInteractable.Interact();
				}
			}
		}

		Vector3 direction = Vector3.Zero;

		if (Input.IsActionPressed("move_forward"))
		{
			direction.Z += 1.0f;
		}

		if (Input.IsActionPressed("move_backward"))
		{
			direction.Z -= 1.0f;
		}

		if (Input.IsActionPressed("move_left"))
		{
			direction.X += 1.0f;
		}

		if (Input.IsActionPressed("move_right"))
		{
			direction.X -= 1.0f;
		}

		// GD.Print(Position);

		MoveAndSlide();
		Velocity = direction * Speed;
		MoveAndSlide();
	}
}
