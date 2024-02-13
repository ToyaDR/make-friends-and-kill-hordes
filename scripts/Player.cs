using Godot;
using System;

public partial class Player : CharacterBody3D
{
	public RayCast3D InteractionRaycast;
	public Camera3D Camera;
	public const float Speed = 5.0f;
	public const float JumpVelocity = 4.5f;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/3d/default_gravity").AsSingle();

	public float mouseSensitivityY = 0.1f;
	public float mouseSensitivityX = 0.3f;
	public override void _Ready()
	{
		base._Ready();
		RayCast3D interactionRayCast = GetNode("Adventurer/Camera3D/RayCast3D") as RayCast3D;
		InteractionRaycast = interactionRayCast;

		Camera3D camera = GetNode("Adventurer/Camera3D") as Camera3D;
		Camera = camera;
	}

	public override void _Input(InputEvent @event)
	{
		base._Input(@event);
		if (@event is InputEventMouseMotion)
		{
			InputEventMouseMotion mouseEvent = @event as InputEventMouseMotion;

			float yRotation = Mathf.DegToRad(-mouseEvent.Relative.X * mouseSensitivityX);
			RotateY(yRotation);

			float xRotation = Mathf.DegToRad(mouseEvent.Relative.Y * mouseSensitivityY);
			float clampedX = Mathf.Clamp(xRotation, Mathf.DegToRad(-30), Mathf.DegToRad(60));
			Camera.RotateX(clampedX);
		}
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector3 velocity = Vector3.Zero;

		// Add the gravity.
		if (!IsOnFloor())
			velocity.Y -= gravity * (float)delta;

		// Handle Jump.
		// if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
		// 	velocity.Y = JumpVelocity;

		// // Get the input direction and handle the movement/deceleration.
		// // As good practice, you should replace UI actions with custom gameplay actions.
		// Vector2 inputDir = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		// Vector3 direction = (Transform.Basis * new Vector3(inputDir.X, 0, inputDir.Y)).Normalized();


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
		Vector2 inputDirection = Input.GetVector("move_right", "move_left", "move_backward", "move_forward");

		direction = (Transform.Basis * new Vector3(inputDirection.X, 0, inputDirection.Y)).Normalized();

		if (direction != Vector3.Zero)
		{
			velocity.X = direction.X * Speed;
			velocity.Z = direction.Z * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			velocity.Z = Mathf.MoveToward(Velocity.Z, 0, Speed);
		}
		// GD.Print(Position);
		Velocity = velocity;
		MoveAndSlide();
	}
}
