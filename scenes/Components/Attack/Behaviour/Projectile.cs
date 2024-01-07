using Godot;
using System;

public partial class Projectile : AttackBahaviour
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

  public override void InitializePosition(Vector2 position, Vector2? target = null)
  {
    base.InitializePosition(position, target);
    if (target != null)
    {
      attack.LookAt(attack.GlobalPosition - target.Value);
    }
    else
    {
      var direction = Vector2.Up;
      var randomRotation = GD.RandRange(-MathF.PI, MathF.PI);
      attack.LookAt(attack.GlobalPosition - direction.Rotated((float)randomRotation));
    }
  }
}
