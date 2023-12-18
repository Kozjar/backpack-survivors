using Godot;
using System;

public partial class Experience : Area2D
{
	public int amount;
	public Node2D target;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (target != null) {
			Position += Position.DirectionTo(target.GlobalPosition) * (float)delta * 300;
		}
	}
}
