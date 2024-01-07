using Godot;
using System;

public partial class PlayerMovementController : Node
{
  [Export] StatsComponent statsComponent;
  [Export] CharacterBody2D player;

  float Speed => statsComponent.statGroup.GetStat(StatType.Speed)?.Value ?? 0;

  public override void _PhysicsProcess(double delta)
  {
    var direction = new Vector2(0, 0);
    if (Input.IsActionPressed("ui_left")) direction.X -= 1;
    if (Input.IsActionPressed("ui_right")) direction.X += 1;
    if (Input.IsActionPressed("ui_up")) direction.Y -= 1;
    if (Input.IsActionPressed("ui_down")) direction.Y += 1;

    player.Velocity = direction.Normalized() * Speed;
    player.MoveAndSlide();
  }
}
