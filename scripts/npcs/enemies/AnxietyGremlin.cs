using Godot;
using System;

public partial class AnxietyGremlin : RigidBody3D
{
	private const string SlashAnimation = "anxietyGremlin_slash/gremlin_SLASH";
	private const string IdleAnimation = "anxietyGremlin_idle/gremlin_IDLE";
	private AnimationPlayer player;

	private int maxHitPoints = 10;
	public int MaxHitPoints { get => maxHitPoints; }

	private int currentHitPoints;

	public int CurrentHitPoints { get => currentHitPoints; set => currentHitPoints = value; }
	private Skeleton3D skeleton;

	public override void _Ready()
	{
		CreateGremlin();
	}

	public void CreateGremlin()
	{
		currentHitPoints = maxHitPoints;
		player = GetNode<AnimationPlayer>("anxietyGremlin_rig/anxietyGremlin_AnimPlayer");
		skeleton = GetNode<Skeleton3D>("anxietyGremlin_rig/anxietyGremlin_rig/Skeleton3D");

		Animation idle = player.GetAnimation(IdleAnimation);
		idle.LoopMode = Animation.LoopModeEnum.Linear;

		// Animation slash = player.GetAnimation(SlashAnimation);
		// slash.LoopMode = Animation.LoopModeEnum.None;

		// player.Queue(IdleAnimation);
		// player.SpeedScale = 1.5f;
	}

	public void LookAtPlayer(Vector3 playerPosition)
	{
		int headIndex = skeleton.FindBone("DEF-head");

		Quaternion headRotation = new Quaternion(new Vector3(Position.X, Position.Y, -Position.Z), Position.DirectionTo(playerPosition));

		skeleton.SetBonePoseRotation(headIndex, headRotation);
	}

	public async void Slash()
	{
		player.Play(SlashAnimation);
	}

	public override void _Process(double delta)
	{
		// Slash();
	}
}
