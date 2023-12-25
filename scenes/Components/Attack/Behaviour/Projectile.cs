using Godot;
using System;

public partial class Projectile : Node
{
  [Export] Node2D attack;
  [Export] float speed = 400f;
  [Export] float maxDistance = 500f;
  float distancePassed = 0;

  public override void _Ready()
  {
  }

  public override void _Process(double delta)
  {
    var distance = (float)delta * speed;
    distancePassed += distance;

    if (distancePassed > maxDistance)
    {
      attack.QueueFree();

      return;
    }
    attack.Position += Vector2.Right.Rotated(attack.Rotation).Normalized() * distance;
  }
}
