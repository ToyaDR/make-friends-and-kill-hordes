using Godot;
using System;

public partial class PlayerCharacter : CharacterBody3D
{
	private Camera3D FirstPersonCamera;

	public float gravity = ProjectSettings.GetSetting("physics/3d/default_gravity").AsSingle();
	private const float Speed = 5.0f;
	private const float DashSpeed = 40.0f;
	private const float LookSpeed = 0.001f;

	private float RotationX = 0.0f;
	private float RotationY = 0.0f;
	private bool isDashing = false;
	private int framesDashing = 0;

	private HitPoints hitPoints;
	private HitPointsBar hitPointsBar;

	public void ReadyPlayerCharacter()
	{
		Input.MouseMode = Input.MouseModeEnum.Captured;
		FirstPersonCamera = GetNode<Camera3D>("PlayerCharacterPrefab/firstPersonCamera");
		hitPoints = new HitPoints(100);
		hitPointsBar = GetNode<HitPointsBar>("PlayerCharacterPrefab/HitPointsBar");
		hitPointsBar.InitHitPointsBars(hitPoints);
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

		if (Input.IsActionJustPressed("dash") && !isDashing)
		{
			isDashing = true;
			framesDashing = 0;
		}

		if (framesDashing >= 15)
		{
			isDashing = false;
		}

		if (isDashing)
		{
			framesDashing++;
		}

		float playerSpeed = isDashing ? DashSpeed : Speed;
		if (direction != Vector3.Zero)
		{

			velocity.X = direction.X * playerSpeed;
			velocity.Z = direction.Z * playerSpeed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, playerSpeed);
			velocity.Z = Mathf.MoveToward(Velocity.Z, 0, playerSpeed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}

	public void TakeDamage(int damage)
	{
		hitPointsBar.TakeDamage(damage);
	}

	private string[] ItemList = new string[2]{
		"Sword",
		"Heal",
	};

	private int currentItem = 0;
	public string CurrentItem { get => ItemList[currentItem]; }

	public void SwapItem()
	{
		if (Input.IsActionJustPressed("swap_forward"))
		{
			currentItem = (currentItem + 1) % ItemList.Length;
		}
		if (Input.IsActionJustPressed("swap_back"))
		{
			if (currentItem == 0)
			{
				currentItem = ItemList.Length + (currentItem - 1);
			}
			else
			{
				currentItem--;
			}
		}

		if (Input.IsActionJustPressed("swap_sword"))
		{
			currentItem = 0;
		}
		if (Input.IsActionJustPressed("swap_heal"))
		{
			currentItem = 1;
		}
	}

	public override void _Process(double delta)
	{
		HandleMovement(delta);
	}
}
