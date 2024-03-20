using Godot;
using System;
using System.Threading.Tasks;

public partial class combat : Node3D
{

	private PackedScene GremlinScene;
	private Node3D gremlins;

	private Player player;
	private bool gremlinSlash = false;

	private int gremlinCount;
	public override void _Ready()
	{
		gremlinCount = 0;
		GremlinScene = GD.Load<PackedScene>("res://prefabs/characters/anxietyGremlin_rig.tscn");
		player = GetNode<Player>("%Player");

		gremlins = GetNode<Node3D>("gremlins");
	}

	public void GenerateGremlins()
	{
		AnxietyGremlin newGremlin = GremlinScene.Instantiate() as AnxietyGremlin;
		gremlins.AddChild(newGremlin);
		newGremlin.Position = new Vector3(player.Position.X, 1, player.Position.Z - 10);

		gremlinCount += 1;
	}

	public override void _Process(double delta)
	{
		if (gremlinCount != 1)
		{
			GenerateGremlins();
		}

		for (int i = 0; i < gremlinCount; i++)
		{
			gremlins.GetChild<AnxietyGremlin>(i).LookAtPlayer(player.Position);
		}
	}

}
