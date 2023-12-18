using Godot;
using System;

public partial class EnemySpawn : Path2D
{
	[Export] public Camera2D camera;
	[Export] public PackedScene enemyScene;
	[Export] public PackedScene xpScene;
	[Export] public PathFollow2D pathFollow2D;
	[Export] public Node2D container;
	[Export] public Player player;

	public override void _Ready()
	{
		var width = camera.GetViewportRect().Size.X / 2;
		var height = camera.GetViewportRect().Size.Y / 2;

		Curve.AddPoint(new Vector2(-width, -height));
		Curve.AddPoint(new Vector2(width, -height));
		Curve.AddPoint(new Vector2(width, height));
		Curve.AddPoint(new Vector2(-width, height));
		Curve.AddPoint(new Vector2(-width, -height));

		pathFollow2D.ProgressRatio = GD.Randf();
	}

	public override void _Process(double delta)
	{
	}

	public void OnEnemySpawn()
	{
		var enemyInstance = enemyScene.Instantiate<Enemy>();
		enemyInstance.player = player;
		enemyInstance.GlobalPosition = GenerateEnemyPosition();

		container.AddChild(enemyInstance);
	}

	private Vector2 GenerateEnemyPosition()
	{
		pathFollow2D.ProgressRatio = GD.Randf();

		return pathFollow2D.Position +  camera.GlobalPosition;
	}
}
