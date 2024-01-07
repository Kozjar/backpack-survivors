using Godot;
using System;

public partial class DashState : State
{
  [Export] float dashSpeed = 500;
  [Export] Enemy entity;
  [Export] State nextState;
  Vector2 direction;

  public override void Enter(params Variant[] args)
  {
    base.Enter(args);
    DashTowards((Vector2)args[0], (float)args[1]);
  }

  void DashTowards(Vector2 direction, float distance)
  {
    this.direction = direction;
    // entity.Velocity = direction * dashSpeed;
    GetTree().CreateTimer(distance / dashSpeed).Timeout += () => stateMachine.TransitionTo(nextState.name);
  }

  public override void PhysicsUpdate(double delta)
  {
    base.PhysicsUpdate(delta);
    entity.MoveTowards(direction * dashSpeed);

    // entity.MoveAndCollide(direction * dashSpeed * (float)delta);
  }

  public override void Exit()
  {
    base.Exit();
    // entity.Velocity = Vector2.Zero;
  }
}
