using Godot;
using System;

public partial class AnxietyGremlin : Enemy
{
	private const string SlashAnimation = "anxietyGremlin_slash/gremlin_SLASH";
	private const string IdleAnimation = "anxietyGremlin_idle/gremlin_IDLE";
	private const string NoHeadIdleAnimation = "anxietyGremlin_idle_noheadAnim/gremlin_Idle_nohead";
	private AnimationPlayer animPlayer;

	private int maxHitPoints = 10;
	public int MaxHitPoints { get => maxHitPoints; }

	private int currentHitPoints;

	public int CurrentHitPoints { get => currentHitPoints; set => currentHitPoints = value; }
	private Skeleton3D skeleton;

	private Weapon claw;

	public override void _Ready()
	{
		CreateGremlin();
	}

	public void CreateGremlin()
	{
		currentHitPoints = maxHitPoints;
		animPlayer = GetNode<AnimationPlayer>("anxietyGremlin_rig/anxietyGremlin_AnimPlayer");
		skeleton = GetNode<Skeleton3D>("anxietyGremlin_rig/anxietyGremlin_rig/Skeleton3D");

		Animation idle = animPlayer.GetAnimation(IdleAnimation);
		idle.LoopMode = Animation.LoopModeEnum.Linear;

		Animation slash = animPlayer.GetAnimation(SlashAnimation);
		slash.LoopMode = Animation.LoopModeEnum.Linear;

		// player.Queue(IdleAnimation);
		// player.SpeedScale = 1.5f;
		animPlayer.Play(SlashAnimation);
		animPlayer.ProcessThreadGroup = ProcessThreadGroupEnum.MainThread;
		claw = GetNode<Weapon>("anxietyGremlin_rig/anxietyGremlin_rig/Skeleton3D/ClawBone/Claw");
		claw.Damage = 2;
	}

	public void LookAtPlayer(Vector3 playerPosition)
	{
		int headIndex = skeleton.FindBone("DEF-head");

		Quaternion headRotation = new Quaternion(new Vector3(Position.X, Position.Y + 2, -Position.Z), Position.DirectionTo(playerPosition));

		skeleton.SetBonePoseRotation(headIndex, headRotation);
	}

	public async void Slash()
	{
		animPlayer.Play(SlashAnimation);
	}

	public override void _Process(double delta)
	{
		// Slash();
	}
}
