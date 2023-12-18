using Godot;
using System;
using System.Dynamic;

public partial class Enemy : CharacterBody2D
{
	[Export] StatsComponent statsComponent;
	public Player player { get; set; }

	double hitEffectTime = 0.25;

	public override void _Ready()
	{
		statsComponent.statGroup.HealthDepletedEvent += SceduleDeath;
	}

	public override void _PhysicsProcess(double delta)
	{
		Velocity = Position.DirectionTo(player.Position) * statsComponent.statGroup.GetStat(StatType.Speed).Value;
		MoveAndSlide();
	}

	void SceduleDeath()
	{
		GetTree().CreateTimer(hitEffectTime).Timeout += Die;
	}

	public void Die()
	{
		QueueFree();
	}
}
