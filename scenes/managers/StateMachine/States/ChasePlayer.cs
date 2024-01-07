using Godot;
using System;

public partial class ChasePlayer : State
{
  [Export] Enemy entity;
  [Export] StatsComponent statsComponent;
  [Export] float speedMultiplier = 1;
  [Export] float duration = 1;
  [Export] State nextState;

  public override void PhysicsUpdate(double delta)
  {
    base.Update();
    entity.MoveTowards(SkillListGlobal.GetPlayerDirection(entity.GlobalPosition) * entity.Speed * speedMultiplier);
  }

  override public void Enter(params Variant[] args)
  {
    GetTree().CreateTimer(duration, false).Timeout += () =>
    {
      stateMachine.TransitionTo(nextState.name);
    };
  }
}
