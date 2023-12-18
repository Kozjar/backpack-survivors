using Godot;
using System;

public partial class PlayerMovementController : Node
{
  [Export] StatsComponent statsComponent;
  [Export] Node2D player;

  float Speed => statsComponent.statGroup.GetStat(StatType.Speed)?.Value ?? 0;

  public override void _Process(double delta)
  {
    var direction = new Vector2(0, 0);
    if (Input.IsActionPressed("ui_left")) direction.X -= 1;
    if (Input.IsActionPressed("ui_right")) direction.X += 1;
    if (Input.IsActionPressed("ui_up")) direction.Y -= 1;
    if (Input.IsActionPressed("ui_down")) direction.Y += 1;

    player.Position += direction.Normalized() * (float)delta * Speed;
  }
}
