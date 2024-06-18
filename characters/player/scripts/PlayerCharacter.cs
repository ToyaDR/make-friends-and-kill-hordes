using Godot;
using System;

public partial class PlayerCharacter : CharacterBody3D
{
	private Camera3D FirstPersonCamera;

	public float gravity = ProjectSettings.GetSetting("physics/3d/default_gravity").AsSingle();
	private const float Speed = 5.0f;
	private const float LookSpeed = 0.001f;

	private float RotationX = 0.0f;
	private float RotationY = 0.0f;

	public void ReadyPlayerCharacter()
	{
		Input.MouseMode = Input.MouseModeEnum.Captured;
		FirstPersonCamera = GetNode<Camera3D>("PlayerCharacterPrefab/firstPersonCamera");
	}

	public override void _Ready()
	{
		ReadyPlayerCharacter();
	}

	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseMotion mouseMotion)
		{
			RotationX += mouseMotion.Relative.X * LookSpeed;
			RotationY += mouseMotion.Relative.Y * LookSpeed;

			Transform3D transform = Transform;
			transform.Basis = Basis.Identity;
			Transform = transform;

			// float clampedX = Mathf.Clamp(RotationX, Mathf.DegToRad(-30), Mathf.DegToRad(30));
			float clampedY = Mathf.Clamp(RotationY, Mathf.DegToRad(-90), Mathf.DegToRad(90));

			RotateObjectLocal(Vector3.Up, -RotationX);
			RotateObjectLocal(Vector3.Right, clampedY);
		}
	}
	public void HandleMovement(double delta)
	{
		Vector3 velocity = Vector3.Zero;

		// Add the gravity.
		if (!IsOnFloor())
			velocity.Y -= gravity * (float)delta;

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
		Velocity = velocity;
		MoveAndSlide();
	}

	public override void _Process(double delta)
	{
		HandleMovement(delta);
	}
}
