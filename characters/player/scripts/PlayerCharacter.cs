using Godot;
using System;

public partial class PlayerCharacter : CharacterBody3D
{
	private Camera3D FirstPersonCamera;
	// private Camera3D DebugCamera;

	public float gravity = ProjectSettings.GetSetting("physics/3d/default_gravity").AsSingle();
	private const float Speed = 5.0f;
	private const float JumpHorizontalSpeed = 2.0f;
	private const float LookSpeed = 0.001f;
	private const float JumpHeight = 1f;

	private float RotationX = 0.0f;
	private float RotationY = 0.0f;
	private bool isDashing = false;
	private int framesDashing = 0;

	private bool isJumping = false;
	private bool disableJumpButton = false;
	private int framesJumping = 0;
	private int MAX_FRAMES_JUMPING = 30;
	private int INITIAL_FRAMES = 10;
	private HitPoints hitPoints;
	private HitPointsBar hitPointsBar;
	public HitPointsBar HPBar { get => hitPointsBar; set => hitPointsBar = value; }

	private Node3D Sword;

	private RayCast3D interactionRayCast;
	private GodotObject hoveredObject;

	private Vector3 hookPoint;
	private bool isGrappling;

	public void ReadyPlayerCharacter()
	{
		Input.MouseMode = Input.MouseModeEnum.Captured;
		FirstPersonCamera = GetNode<Camera3D>("PlayerCharacterPrefab/firstPersonCamera");
		hitPoints = new HitPoints(100);
		hitPointsBar = GetNode<HitPointsBar>("PlayerCharacterPrefab/HitPointsBar");
		hitPointsBar.InitHitPointsBars(hitPoints);
		Sword = GetNode<Node3D>("PlayerCharacterPrefab/pc_arms_rig_v6/PC_rig/Skeleton3D/BoneAttachment3D");
		interactionRayCast = GetNode<RayCast3D>("PlayerCharacterPrefab/firstPersonCamera/RayCast3D");
		interactionRayCast.CollideWithBodies = true;

		// DebugCamera = GetNode<Camera3D>("SubViewport/Camera3D");
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


	public void HandleGrapple(double delta)
	{
		Transform3D transform = Transform;
		if (currentItem == 2 && hoveredObject is GrapplePoint && Input.IsActionJustPressed("action"))
		{
			if (!isGrappling)
			{
				isGrappling = true;
			}
		}

		if (isGrappling)
		{
			hookPoint = interactionRayCast.GetCollisionPoint() + new Vector3(0f, 2.25f, 0f);
			transform.Origin = Transform.Origin.Lerp(hookPoint, 0.05f);
			Transform = transform;
		}

		if (Input.IsActionJustReleased("action"))
		{
			isGrappling = false;
			hookPoint = Vector3.Zero;
		}
	}

	public void HandleMovement(double delta)
	{
		Vector3 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
			velocity.Y -= gravity * (float)delta / 2;

		Vector3 direction = Vector3.Zero;
		Vector2 inputDirection = Input.GetVector("move_right", "move_left", "move_backward", "move_forward");

		direction = (Transform.Basis * new Vector3(inputDirection.X, 0, inputDirection.Y)).Normalized();


		float playerSpeed = Speed;
		if (!IsOnFloor())
		{
			playerSpeed = JumpHorizontalSpeed;
		}

		HandleGrapple(delta);
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

		if (Input.IsActionPressed("jump") && isJumping && framesJumping < MAX_FRAMES_JUMPING)
		{
			if (framesJumping > INITIAL_FRAMES)
			{
				velocity.Y = Mathf.Sqrt(JumpHeight * 4f * gravity);
			}
			else
			{
				velocity.Y = Mathf.Sqrt(JumpHeight * gravity);
			}
			framesJumping++;
		}

		if (Input.IsActionJustPressed("jump") && !disableJumpButton)
		{
			isJumping = true;
			disableJumpButton = true;

			velocity.Y = Mathf.Sqrt(JumpHeight * gravity);
		}

		if (Input.IsActionJustReleased("jump") || framesJumping >= MAX_FRAMES_JUMPING)
		{
			isJumping = false;
		}

		if (IsOnFloor())
		{
			disableJumpButton = false;
			isJumping = false;
			framesJumping = 0;
		}

		Velocity = velocity;
		MoveAndSlide();
	}

	public void TakeDamage(int damage)
	{
		hitPointsBar.TakeDamage(damage);
	}

	private string[] ItemList = new string[3]{
		"Sword",
		"Heal",
		"Grapple",
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
		if (Input.IsActionJustPressed("swap_grapple"))
		{
			currentItem = 2;
		}

		if (CurrentItem == "Heal")
		{
			Sword.Visible = false;
			Sword.GetChild<Sword>(0).GetChild<CollisionShape3D>(0).Disabled = true;
		}
		else
		{
			Sword.Visible = true;
			Sword.GetChild<Sword>(0).GetChild<CollisionShape3D>(0).Disabled = false;
		}
	}

	public void HandleInteraction()
	{
		GodotObject interactable = interactionRayCast.GetCollider();
		if (interactable != null && interactable is GrapplePoint)
		{
			hoveredObject = interactable;
			((GrapplePoint)hoveredObject).Hover();
		}

		if (interactable == null && hoveredObject != null)
		{
			if (hoveredObject is GrapplePoint)
			{
				((GrapplePoint)hoveredObject).LeaveHover();
			}
			hoveredObject = null;
		}
	}

	public override void _PhysicsProcess(double delta)
	{
		HandleMovement(delta);
		HandleInteraction();

		// Transform3D debugCameraTransform = Transform;
		// debugCameraTransform.Origin = new Vector3(Transform.Origin.X + 10.0f, Transform.Origin.Y, Transform.Origin.Z);
		// debugCameraTransform.Basis = new Basis(new Vector3(0, 0, -1), new Vector3(0, 1, 0), new Vector3(1, 0, 0));
		// DebugCamera.Transform = debugCameraTransform;
	}
}
