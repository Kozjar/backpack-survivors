using Godot;
using System;
using System.Dynamic;

public partial class Enemy : CharacterBody2D
{
  [Export] StatsComponent statsComponent;
  [Export] public Player player { get; set; }
  [Export] bool log = false;
  public Vector2 extraVelocity = new Vector2(0, 0);

  double hitEffectTime = 0.25;
  [Export] float avoidanceEffect = 1;

  public float Speed => statsComponent.statGroup.GetStat(StatType.Speed).Value;

  [Export] Vector2 customDirection;

  public override void _Ready()
  {
    statsComponent.statGroup.HealthDepletedEvent += SceduleDeath;
    // CustomIntegrator = true;
  }

  // public override void _IntegrateForces(PhysicsDirectBodyState2D state)
  // {
  // if (log)
  // {
  // for (int i = 0; i < state.GetContactCount(); i++)
  // {
  // var collider = state.GetContactLocalNormal(i);
  // GD.Print(collider, state.GetContactImpulse(i), state.GetContactColliderObject(i));
  // if (state.GetContactColliderObject(i) is Enemy enemy)
  // {
  // GD.Print(enemy.force);
  // Position += state.GetContactLocalNormal(i) / 2 - enemy.force;
  // }
  // GD.Print(state.GetContactCount(), state.GetContactCollider(0));

  // }

  // state.Transform.Origin += force;

  // }
  // base._IntegrateForces(state);
  // }

  public override void _PhysicsProcess(double delta)
  {
    MoveTowards(SkillListGlobal.GetPlayerDirection(GlobalPosition) * Speed);
    // MoveTowards(customDirection * Speed);

    // if (GetOverlappingAreas().Count > 0)
    // {


    // }
    // Velocity = direction;
    // ApplyForce(direction);
    // ConstantForce = direction;
    // ApplyCentralForce(direction * (float)delta);
    // ApplyCentralForce(direction);
    // force = direction * (float)delta;
    // force = direction;
    // var collision = MoveAndCollide(direction * (float)delta);
    // if (collision != null && collision.GetCollider() is RigidBody2D body)
    // {
    // GD.Print(collision.GetNormal());
    //   body.Position -= collision.GetNormal();
    // }






    // foreach (var collistion in getcollisio)
    // {

    // }
  }

  public void MoveTowards(Vector2 direction)
  {
    // var collision = MoveAndCollide(direction);
    // if (collision != null)
    // {
    //   var remainer = collision.GetRemainder();
    //   var normal = -collision.GetNormal();
    //   var depth = collision.GetDepth();
    //   GD.Print(remainer);
    //   if (collision.GetCollider() is Enemy enemy)
    //   {
    //     enemy.Position += depth * normal;
    //   }
    // }
    Velocity = direction;
    MoveAndSlide();
    // for (int i = 0; i < GetSlideCollisionCount(); i++)
    // {
    //   var collision = GetSlideCollision(i);
    //   if (collision.GetCollider() is Enemy enemy)
    //   {
    //     // enemy.extraVelocity = collision.GetNormal();
    //     // enemy.Velocity += -collision.GetNormal();
    //     var remainer = collision.GetRemainder();
    //     var normal = collision.GetNormal();
    //     enemy.extr += -normal * remainer;
    //     if (log)
    //     {
    //       // GD.Print(normal);
    //     }
    //   }
    // }
    // extraVelocity = Vector2.Zero;
  }

  void SceduleDeath()
  {
    GetTree().CreateTimer(hitEffectTime, false).Timeout += Die;
  }

  public void Die()
  {
    QueueFree();
  }
}
